using NUnit.Framework;
using Wss.Lib.Utilities;

namespace Wss.Lib.UtilitiesTests1
{
    [TestFixture()]
    public class ParserParameterTests
    {
        [Test()]
        public void ParseTest()
        {
            var para = ParserParameter.Parse("-cmd Cmd -p1 x -p2 y -p3 x z t");
            Assert.IsNotNull(para);
        }
    }
}
