namespace Softwash.Domain.EntityConfigurations;

public class LoginEntityConfiguration : IEntityTypeConfiguration<Login>
{
    public void Configure(EntityTypeBuilder<Login> entity)
    {
        entity.ToTable("Logins", "Auth");
        entity.HasKey(x => x.Id);
        //  entity.Property(x => x.Id).ValueGeneratedNever();

            entity.Property(x => x.OTP).HasColumnType("NVARCHAR").HasMaxLength(10);
            entity.Property(x => x.OTPExpiry).HasColumnType("DATETIME").HasDefaultValueSql("DATEADD(MINUTE, 1, GETUTCDATE())");
            entity.Property(x => x.IsVerified).HasColumnType("BIT").HasDefaultValue(false);
            entity.Property(x => x.IsProfileCompleted).HasColumnType("BIT").HasDefaultValue(false);
            entity.Property(x => x.IsPasswordSetted).HasColumnType("BIT").HasDefaultValue(false);

        
    }
}
