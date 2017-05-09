using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wss.Lib.Utilities
{
    public static class Common
    {
        private const string KoDauChars =
               "aaaaaaaaaaaaaaaaaeeeeeeeeeeediiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAAEEEEEEEEEEEDIIIOOOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYYAADOOU";

        private const string uniChars =
            "àáảãạâầấẩẫậăằắẳẵặèéẻẽẹêềếểễệđìíỉĩịòóỏõọôồốổỗộơờớởỡợùúủũụưừứửữựỳýỷỹỵÀÁẢÃẠÂẦẤẨẪẬĂẰẮẲẴẶÈÉẺẼẸÊỀẾỂỄỆĐÌÍỈĨỊÒÓỎÕỌÔỒỐỔỖỘƠỜỚỞỠỢÙÚỦŨỤƯỪỨỬỮỰỲÝỶỸỴÂĂĐÔƠƯ";
        public static string UnicodeToKoDauFulltext(string s)
        {
            string retVal = String.Empty;
            s = s.Trim();
            int pos;
            for (int i = 0; i < s.Length; i++)
            {
                pos = uniChars.IndexOf(s[i].ToString());
                if (pos >= 0)
                    retVal += KoDauChars[pos];
                else
                    retVal += s[i];
            }
            return FormatKeyword(retVal);
        }
        private static string FormatKeyword(string s)
        {
            string r = s;
            string[] blackword = new string[] {
                                "`", "~", "!", "@", "#", "$", "%", "^", "&","*", "(", ")","-","_","+","=",
                                 "{", "}", "[", "]", "|", @"\",
                                ":", ";", "'", "\"",
                                "<", ">", ",", ".", "?", "/"
                            };
            int num;
            for (num = 0; num < blackword.Length; num++)
            {
                r = r.Replace(blackword[num], " ");
            }
            r = r.Trim().Replace("  ", " ");
            r = r.Replace('+', ' ');
            return r;
        }
    }
}
