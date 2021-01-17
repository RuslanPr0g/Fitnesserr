using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBApi.Models;

namespace WEBApi.Repository
{
    public interface IExerciseRepo
    {
        bool SaveChanges();

        IEnumerable<Exercise> GetExercises();
        Exercise GetExercise(Guid id);
        void AddExercise(Exercise exercise);
    }
}
