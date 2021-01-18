using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEBApi.DTOs
{
    public class TrainingUpdateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int TimeToComplete { get; set; }
        [Required]
        public bool IsPublic { get; set; } = true;
        [Required]
        public int Likes { get; set; } = 0;
    }
}
