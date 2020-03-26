using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionLayer.Interfaces
{
    public interface IUserEncryptionService
    {
     Task<User> EncryptUser(User user,string Key);
     Task<User> DecryptUser(User user,string Key);

      Task<bool> Login(string Email,string Password,string Key);
     string GenerateSecretKey();
    }
}
