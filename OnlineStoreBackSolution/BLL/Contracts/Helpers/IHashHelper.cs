using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserBLL.Contracts.Helpers
{
    public interface IHashHelper
    {
        string Hash(string password);
        bool CompareHashCodes(string hash1, string hash2);
        string ByteArrayToString(byte[] arrInput);
    }
}
