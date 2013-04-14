using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace CG.Services.impl
{
    public interface IEncryptionService
    {
        string GenerateAPassKey(string passphrase);
        string Encrypt(string plainStr, string KeyString);
        string Decrypt(string encryptedText, string KeyString);
    }
}
