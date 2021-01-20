using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class TrainingProgram
    {
        [Key]
        [Column(Order = 2)]
        [Required]
        public Guid Id { get; set; }
        [Column(Order = 2)]
        [Required]
        public Guid TrainingId { get; set; }
        [Column(Order = 3)]
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public bool IsPublic { get; set; } = false;
    }
}
