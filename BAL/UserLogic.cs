using System;
using System.Collections.Generic;
using System.Text;
using EncryptionLayer.Functions;
using EncryptionLayer.Interfaces;
using System.Threading.Tasks;
using Entities;

namespace BAL
{
    public class UserLogic
    {
        IEncryptUserFunction encrypt;
        public UserLogic()
        {
            encrypt = new EncryptUserFunction();
        }
      
        public async Task<bool> AddAsync(Registration newUser)
        {

            var SecretKey = encrypt.GenerateSecretKey();

           var Result= await encrypt.EncryptUser(newUser,SecretKey);
            if(Result!=null)
            {
                return true;
            }
            return false;
        }


    }
}
