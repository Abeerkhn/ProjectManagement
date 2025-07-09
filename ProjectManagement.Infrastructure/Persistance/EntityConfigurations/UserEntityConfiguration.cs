namespace Softwash.Domain.EntityConfigurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entity)
    {
        entity.ToTable("Users");
        entity.HasKey(x => x.Id);

        entity.Property(x => x.FirstName).HasColumnType("NVARCHAR").HasMaxLength(250);
        entity.Property(x => x.LastName).HasColumnType("NVARCHAR").HasMaxLength(250);
        entity.Property(x => x.Email).HasColumnType("NVARCHAR").HasMaxLength(250);
        entity.Property(x => x.Image).HasColumnType("NVARCHAR").HasMaxLength(500);

        entity.Property(x => x.CreatedDate).HasColumnType("SMALLDATETIME");
        entity.Property(x => x.ModifiedDate).HasColumnType("SMALLDATETIME");
        entity.Property(x => x.IsDeleted).HasColumnType("BIT").HasDefaultValue(false);

        
       


    }
}
