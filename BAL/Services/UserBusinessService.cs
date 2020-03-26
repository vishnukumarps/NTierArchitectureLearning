using BLL.Interfaces;
using EncryptionLayer.Interfaces;
using EncryptionLayer.Services;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserBusinessService : IUserBusinessService
    {
        private readonly IUserEncryptionService _userEncryptionService;

        public UserBusinessService(IUserEncryptionService _userEncryptionService)
        { 
            this._userEncryptionService = _userEncryptionService;
        }
        public async Task <User>Add(User newUser)
        {
            var SecretKey =_userEncryptionService.GenerateSecretKey();
            var user = await _userEncryptionService.EncryptUser(newUser, SecretKey);

            return user;
        }


        public async Task<bool> Login(string Email, string Password, string Key)
        {
            var result = await _userEncryptionService.Login(Email,Password,Key);
            return true;
        }
    }
}
