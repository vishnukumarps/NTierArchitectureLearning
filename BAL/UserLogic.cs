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
        HelperUtils utils;
        public UserLogic()
        {
            encrypt = new EncryptUserFunction();
            utils = new HelperUtils();
        }
      
        public async Task<bool> AddAsync(Registration newUser)
        {

            try
            {
                var SecretKey = encrypt.GenerateSecretKey();

                var Result = await encrypt.EncryptUser(newUser, SecretKey);
                if (Result != null)
                {
                    utils.SendSms(newUser.PhoneNumber, "Your SecretKey is " + SecretKey);
                    return true;

                }
                return false;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


    }
}
