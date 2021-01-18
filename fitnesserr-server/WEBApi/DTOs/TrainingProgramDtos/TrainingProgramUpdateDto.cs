using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEBApi.DTOs
{
    public class TrainingProgramUpdateDto
    {
        [Required]
        public bool IsPublic { get; set; } = false;
    }
}
