using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEBApi.DTOs
{
    public class TrainingCreateDto
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public bool IsPublic { get; set; } = true;
        [Required]
        public DateTime DatePublished { get; set; } = DateTime.Now;
    }
}
