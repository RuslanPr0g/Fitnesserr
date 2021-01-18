using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEBApi.DTOs
{
    public class TrainingDoneCreateDto
    {
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
