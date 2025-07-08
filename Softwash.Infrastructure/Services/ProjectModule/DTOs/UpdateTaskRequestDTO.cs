using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Infrastructure.Services.ProjectModule.DTOs
{
    public class UpdateTaskRequestDTO
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public long ProjectId { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; } = null!;

        public DateTime DueDate { get; set; }

        public bool IsCompleted { get; set; }
    }

}
