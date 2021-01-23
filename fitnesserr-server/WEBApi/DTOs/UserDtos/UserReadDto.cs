using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBApi.DTOs
{
    public class UserReadDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int Score { get; set; }
        public DateTime DateOfBirth { get; set; }

        public List<TrainingProgram> TrainingPrograms { get; set; }
        public List<TrainingDone> TrainingDones { get; set; }
    }
}
