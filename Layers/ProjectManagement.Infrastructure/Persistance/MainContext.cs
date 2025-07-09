using Softwash.Infrastructure.Persistance.EntityConfigurations;

namespace Softwash.Infrastructure.Persistance;

public class MainContext : DbContext
{
    public MainContext(DbContextOptions<MainContext> options) : base(options)
    {
    }
    public MainContext()
    {
        
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Login> Logins { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var configurationTypes = typeof(MainContext).Assembly.GetTypes()
                                  .Where(t => t.GetInterfaces().Any(i => i.IsGenericType
                                  && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
                                  && t != typeof(CommonEntityConfiguration<>));

        foreach (var configurationType in configurationTypes)
        {
            dynamic configurationInstance = Activator.CreateInstance(configurationType);
            modelBuilder.ApplyConfiguration(configurationInstance);
        }

        #region Global Filters

        modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);
        modelBuilder.Entity<Login>().HasQueryFilter(u => !u.IsDeleted);

        #endregion

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetAuditFields();
        return base.SaveChangesAsync(cancellationToken);
    }
    private void SetAuditFields()
    {
        var entries = ChangeTracker.Entries()
                                     .Where(e => e.Entity is IAuditEntity &&
                                      (e.State == EntityState.Added || e.State == EntityState.Modified) &&
                                      e.Entity.GetType() != typeof(Login) &&
                                      e.Entity.GetType() != typeof(User) &&
                                      e.Entity.GetType() != typeof(User));
                                 
        foreach (var entry in entries)
        {
            var entity = (IAuditEntity)entry.Entity;

            switch (entry.State)
            {
                case EntityState.Added:
                    entity.CreatedDate = DateTime.UtcNow;
                    entity.CreatedById = GetClaims.GetUserId();
                    break;

                case EntityState.Modified:
                    entity.ModifiedDate = DateTime.UtcNow;
                    entity.ModifiedById = GetClaims.GetUserId();

                    break;
            }
        }
    }

    private long? GetCurrentUserId()
    {
        long userIdClaim = Convert.ToInt64(GetClaims.GetUserId());
        return (userIdClaim != null || userIdClaim != 0) ? (Convert.ToInt64(userIdClaim)) : (long?)null;
    }
}