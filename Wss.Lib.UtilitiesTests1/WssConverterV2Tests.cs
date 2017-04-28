using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wss.Lib.Utilities;
using NUnit.Framework;

namespace Wss.Lib.Utilities.Tests
{
    [TestFixture()]
    public class WssConverterV2Tests
    {


        [Test()]
        [NUnit.Framework.ExpectedException(typeof (ArgumentException))]
        public void ShouldThrowNewExceptionWHenNoInput()
        {
          
           CommonConvert.ConvertStringToPrice("");
        }

        [Test()]
        [NUnit.Framework.ExpectedException(typeof (ArgumentException))]
        public void ShouldThrowExceptionWhenNotValidRegexNumber()
        {
          
            CommonConvert.ConvertStringToPrice("3434,3434 vnd");
        }

        [Test()]
        public void ShouldConvertNoramlNumber()
        {

            var y = CommonConvert.ConvertStringToPrice("10000");
            Assert.AreEqual(10000, y);
        }


        [Test()]
        public void ShouldConvertForGreaterOneDotAndLessThreadNumbeEnd()
        {

            var y = CommonConvert.ConvertStringToPrice("123.789.91");
            Assert.AreEqual(123789.91, y);
        }

        [Test()]
        public void ShouldConvertForGreaterOneComanAndLessThreadNumbeEnd()
        {

            var y = CommonConvert.ConvertStringToPrice("123,789,91");
            Assert.AreEqual(123789.91, y);
        }

        [Test()]
        public void ShouldConvertForNumberLongWitComma()
        {

            var y = CommonConvert.ConvertStringToPrice("123,455,789");
            Assert.AreEqual(123455789, y);
        }

        [Test()]
        public void ShouldConvertForNumberLongWithDot()
        {

            var y = CommonConvert.ConvertStringToPrice("123.456.789");
            Assert.AreEqual(123456789, y);
        }

        [Test()]
        public void ShouldConvertForNumberDotAndCommand()
        {


            var y = CommonConvert.ConvertStringToPrice("12.123.323,23");
            Assert.AreEqual(12123323,23, y);

            var y1 = CommonConvert.ConvertStringToPrice("12,123,323.23");
            Assert.AreEqual(12123323, 23, y1);
        }

        [Test]
        public void CheckPriceParseOfERotenCom()
        {

            var x = CommonConvert.ConvertStringToPrice("657.00");
            Assert.AreEqual(657, x);
        }

    }
}
