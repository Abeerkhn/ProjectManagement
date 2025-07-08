using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Infrastructure.Services.ProjectModule.DTOs
{
    public class ProjectFilterDTO : PaginationDTO
    {
        public long? Id { get; set; }
        public string? Name { get; set; }
        public long? CreatedById { get; set; }
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
