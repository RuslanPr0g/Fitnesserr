using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLibrary.Encryption
{
    public interface IEncrypter
    {
        Task<string> Encrypt(string ToBeEncrypt);
    }
}
