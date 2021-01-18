using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBApi.Models;

namespace WEBApi.Repository
{
    public interface IExerciseRepo
    {
        Task<bool> SaveChangesAsync();

        Task<IEnumerable<Exercise>> GetExercisesAsync();
        Task<Exercise> GetExerciseAsync(Guid id);
        Task AddExerciseAsync(Exercise exercise);
        Task UpdateExercise(Exercise exercise);
        void DeleteExercise(Exercise exercise);
    }
}
