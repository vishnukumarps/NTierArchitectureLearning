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
        EncryptionUtils obj;
        public EncryptUserFunction()
        {
            registration = new RegistrationFunction();
            obj = new EncryptionUtils();
        }

        public async Task<Registration> DecryptUser(Registration user, string key)
        {
           
            user.Name = obj.DecryptString(key, user.Name);
            user.Address = obj.DecryptString(key, user.Address);
            user.Email = obj.DecryptString(key, user.Email);
            user.Password = obj.DecryptString(key, user.Password);
            user.PhoneNumber = obj.DecryptString(key, user.PhoneNumber);
            await Task.FromResult(0);
            return user;
        }

        public async Task<Registration> EncryptUser(Registration user, string Key)
        {
            
            user.Name = obj.EncryptString(Key, user.Name);
            user.Address = obj.EncryptString(Key, user.Address);
            user.Email = obj.EncryptString(Key, user.Email);
            user.Password = obj.EncryptString(Key, user.Password);
            user.PhoneNumber = obj.EncryptString(Key, user.PhoneNumber);
            user.Key = Key;
            var Result = await registration.AddUser(user);
            return Result;
        }

        public string GenerateSecretKey()
        {
            var Key = obj.GenerateKey();
            return Key;
        }
    }
}
