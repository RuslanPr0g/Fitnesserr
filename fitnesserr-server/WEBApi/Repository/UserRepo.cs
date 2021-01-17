using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBApi.Context;
using WEBApi.Models;

namespace WEBApi.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly TrainingContext _context;

        public UserRepo(TrainingContext context)
        {
            this._context = context;
        }

        public User GetUser(Guid id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users
                .Include(t => t.TrainingDones)
                .Include(t => t.TrainingPrograms)
                .ToList();
        }

        public void RegisterUser(User user)
        {
            if (user is null)
                throw new ArgumentNullException(nameof(user));

            _context.Users.Add(user);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
