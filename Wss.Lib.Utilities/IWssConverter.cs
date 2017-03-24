using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wss.Lib.Utilities
{
    public interface IWssConverter
    {
        long ConvertStringToPrice(string strInput);
        long ConvertStringToPrice(string strInput, CultureInfo cultureInfo);
    }
}
