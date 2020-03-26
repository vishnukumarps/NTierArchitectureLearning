using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserBusinessService
    {
        Task<User> Add(User model);
        Task<bool> Login(string Email, string Password, string Key);
    }
}
