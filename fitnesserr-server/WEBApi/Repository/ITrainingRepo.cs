using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBApi.Models;

namespace WEBApi.Repository
{
    public interface ITrainingRepo
    {
        Task<bool> SaveChangesAsync();

        Task<IEnumerable<Training>> GetTrainingsAsync();
        Task<Training> GetTrainingAsync(Guid id);
        Task AddTrainingAsync(Training training);
        Task UpdateTraining(Training training);
        void DeleteTraining(Training training);
    }
}
