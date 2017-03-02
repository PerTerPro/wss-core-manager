using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSS.ImageImbo.Lib;
using NUnit.Framework;
namespace WSS.ImageImbo.Lib.Tests
{
    [TestFixture()]
    public class ImboServiceTests
    {
        [Test()]
        public void PostImgToImboTest()
        {
            ImboService s = new ImboService();
            s.PostImgToImbo(@"http://192.168.100.34:40000/users/wss/images/4tzvqVzK2axk", "wss_write", "123websosanh@195", "wss", "https://172.22.1.226", 443);
        }
    }
}
