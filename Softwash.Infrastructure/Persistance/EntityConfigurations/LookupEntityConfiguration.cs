namespace Softwash.Infrastructure.Persistance.EntityConfigurations;

public class LookupEntityConfiguration : IEntityTypeConfiguration<Lookup>
{
    public void Configure(EntityTypeBuilder<Lookup> entity)
    {
        entity.ToTable("Lookups", "dbo");

        entity.HasKey(e => e.Id);

        entity.Property(e => e.Id)
              .HasColumnName("Id")
              .ValueGeneratedNever();

        entity.Property(e => e.Type)
              .HasColumnType("NVARCHAR")
              .HasMaxLength(250);

        entity.Property(e => e.Text)
              .HasColumnType("NVARCHAR")
              .HasMaxLength(500);

        entity.Property(e => e.Value)
              .HasColumnType("NVARCHAR")
              .HasMaxLength(400);

        #region Data seed

        entity.HasData(
            new Lookup { Id = 1, Type = "Gender", Text = "Male", Value = "Male", Order = 1 },
            new Lookup { Id = 2, Type = "Gender", Text = "FeMale", Value = "FeMale", Order = 2 },
            new Lookup { Id = 101, Type = "ScreenType", Text = "Videos", Value = "Videos", Order = 1 },
            new Lookup { Id = 102, Type = "ScreenType", Text = "Products", Value = "Products", Order = 2 },
            new Lookup { Id = 103, Type = "ScreenType", Text = "Deals", Value = "Deals", Order = 3 }
        );

        #endregion
    }
}
