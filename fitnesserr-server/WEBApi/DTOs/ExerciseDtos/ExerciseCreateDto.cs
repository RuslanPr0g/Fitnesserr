using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEBApi.DTOs
{
    public class ExerciseCreateDto
    {
        [Required]
        public Guid TrainingId { get; set; }
        [Required]
        public int Order { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int TimeToComplete { get; set; }
        [Required]
        public int Times { get; set; }
        public string ImageURL { get; set; }
    }
}
