using ProjectManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Infrastructure.Persistance.EntityConfigurations
{
    public class ProjectEntityConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> entity)
        {
                entity.ToTable("Project");

                entity.HasKey(x => x.Id);

                entity.Property(x => x.Name)
                    .IsRequired()
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(100);

                entity.Property(x => x.Description)
                    .HasColumnType("NVARCHAR(MAX)");

                entity.Property(x => x.StartDate)
                    .HasColumnType("DATETIME");

                entity.Property(x => x.EndDate)
                    .HasColumnType("DATETIME");

                entity.Property(x => x.CreatedDate)
                    .HasColumnType("SMALLDATETIME");

                entity.Property(x => x.ModifiedDate)
                    .HasColumnType("SMALLDATETIME");

                entity.Property(x => x.IsDeleted)
                    .HasColumnType("BIT")
                    .HasDefaultValue(false);

                entity.HasOne(p => p.CreatedBy)
                    .WithMany(p=>p.Projects) 
                    .HasForeignKey(p => p.CreatedById)
                    .OnDelete(DeleteBehavior.Cascade); 
         

           
        }
    }
    }



