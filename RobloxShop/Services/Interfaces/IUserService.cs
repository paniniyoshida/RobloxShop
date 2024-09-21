
using RobloxShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobloxShop.Services.Interfaces
{
    public interface IUserService : IBaseService<User>
    {
        User? GetByLoginAndPassword(string username, string password);
    }
}
