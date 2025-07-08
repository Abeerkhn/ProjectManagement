namespace Softwash.Infrastructure.Persistance.EntityConfigurations;
public class CommonEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : AuditDeleteableEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> entity)
    {
        entity.Property(x => x.CreatedDate).HasColumnType("SMALLDATETIME");
        entity.Property(x => x.ModifiedDate).HasColumnType("SMALLDATETIME");
        entity.Property(x => x.IsDeleted).HasColumnType("BIT").HasDefaultValue(false);
    }
}
