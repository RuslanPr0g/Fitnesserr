using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBApi.Context;
using WEBApi.Models;

namespace WEBApi.Repository
{
    public class TrainingProgramRepo : ITrainingProgramRepo
    {
        private readonly TrainingContext _context;

        public TrainingProgramRepo(TrainingContext context)
        {
            this._context = context;
        }

        public IEnumerable<TrainingProgram> GetTrainings()
        {
            return _context.TrainingPrograms.ToList();
        }

        public IEnumerable<TrainingProgram> GetTrainings(Guid ownerId)
        {
            return _context.TrainingPrograms.Where(t => t.UserId == ownerId).ToList();
        }
    }
}
