using Core.EF;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBApi.Repository
{
    public class TrainingRepo : ITrainingRepo
    {
        private readonly TrainingContext _context;

        public TrainingRepo(TrainingContext context)
        {
            this._context = context;
        }

        public async Task AddTrainingAsync(Training training)
        {
            if (training is null)
                throw new ArgumentNullException(nameof(training));

            await _context.Trainings.AddAsync(training);
        }

        public void DeleteTraining(Training training)
        {
            if (training is null)
                throw new ArgumentNullException(nameof(training));

            _context.Trainings.Remove(training);
        }

        public async Task<Training> GetTrainingAsync(Guid id)
        {
            return await _context.Trainings.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Training>> GetTrainingsAsync()
        {
            return await _context.Trainings.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public async Task UpdateTraining(Training training)
        {
            // nothing
        }
    }
}
