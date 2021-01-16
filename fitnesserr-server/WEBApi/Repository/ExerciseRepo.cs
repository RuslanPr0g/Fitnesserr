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

        public Exercise GetExercise(Guid id)
        {
            return _context.Exercises.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Exercise> GetExercises()
        {
            return _context.Exercises.ToList();
        }
    }
}
