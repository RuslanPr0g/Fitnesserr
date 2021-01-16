﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBApi.Models
{
    public class User
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string UserName { get; set; }
        [Required]
        [Column(TypeName = "varchar(500)")]
        public string Password { get; set; }
        [Required]
        [Column(TypeName = "varchar(400)")]
        public string Email { get; set; }
        public int Score { get; set; }
        public DateTime DateOfBirth { get; set; }
        
        public List<TrainingProgram> TrainingPrograms { get; set; }
        public List<TrainingDone> TrainingDones { get; set; }
    }
}
