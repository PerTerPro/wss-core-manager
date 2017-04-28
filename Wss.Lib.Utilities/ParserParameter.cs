using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wss.Lib.Utilities
{
    public class ParserParameter
    {
        public static Dictionary<string, List<string>> Parse(string data, char splitCharactor='-')
        {
            Dictionary<string, List<string>> paraResult = new Dictionary<string, List<string>>();
            string[] x = data.Split(new char[] {splitCharactor}, StringSplitOptions.None);
            foreach (var variable in x)
            {
                string[] y = variable.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                if (y.Count() >= 2)
                {
                    List<string> lst = new List<string>();
                    for (int i = 1; i < y.Length; i++)
                    {
                        lst.Add(y[i]);
                    }
                    paraResult.Add(y[0], lst);
                }
            }
            return paraResult;
        }
    }
}
