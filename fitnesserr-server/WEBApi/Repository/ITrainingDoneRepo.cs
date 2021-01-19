using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace WEBApi.Repository
{
    public interface ITrainingDoneRepo
    {
        Task<bool> SaveChangesAsync();

        Task<TrainingDone> GetUniqueTrainingDoneAsync(Guid id);
        Task<IEnumerable<TrainingDone>> GetTrainingDoneAsync();
        Task<IEnumerable<TrainingDone>> GetTrainingDoneAsync(Guid id);
        Task FinishTrainingAsync(TrainingDone training);
        Task UpdateTrainingDone(TrainingDone training);
        void DeleteTrainingDone(TrainingDone training);
    }
}
