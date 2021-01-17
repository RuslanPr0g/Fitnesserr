using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WEBApi.DTOs;
using WEBApi.Models;

namespace WEBApi.Repository
{
    public interface IUserRepo
    {
        Task<bool> SaveChangesAsync();

        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserAsync(Guid id);
        Task RegisterUserAsync(User user);
    }
}
