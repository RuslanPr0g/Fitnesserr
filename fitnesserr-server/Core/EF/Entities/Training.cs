using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Training
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string Description { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Type { get; set; }
        public bool IsPublic { get; set; } = true;
        public int Likes { get; set; } = 0;
        public DateTime DatePublished { get; set; } = DateTime.Now;

        [Required]
        public List<Exercise> Exercises { get; set; }
    }
}
