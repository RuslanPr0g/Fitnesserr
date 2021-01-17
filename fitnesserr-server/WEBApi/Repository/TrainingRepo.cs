using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBApi.Context;
using WEBApi.Models;

namespace WEBApi.Repository
{
    public class TrainingRepo : ITrainingRepo
    {
        private readonly TrainingContext _context;

        public TrainingRepo(TrainingContext context)
        {
            this._context = context;
        }

        public void AddTraining(Training training)
        {
            if (training is null)
                throw new ArgumentNullException(nameof(training));

            _context.Trainings.Add(training);
        }

        public Training GetTraining(Guid id)
        {
            return _context.Trainings.FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Training> GetTrainings()
        {
            return _context.Trainings.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
