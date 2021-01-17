using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBApi.Models;

namespace WEBApi.Repository
{
    public interface ITrainingDoneRepo
    {
        bool SaveChanges();

        IEnumerable<TrainingDone> GetTrainingDone();
        IEnumerable<TrainingDone> GetTrainingDone(Guid id);
        void FinishTraining(TrainingDone training);
    }
}
