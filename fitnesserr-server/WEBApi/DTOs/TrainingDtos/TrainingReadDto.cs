using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBApi.DTOs
{
    public class TrainingReadDto
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int TimeToComplete { get; set; }
        public bool IsPublic { get; set; } = true;
        public int Likes { get; set; } = 0;
        public DateTime DatePublished { get; set; }

        public List<Exercise> Exercises { get; set; }
    }
}
