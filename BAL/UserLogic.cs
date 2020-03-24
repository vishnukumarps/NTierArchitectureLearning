using System;
using System.Collections.Generic;
using System.Text;
using DAL.InterFaces;
using DAL.Functions;
using System.Threading.Tasks;
using Entities;

namespace BAL
{
    public class UserLogic
    {
        IRegistrationFunction user;
        public UserLogic()
        {
           user = new RegistrationFunction();
        }
      
        public async Task<bool> AddAsync(Registration newUser)
        {

           var Result=await user.AddUser(newUser);
            if(Result!=null)
            {
                return true;
            }
            return false;
        }


    }
}
