using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Domain.Entities
{
    public class ProjectTask:AuditDeleteableEntity
    {
  
        [Required, MaxLength(100)]
        public string Title { get; set; }

        public bool? IsCompleted { get; set; }

        public DateTime? DueDate { get; set; }

        public long? ProjectId { get; set; }
        public Project? Project { get; set; }
    }
}
