using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Exercise
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid TrainingId { get; set; }
        [Required]
        public int Order { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string Description { get; set; }
        [Required]
        public int TimeToComplete { get; set; }
        public int ScoreToIncrease { get; set; } = 5;
        public int Times { get; set; }
        public string ImageURL { get; set; }
    }
}
