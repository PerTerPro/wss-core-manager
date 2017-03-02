using NUnit.Framework;
using WSS.ImageImbo.Lib;

namespace WSS.ImageImbo.LibTests
{
    [TestFixture()]
    public class ImboServiceTests
    {
        [Test()]
        public void DownloadImageProductWithImboServerTest()
        {
            string url = @"http://nobacks.com/wp-content/uploads/2014/11/Peach-50-500x329.png";
            string x = (new ImboService()).PostImageToImbo(url, "wss_write", "123websosanh@195", "wss", @"https://172.22.1.226", 443);
            Assert.Greater(x.Length, 10);
        }

         [Test()]
        public void PostImgToImboTest()
        {
            string url = @"https://img.websosanh.vn/users/wss/images/1KVlyFMDkU9r";
            string x = (new ImboService()).PostImgToImboChangeBackgroundTransference(url, "wss_write", "123websosanh@195", "wss", @"http://192.168.100.34", 40000);
            Assert.Greater(x.Length, 10);
        }
    }
}
