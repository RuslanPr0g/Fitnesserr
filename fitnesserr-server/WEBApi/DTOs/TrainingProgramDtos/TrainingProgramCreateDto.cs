using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEBApi.DTOs
{
    public class TrainingProgramCreateDto
    {
        [Required]
        public Guid TrainingId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public DateTime DateAdded { get; set; } = DateTime.Now;
        [Required]
        public bool IsPublic { get; set; } = false;
    }
}
