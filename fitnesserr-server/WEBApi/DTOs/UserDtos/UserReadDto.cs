using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBApi.Models;

namespace WEBApi.DTOs
{
    public class UserReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Score { get; set; }
        public DateTime DateOfBirth { get; set; }

        public List<TrainingProgram> TrainingPrograms { get; set; }
        public List<TrainingDone> TrainingDones { get; set; }
    }
}
