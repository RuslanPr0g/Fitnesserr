using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBApi.DTOs
{
    public class TrainingProgramReadDto
    {
        public Guid TrainingId { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsPublic { get; set; } = false;
    }
}
