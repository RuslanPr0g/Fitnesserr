using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using WEBApi.DTOs;
using System.Threading;

namespace WEBApi.Repository
{
    public interface IUserRepo
    {
        Task<bool> SaveChangesAsync();

        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserAsync(Guid id);
        Task<string> LoginUserAsync(Guid id, UserLoginDto user);
        Task<string> RegisterUserAsync(User user);
        Task UpdateUser(User user);
        Task<User> FindUserByEmailAsync(string email, CancellationToken cancellation);
    }
}
