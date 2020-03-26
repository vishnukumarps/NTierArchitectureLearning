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

        IUserFunction User;
        EncryptionUtils crypto;
        public EncryptUserFunction()
        {
            User = new UserFunction();
            crypto = new EncryptionUtils();
        }

        public async Task<User> DecryptUser(User user, string key)
        {
           
            user.Name = crypto.DecryptString(key, user.Name);
            user.Address = crypto.DecryptString(key, user.Address);
            user.Email = crypto.DecryptString(key, user.Email);
            user.Password = crypto.DecryptString(key, user.Password);
            user.PhoneNumber = crypto.DecryptString(key, user.PhoneNumber);
            await Task.FromResult(0);
            return user;
        }

        public async Task<User> EncryptUser(User user, string Key)
        {
            
            user.Name = crypto.EncryptString(Key, user.Name);
            user.Address = crypto.EncryptString(Key, user.Address);
            user.Email = crypto.EncryptString(Key, user.Email);
            user.Password = crypto.EncryptString(Key, user.Password);
            user.PhoneNumber = crypto.EncryptString(Key, user.PhoneNumber);
            user.Key = Key;
            var Result = await User.AddUser(user);
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

            var allUser = await User.GetAllUser();
            var user=allUser.Find(x=>x.Email==email && x.Password==password);
            if(user!=null)
            {
                return true;
            }
            return false;
        }
    }
}
