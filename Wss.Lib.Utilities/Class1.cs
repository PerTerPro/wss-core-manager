using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Wss.Lib.Utilities
{
    public static class UtilIdProduct
    {
        public static long GenId(string url, string regex)
        {
            string urlGen = HttpUtility.UrlDecode(HttpUtility.UrlDecode(url));
            if (!string.IsNullOrEmpty(regex))
            {
                var originUrl = new Regex(regex);
                if (originUrl.IsMatch(urlGen))
                    urlGen = originUrl.Match(urlGen).Value;
            }
            return CRCCommon.getCRC64(urlGen.Trim().ToLower());
        }

    }
}
