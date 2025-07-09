using Softwash.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Domain.Entities
{
    public class Project:AuditDeleteableEntity
    {
   
        [Required, MaxLength(100)]
        public string Name { get; set; }

        public string? Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public ICollection<ProjectTask>? Tasks { get; set; } = new List<ProjectTask>();
        public bool? IsDeleted { get; set; }
       
        public virtual User? CreatedBy { get; set; }
        public virtual User? ModifiedBy { get; set; }
    }
}
