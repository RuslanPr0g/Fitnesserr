using Microsoft.EntityFrameworkCore;
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

        public async Task AddTrainingAsync(TrainingProgram training)
        {
            if (training is null)
                throw new ArgumentNullException(nameof(training));

            await _context.TrainingPrograms.AddAsync(training);
        }

        public void DeleteTrainingProgram(TrainingProgram training)
        {
            if (training is null)
                throw new NullReferenceException(nameof(training));

            _context.TrainingPrograms.Remove(training);
        }

        public async Task<TrainingProgram> GetTrainingAsync(Guid id)
        {
            return await _context.TrainingPrograms.Where(t => t.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TrainingProgram>> GetTrainingsAsync()
        {
            return await _context.TrainingPrograms.ToListAsync();
        }

        public async Task<IEnumerable<TrainingProgram>> GetTrainingsAsync(Guid ownerId)
        {
            return await _context.TrainingPrograms.Where(t => t.UserId == ownerId).ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public async Task UpdateTrainingProgram(TrainingProgram training)
        {
            //nothing
        }
    }
}
