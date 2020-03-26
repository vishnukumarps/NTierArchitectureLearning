using System;
using System.Collections.Generic;
using System.Text;
using EncryptionLayer.Functions;
using EncryptionLayer.Interfaces;
using System.Threading.Tasks;
using Entities;

namespace BLL
{
    public class UserLogic
    {
        IEncryptUserFunction crypto;
        HelperUtils utils;
        public UserLogic()
        {
            crypto = new EncryptUserFunction();
            utils = new HelperUtils();
        }
      
        public async Task<bool> AddAsync(User newUser)
        {

            try
            {
                var SecretKey = crypto.GenerateSecretKey();

                var Result = await crypto.EncryptUser(newUser, SecretKey);
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


        public async Task<User> GetUserAsync(User user,string Key)
        {
            
            var Result= await crypto.DecryptUser(user, Key);
            return Result;
        }


        public async Task<bool>Login(string Email,string Password,string Key)
        {
            var result = await crypto.Login(Email,Password,Key);
            return result;
        }
    }
}
