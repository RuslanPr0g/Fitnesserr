using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class TrainingProgram
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid TrainingId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public bool IsPublic { get; set; } = false;
    }
}
