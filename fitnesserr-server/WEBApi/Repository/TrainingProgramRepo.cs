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

        public void AddTraining(TrainingProgram training)
        {
            if (training is null)
                throw new ArgumentNullException(nameof(training));

            _context.TrainingPrograms.Add(training);
        }

        public IEnumerable<TrainingProgram> GetTrainings()
        {
            return _context.TrainingPrograms.ToList();
        }

        public IEnumerable<TrainingProgram> GetTrainings(Guid ownerId)
        {
            return _context.TrainingPrograms.Where(t => t.UserId == ownerId).ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
