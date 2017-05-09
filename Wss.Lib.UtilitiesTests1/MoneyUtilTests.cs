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
    public class MoneyUtilTests
    {
        [Test()]
        public void ShouldGetRateMoney()
        {
            MoneyUtil moneyUtil = new MoneyUtil();
            int x = moneyUtil.GetMoneyRate("usd");
            Assert.AreNotEqual(x, 1);
        }
    }
}
 