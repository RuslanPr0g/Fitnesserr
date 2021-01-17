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

        public void AddExercise(Exercise exercise)
        {
            if (exercise is null)
                throw new ArgumentNullException(nameof(exercise));

            _context.Exercises.Add(exercise);
        }

        public Exercise GetExercise(Guid id)
        {
            return _context.Exercises.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Exercise> GetExercises()
        {
            return _context.Exercises.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
