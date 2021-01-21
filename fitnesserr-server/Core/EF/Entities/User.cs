using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string UserName { get; set; }
        [Required]
        [Column(TypeName = "varchar(500)")]
        public string Password { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "varchar(400)")]
        public string Email { get; set; }
        public int Score { get; set; }
        public DateTime DateOfBirth { get; set; }
        
        public List<TrainingProgram> TrainingPrograms { get; set; }
        public List<TrainingDone> TrainingDones { get; set; }
    }
}
