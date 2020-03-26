using EncryptionLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Services;
using DAL.Interfaces;
using Model;

namespace EncryptionLayer.Services
{
    public class UserEncryptionService : IUserEncryptionService
    {

        private readonly IUserDataService _userDataService;
        private readonly IEnciphermentUtilService _encryptionUtils;
        public UserEncryptionService(IUserDataService _userDataService,
             IEnciphermentUtilService _encryptionUtils
          )
        {
            this._userDataService = _userDataService;
            this._encryptionUtils = _encryptionUtils;
        }

        public async Task<User> EncryptUser(User user, string Key)
        {
            user.Name = _encryptionUtils.EncryptString(Key, user.Name);
            user.Address = _encryptionUtils.EncryptString(Key, user.Address);
            user.Email = _encryptionUtils.EncryptString(Key, user.Email);
            user.Password = _encryptionUtils.EncryptString(Key, user.Password);
            user.PhoneNumber = _encryptionUtils.EncryptString(Key, user.PhoneNumber);
            user.Key = Key;

            var encryptedUser = await _userDataService.AddUser(user);

            return encryptedUser;
        }


        public async Task<User> DecryptUser(User user, string key)
        {
            await Task.FromResult(0);

            user.Name = _encryptionUtils.DecryptString(key, user.Name);
            user.Address = _encryptionUtils.DecryptString(key, user.Address);
            user.Email = _encryptionUtils.DecryptString(key, user.Email);
            user.Password = _encryptionUtils.DecryptString(key, user.Password);
            user.PhoneNumber = _encryptionUtils.DecryptString(key, user.PhoneNumber);

            var DecryptedUser = user;
            return DecryptedUser;
        }

       

        public string GenerateSecretKey()
        {
            var Key = _encryptionUtils.GenerateKey();
            return Key;
        }


      
        public async Task<bool> Login(string Email, string Password, string Key)
        {
            var email = _encryptionUtils.EncryptString(Key,Email);
            var password = _encryptionUtils.EncryptString(Key, Password);

            var allUser = await _userDataService.GetAllUser();
            var user=allUser.Find(x=>x.Email==email && x.Password==password);
            if(user!=null)
            {
                return true;
            }
            return false;
        }
    }
}
