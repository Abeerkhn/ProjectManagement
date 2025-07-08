using ProjectManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Infrastructure.Persistance.EntityConfigurations
{
    public class ProjectTaskEntityConfiguration : IEntityTypeConfiguration<ProjectTask>
    {
        public void Configure(EntityTypeBuilder<ProjectTask> entity)
        {
            entity.ToTable("ProjectTask");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Title)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);

            entity.Property(x => x.IsCompleted)
                .HasColumnType("BIT")
                .HasDefaultValue(false);

            entity.Property(x => x.DueDate)
                .HasColumnType("DATETIME");

            entity.Property(x => x.CreatedDate)
                .HasColumnType("SMALLDATETIME");

            entity.Property(x => x.ModifiedDate)
                .HasColumnType("SMALLDATETIME");

            entity.Property(x => x.IsDeleted)
                .HasColumnType("BIT")
                .HasDefaultValue(false);

            // 🔗 Foreign key to Project
            entity.HasOne(pt => pt.Project)
                .WithMany(p => p.Tasks)
                .HasForeignKey(pt => pt.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

       

        }
    }
}
