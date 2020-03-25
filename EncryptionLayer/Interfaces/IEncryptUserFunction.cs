using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionLayer.Interfaces
{
    public interface IEncryptUserFunction
    {
     Task<Registration> EncryptUser(Registration user,string Key);
     Task<Registration> DecryptUser(Registration user,string Key);
     string GenerateSecretKey();
    }
}
