using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBApi.Models;

namespace WEBApi.Repository
{
    public interface ITrainingProgramRepo
    {
        IEnumerable<TrainingProgram> GetTrainings();
        IEnumerable<TrainingProgram> GetTrainings(Guid ownerId);
    }
}
