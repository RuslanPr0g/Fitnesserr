using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBApi.Models;

namespace WEBApi.Repository
{
    public interface ITrainingRepo
    {
        bool SaveChanges();

        IEnumerable<Training> GetTrainings();
        Training GetTraining(Guid id);
        void AddTraining(Training training);
    }
}
