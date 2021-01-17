using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBApi.Context;
using WEBApi.Models;

namespace WEBApi.Repository
{
    public class TrainingDoneRepo : ITrainingDoneRepo
    {
        private readonly TrainingContext _context;

        public TrainingDoneRepo(TrainingContext context)
        {
            this._context = context;
        }

        public async Task FinishTrainingAsync(TrainingDone training)
        {
            if (training is null)
                throw new ArgumentNullException(nameof(training));

            await _context.TrainingDone.AddAsync(training);
        }

        public async Task<IEnumerable<TrainingDone>> GetTrainingDoneAsync()
        {
            return await _context.TrainingDone.ToListAsync();
        }

        public async Task<IEnumerable<TrainingDone>> GetTrainingDoneAsync(Guid id)
        {
            return await _context.TrainingDone.Where(t => t.Id == id).ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
