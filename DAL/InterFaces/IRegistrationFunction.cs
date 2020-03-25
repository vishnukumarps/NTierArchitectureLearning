using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.InterFaces
{
    public  interface IRegistrationFunction
    {
        public Task<Registration> AddUser(Registration user);
        public Task<List<Registration>> GetAllUser();
    }
}
