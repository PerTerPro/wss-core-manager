using System.Collections.Generic;
using NUnit.Framework;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;
using Wss.Bll;
using Wss.CrawlerProduct;
using Wss.Entities.Crawler;
using Wss.Lib.Web;
using Wss.Repository;
using Wss.Repository.Crawler;

namespace Wss.CrawlerProductTests
{
    [TestFixture()]
    public class WorkerCrawlerTests
    {
        [Test()]
        public void ShouldCrawlerStepByStep()
        {
            IProductCacheRepository productCacheRepository = Mock.Create<IProductCacheRepository>();
            IDownloader downloader = Mock.Create<IDownloader>();
            IProductRepository productRepository = Mock.Create<IProductRepository>();
            IAnalysicProduct analysicProduct = Mock.Create<IAnalysicProduct>();
            Mock.Arrange(() => productCacheRepository.GetProductCaches(Arg.IsAny<long>(), Arg.IsAny<int>())).Returns(new List<ProductCache>()
            {
                new ProductCache(),
                new ProductCache()
            }).CallOriginal().OccursAtLeast(1);
            Mock.Arrange(() => downloader.GetHtml(Arg.IsAny<string>())).Returns("htmlTest").CallOriginal().OccursAtLeast(1);
            Mock.Arrange(() => analysicProduct.Analysic(Arg.IsAny<string>())).Returns(new ProductCrawler()).CallOriginal().OccursAtLeast(1);
            WorkerCrawler workerCrawler = new WorkerCrawler(1, productCacheRepository, analysicProduct, downloader, productRepository);
        }
    }
}
