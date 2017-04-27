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

            return Math.Abs(BitConverter.ToInt64(x, 0));
        }
        public static int getCRC32(string s)
        {
            Encoding unicode = Encoding.Unicode;
            return Math.Abs(CRC32.Compute(unicode.GetBytes(s.Trim().ToLower())));
        }
    }
}
