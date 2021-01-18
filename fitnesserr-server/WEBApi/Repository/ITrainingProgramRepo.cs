using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBApi.Models;

namespace WEBApi.Repository
{
    public interface ITrainingProgramRepo
    {
        Task<bool> SaveChangesAsync();

        Task<TrainingProgram> GetTrainingAsync(Guid id);
        Task<IEnumerable<TrainingProgram>> GetTrainingsAsync();
        Task<IEnumerable<TrainingProgram>> GetTrainingsAsync(Guid ownerId);
        Task AddTrainingAsync(TrainingProgram training);
        Task UpdateTrainingProgram(TrainingProgram training);
        void DeleteTrainingProgram(TrainingProgram training);
    }
}
