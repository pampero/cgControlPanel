using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace CG.Cryptography.Interface
{
    public interface IEncryptionService
    {
        string EncryptionKey { get; }
        string GenerateAPassKey(string passphrase);
        string Encrypt(string plainStr, string KeyString);
        string Decrypt(string encryptedText, string KeyString);
    }
}
