using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    interface IUserRepository
    {
        bool AddUser(User user);
        User GetUser(int id);
        List<User> GetUsers();
        void UpdateUser(int id);
        void DeleteUser(int id);
    }
}
