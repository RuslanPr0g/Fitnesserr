using Core.EF;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBApi.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly TrainingContext _context;

        public UserRepo(TrainingContext context)
        {
            this._context = context;
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users
                .Include(t => t.TrainingDones)
                .Include(t => t.TrainingPrograms)
                .ToListAsync();
        }

        public async Task RegisterUserAsync(User user)
        {
            if (user is null)
                throw new ArgumentNullException(nameof(user));

            await _context.Users.AddAsync(user);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public async Task UpdateUser(User user)
        {
            // nothing
        }
    }
}
