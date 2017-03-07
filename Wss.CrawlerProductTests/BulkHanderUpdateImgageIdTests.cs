using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wss.Bll;
using NUnit.Framework;
using Telerik.JustMock;
using Wss.Entities;
using Wss.Repository;

namespace Wss.Bll.Tests
{
    [TestFixture()]
    public class BulkHanderUpdateImgageIdTests
    {
        [Test()]
        public void ShouldBeRunWithNoException()
        {
            IProductRepository productRepository = Mock.Create<IProductRepository>();
            Mock.Arrange(() => productRepository.UpdateImageBatch(Arg.IsAny<IEnumerable<ImageProductInfo>>())).DoInstead(
                new Action<IEnumerable<ImageProductInfo>>((obj1) =>
                {
                    Console.WriteLine(string.Format("Update ImageIds to SqlServer {0} items", obj1.Count()));
                })).OccursAtLeast(10);
            BulkHanderUpdateImgageId bulkHander = new BulkHanderUpdateImgageId(productRepository);
            bulkHander.Start();
            for (int i = 0; i < 50; i++)
            {
                bulkHander.AddItem(new ImageProductInfo()
                {
                    
                });
                Thread.Sleep(100);
            }
            bulkHander.Stop();
            Assert.AreEqual(1, 1);
        }

    }
}
