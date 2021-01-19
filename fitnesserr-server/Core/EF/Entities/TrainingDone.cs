using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace Core.Entities
{
    public class TrainingDone
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Guid TrainingId { get; set; }
        [Required]
        public DateTime DateDone { get; set; } = DateTime.Now;
        [Required]
        public int TimeDone { get; set; }
    }
}
