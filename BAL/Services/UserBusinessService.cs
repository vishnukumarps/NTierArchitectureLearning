using BLL.Interfaces;
using EncryptionLayer.Interfaces;
using EncryptionLayer.Services;
using Model;
using SecuredVault.Business.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserBusinessService : IUserBusinessService
    {
        private readonly IUserEncryptionService _userEncryptionService;
        private readonly IMessageService _messageService;
        public UserBusinessService(IUserEncryptionService _userEncryptionService,
            IMessageService _messageService)
        { 
            this._userEncryptionService = _userEncryptionService;
            this._messageService = _messageService;
        }
        public async Task <User>Add(User newUser)
        {
            var toPhoneNumber = newUser.PhoneNumber;
            var SecretKey =_userEncryptionService.GenerateSecretKey();
            var user = await _userEncryptionService.EncryptUser(newUser, SecretKey);

           if(toPhoneNumber!=null && user!=null)
            {
                var status=await _messageService.SendSms(toPhoneNumber,"Your SecretKey is "+SecretKey);
            }
            return user;
        }


        public async Task<bool> Login(string Email, string Password, string Key)
        {
            var result = await _userEncryptionService.Login(Email,Password,Key);
            return true;
        }
    }
}
