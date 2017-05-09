using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Wss.Lib.Utilities
{
    public class CommonConvert
    {

        public static String ParseName(string input)
        {
            string r = input.Replace('\t', ' ');
            r = r.TrimEnd(new char[] { '-', ' ', '>' });
            r = r.TrimStart(new char[] { '-', ' ', '>' });
            for (int i = 0; i < r.Length; i++)
            {
                if (r.IndexOf("  ") > 0)
                {
                    r = r.Replace("  ", " ");
                }
                else
                {
                    break;
                }
            }
            return r;
        }

        public static Byte Obj2Byte(object obj)
        {
            if (obj == null)
                return 0;
            try
            {
                return Convert.ToByte(obj.ToString().Replace(",", string.Empty), CultureInfo.InvariantCulture);
            }
            catch
            {
                return 0;
            }
        }
        public static String Obj2String(object obj, string defaultStr = "")
        {
            if (obj == null || obj == DBNull.Value)
                return defaultStr;
            try
            {
                return obj.ToString();
            }
            catch
            {
                return "";
            }
        }
        public static int Obj2Int(object obj, int defaultValue = 0)
        {
            if (obj == null || obj==DBNull.Value)
                return defaultValue;
            try
            {
                return Convert.ToInt32(obj.ToString().Replace(",", string.Empty), CultureInfo.InvariantCulture);
            }
            catch
            {
                return defaultValue;
            }
        }
        public static Boolean Obj2Bool(object obj, bool defaultValue=false)
        {
            if (obj == null)
                return defaultValue;
            try
            {
                return Convert.ToBoolean(obj.ToString());
            }
            catch
            {
                return defaultValue;
            }
        }

        public static double Obj2Double(object value)
        {
            if (value == null || value.ToString().Trim() == "")
                return 0;
            try
            {
                return Convert.ToDouble(value, CultureInfo.InvariantCulture);
            }
            catch
            {
                return 0;
            }
        }

        public static decimal Obj2Decimal(object value)
        {
            if (value == null || value.ToString().Trim() == "")
                return 0;
            try
            {
                return Convert.ToDecimal(value, CultureInfo.InvariantCulture);
            }
            catch
            {
                return 0;
            }
        }

        public static long Obj2Int64(object obj)
        {
            try
            {
                return Convert.ToInt64(obj);
            }
            catch
            {
                return 0;
            }
        }

        public static DateTime ObjectToDataTime(object value)
        {
            DateTime dt = DateTime.MinValue;
            try
            {
                dt = Convert.ToDateTime(value);
            }
            catch
            {
                dt = DateTime.MinValue;
            }
            return dt;
        }





        public static double ConvertStringToPrice(string strInput)
        {
            string strPrice = strInput.ToLower();

            if (string.IsNullOrEmpty(strPrice))
            {
                throw new ArgumentException("No input string");
            }

            if (!Regex.IsMatch(strPrice, @"^[\.\,\d]*$"))
            {
                throw new ArgumentException();
            }

            if (Regex.IsMatch(strPrice, @"^\d*$"))
            {
                return double.Parse(strPrice);
            }

            if (Regex.IsMatch(strInput, @"^[\d\,]+$") || Regex.IsMatch(strInput, @"^[\d\.]+$"))
            {
                strPrice = strPrice.Replace(".", ",");
                if (Regex.IsMatch(strPrice, @"^.*\,\d{0,2}$"))
                {
                    int index = strPrice.LastIndexOf(',');
                    StringBuilder sb = new StringBuilder(strPrice);
                    sb[index] = '.';
                    sb.Replace(",", "");
                    strPrice = sb.ToString();
                    return ConvertStringToPriceStandard(strPrice);
                }
                else if (Regex.IsMatch(strPrice, @"^.*\,\d{3}$"))
                {
                    strPrice = strPrice.Replace(",", "");
                    return long.Parse(strPrice);
                }
            }
            else if (Regex.IsMatch(strInput,@""))
            {
                //HonHopDau
                if (Regex.IsMatch(strPrice, @"\,\d*$"))
                {
                    strPrice = strPrice.Replace(".", "");
                    strPrice = strPrice.Replace(",", ".");
                }
                strPrice = strPrice.Replace(",", "");
                return ConvertStringToPriceStandard(strPrice);

            }

            return (double)0.0;

        }

        private static double ConvertStringToPriceStandard(string strStandard)
        {
            return double.Parse(strStandard, System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}

