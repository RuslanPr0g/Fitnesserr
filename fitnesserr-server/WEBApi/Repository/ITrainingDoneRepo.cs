using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBApi.Models;

namespace WEBApi.Repository
{
    public interface ITrainingDoneRepo
    {
        Task<bool> SaveChangesAsync();

        Task<IEnumerable<TrainingDone>> GetTrainingDoneAsync();
        Task<IEnumerable<TrainingDone>> GetTrainingDoneAsync(Guid id);
        Task FinishTrainingAsync(TrainingDone training);
    }
}
