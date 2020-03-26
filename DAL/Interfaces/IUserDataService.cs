using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public  interface IUserDataService
    {
        public Task<User> AddUser(User user);
        public Task<List<User>> GetAllUser();
    }
}
