using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBApi.Models;

namespace WEBApi.Repository
{
    public interface IUserRepo
    {
        IEnumerable<User> GetUsers();
        User GetUser(Guid id);
    }
}
