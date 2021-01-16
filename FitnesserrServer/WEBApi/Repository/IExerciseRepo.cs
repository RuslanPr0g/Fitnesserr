using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBApi.Models;

namespace WEBApi.Repository
{
    public interface IExerciseRepo
    {
        IEnumerable<Exercise> GetExercises();
        Exercise GetExercise(Guid id);
    }
}
