using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBApi.DTOs
{
    public class ExerciseCreateDto
    {
        public Guid TrainingId { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TimeToComplete { get; set; }
        public int Times { get; set; }
        public string ImageURL { get; set; }
    }
}
