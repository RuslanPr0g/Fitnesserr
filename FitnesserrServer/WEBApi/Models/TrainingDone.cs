using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace WEBApi.Models
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
        public DateTime DateDone { get; set; }
        [Required]
        public int TimeDone { get; set; }
    }
}
