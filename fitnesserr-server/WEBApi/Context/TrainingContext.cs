using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBApi.Models;

namespace WEBApi.Context
{
    public class TrainingContext : DbContext
    {
        public TrainingContext(DbContextOptions<TrainingContext> options) : base(options)
        {

        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<TrainingDone> TrainingDone { get; set; }
        public DbSet<TrainingProgram> TrainingPrograms { get; set; }
    }
}
