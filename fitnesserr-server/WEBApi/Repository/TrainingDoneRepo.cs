﻿using System;
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

        public IEnumerable<TrainingDone> GetTrainingDone()
        {
            return _context.TrainingDone.ToList();
        }

        public IEnumerable<TrainingDone> GetTrainingDone(Guid id)
        {
            return _context.TrainingDone.Where(t => t.Id == id).ToList();
        }
    }
}