using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Wss.Lib.Utilities
{
    public class WssConverter : IWssConverter
    {
        public long ConvertStringToPrice(string strInput, CultureInfo cultureInfo)
        {
            long price = 0;
            if (!string.IsNullOrEmpty(strInput.Trim().ToLower()))
            {
                strInput = Regex.Replace(strInput.ToLower().Trim(), @"\s*vnd|\s*vnđ|\s*đ", "");
                price = long.Parse(strInput,cultureInfo);
            }
            return price;
        }

        public long ConvertStringToPrice(string strInput)
        {
            long price = 0;
            if (!string.IsNullOrEmpty(strInput.Trim().ToLower()))
            {
                strInput = Regex.Replace(strInput.ToLower().Trim(), @"\s*vnd|\s*vnđ|\s*đ", "");
                price = long.Parse(strInput);
            }
            return price;
        }
    }
}  
