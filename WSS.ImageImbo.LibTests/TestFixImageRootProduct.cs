using NUnit.Framework;
using WSS.ImageImbo.Lib;

namespace WSS.ImageImbo.LibTests
{
    [TestFixture()]
    public class TestFixImageRootProduct
    {
        [Test()]
        public void DownloadImageProductWithImboServerTest()
        {
        }

        [Test()]
        public void PostImgToImboTest()
        {
            bool x = WSS.AutoFixLinkRootProduct.Program.CheckExistsInImbo("5F-7UVzZNqz9");
            Assert.AreEqual(false, x);
            

        }

        [Test()]
        public void ProcessJob()
        {
            WSS.AutoFixLinkRootProduct.Program.ProcessData(77045990, "OGMeJ-FEv_wt", @"https://www.vinabook.com/images/thumbnails/product/240x/13498_p19886.jpg", 10);



        }
    }
}
