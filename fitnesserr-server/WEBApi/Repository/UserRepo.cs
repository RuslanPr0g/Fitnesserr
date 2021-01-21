using Core.EF;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WEBApi.DTOs;

namespace WEBApi.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly TrainingContext _context;

        public UserRepo(TrainingContext context)
        {
            this._context = context;
        }

        public async Task<User> FindUserByEmailAsync(string email, CancellationToken cancellation)
        {
            return await _context.Users.Where(u => u.Email == email).FirstOrDefaultAsync(cancellationToken: cancellation);
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

        public async Task<User> LoginUserAsync(Guid id, UserLoginDto user)
        {
            var userFromContext = await _context.Users
                .Include(t => t.TrainingDones)
                .Include(t => t.TrainingPrograms)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (userFromContext is not null && BCrypt.Net.BCrypt.Verify(user.Password, userFromContext.Password))
            {
                return userFromContext;
            }
            else
            {
                return null;
            }
        }

        public async Task RegisterUserAsync(User user)
        {
            if (user is null)
                throw new ArgumentNullException(nameof(user));

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

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
