using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Infrastructure.Services.ProjectModule.DTOs
{
    public class ProjectResponseDTO 
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long CreatedById { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
   
}
