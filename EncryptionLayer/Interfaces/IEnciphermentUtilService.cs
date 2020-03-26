using System;
using System.Collections.Generic;
using System.Text;

namespace EncryptionLayer.Interfaces
{
    public interface IEnciphermentUtilService
    {
        public string EncryptString(string key, string plainText);
        public string DecryptString(string key, string cipherText);
        public string GenerateKey();
    }
}
