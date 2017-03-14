using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wss.Lib.Utilities
{
    public interface IWssConverter
    {
        long ConvertStringToPrice(string strInput);
    }
}
