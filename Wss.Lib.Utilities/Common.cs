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
        public static string FormatKeyword(string s)
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
        public static IEnumerable<string> makeNgrams(string text, int nGramSize)
        {
            if (nGramSize == 0) throw new Exception("nGram size was not set");

            StringBuilder nGram = new StringBuilder();
            Queue<int> wordLengths = new Queue<int>();

            int wordCount = 0;
            int lastWordLen = 0;

            //append the first character, if valid.
            //avoids if statement for each for loop to check i==0 for before and after vars.
            if (text != "" && char.IsLetterOrDigit(text[0]))
            {
                nGram.Append(text[0]);
                lastWordLen++;
            }

            //generate ngrams
            for (int i = 1; i <= text.Length - 1; i++)
            {
                char before = text[i - 1];
                char after = ' ';
                if (i + 1 < text.Length)
                {
                    after = text[i + 1];
                }
                if (char.IsLetterOrDigit(text[i])
                        ||
                        //keep all punctuation that is surrounded by letters or numbers on both sides.
                        (text[i] != ' '
                        && (char.IsSeparator(text[i]) || char.IsPunctuation(text[i]))
                        && (char.IsLetterOrDigit(before) && char.IsLetterOrDigit(after))
                        )
                    )
                {
                    nGram.Append(text[i]);
                    lastWordLen++;
                }
                else
                {
                    if (lastWordLen > 0)
                    {
                        wordLengths.Enqueue(lastWordLen);
                        lastWordLen = 0;
                        wordCount++;

                        if (wordCount >= nGramSize)
                        {
                            yield return nGram.ToString();
                            var dqLength = (int)wordLengths.Dequeue() + 1;
                            if (dqLength <= nGram.Length)
                            {
                                nGram.Remove(0, dqLength);
                            }
                            else nGram.Remove(0, dqLength - 1);
                            wordCount -= 1;
                        }
                        if (nGramSize > 1)
                        {
                            nGram.Append(" ");
                        }

                    }
                }
            }

            yield return nGram.ToString();
        }
    }
}
