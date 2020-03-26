using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.InterFaces
{
    public  interface IUserFunction
    {
        public Task<User> AddUser(User user);
        public Task<List<User>> GetAllUser();
    }
}
