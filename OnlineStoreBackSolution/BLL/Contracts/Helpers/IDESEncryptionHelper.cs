using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserBLL.Contracts.Helpers
{
    public interface IDESEncryptionHelper
    {
        string EncryptStringDES(string strData, string strKey);
        string DecryptStringDES(string strData, string strKey);
        byte[] GenerateKeyDES();
    }
}
