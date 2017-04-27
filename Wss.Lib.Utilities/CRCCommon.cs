using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wss.Lib.Utilities
{
    public static class CRCCommon
    {
        public static long getCRC64(string s)
        {
            UnicodeEncoding _unicode = new UnicodeEncoding();
            ulong crc = 0;
            byte[] pl = _unicode.GetBytes(s.Trim().ToLower());
            CRC64.Calc_crc(ref crc, pl, (uint)pl.Length);

            byte[] x = BitConverter.GetBytes(crc);

            return BitConverter.ToInt64(x, 0); //Convert.ToInt64(crc & 0x0008000000000000);
        }
        public static int getCRC32(string s)
        {
            Encoding unicode = Encoding.Unicode;
            return CRC32.Compute(unicode.GetBytes(s.Trim().ToLower()));
        }
    }
}
