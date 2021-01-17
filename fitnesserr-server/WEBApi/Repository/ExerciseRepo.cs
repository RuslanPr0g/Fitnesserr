using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBApi.Context;
using WEBApi.Models;

namespace WEBApi.Repository
{
    public class ExerciseRepo : IExerciseRepo
    {
        private readonly TrainingContext _context;

        public ExerciseRepo(TrainingContext context)
        {
            this._context = context;
        }

        public async Task AddExerciseAsync(Exercise exercise)
        {
            if (exercise is null)
                throw new ArgumentNullException(nameof(exercise));

            await _context.Exercises.AddAsync(exercise);
        }

        public async Task<Exercise> GetExerciseAsync(Guid id)
        {
            return await _context.Exercises.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<Exercise>> GetExercisesAsync()
        {
            return await _context.Exercises.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
