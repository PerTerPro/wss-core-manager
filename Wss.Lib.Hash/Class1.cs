using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using GABIZ.Base.Cryptography;

namespace Wss.Lib.Hash
{
    public class CommonCrc
    {
        public static long Crc64(string str)
        {
            UnicodeEncoding _unicode = new UnicodeEncoding();
            ulong crc = 0;
            byte[] pl = _unicode.GetBytes(str);
            CRC64.Calc_crc(ref crc, pl, (uint)pl.Length);
            byte[] x = BitConverter.GetBytes(crc);
            return BitConverter.ToInt64(x, 0); //Convert.ToInt64(crc & 0x0008000000000000);
        }

        public static int Crc32(string str)
        {
            Encoding unicode = Encoding.Unicode;
            return CRC32.Compute(unicode.GetBytes(str));
        }
    }


    
}

