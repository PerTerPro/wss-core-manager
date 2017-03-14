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
            //ImboService s = new ImboService();
            //s.PostImgToImbo(@"http://dienmaytanbinh.vn/data/upload/SanakyVH-5699W-1413906600-.jpg", "wss_write", "123websosanh@195", "wss", "https://172.22.1.226", 443);
        }

        [Test()]
        public void PostImgWithChangeTransferenceTest()
        {
            ImboService imaService = new ImboService();
            imaService.PostImgToImbo(@"C:\Users\xuantrang\Pictures\a.png","wss_write","123websosanh@195","wss","https://172.22.1.226",443); 
            
        }
    }
}
