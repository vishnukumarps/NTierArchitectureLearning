using EncryptionLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Functions;
using Entities;
using SecuredLoginSystem;
using DAL.InterFaces;

namespace EncryptionLayer.Functions
{
    public class EncryptUserFunction : IEncryptUserFunction
    {

        IRegistrationFunction registration;
        EncryptionUtils crypto;
        public EncryptUserFunction()
        {
            registration = new RegistrationFunction();
            crypto = new EncryptionUtils();
        }

        public async Task<Registration> DecryptUser(Registration user, string key)
        {
           
            user.Name = crypto.DecryptString(key, user.Name);
            user.Address = crypto.DecryptString(key, user.Address);
            user.Email = crypto.DecryptString(key, user.Email);
            user.Password = crypto.DecryptString(key, user.Password);
            user.PhoneNumber = crypto.DecryptString(key, user.PhoneNumber);
            await Task.FromResult(0);
            return user;
        }

        public async Task<Registration> EncryptUser(Registration user, string Key)
        {
            
            user.Name = crypto.EncryptString(Key, user.Name);
            user.Address = crypto.EncryptString(Key, user.Address);
            user.Email = crypto.EncryptString(Key, user.Email);
            user.Password = crypto.EncryptString(Key, user.Password);
            user.PhoneNumber = crypto.EncryptString(Key, user.PhoneNumber);
            user.Key = Key;
            var Result = await registration.AddUser(user);
            return Result;
        }

        public string GenerateSecretKey()
        {
            var Key = crypto.GenerateKey();
            return Key;
        }


      
        public async Task<bool> Login(string Email, string Password, string Key)
        {
            var email = crypto.EncryptString(Key,Email);
            var password = crypto.EncryptString(Key, Password);

            var allUser = await registration.GetAllUser();
            var user=allUser.Find(x=>x.Email==email && x.Password==password);
            if(user!=null)
            {
                return true;
            }
            return false;
        }
    }
}
