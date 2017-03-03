using System.Collections.Generic;
using NUnit.Framework;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;
using Wss.Bll;
using Wss.CrawlerProduct;
using Wss.Entities;
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
            ICompanyRepository companyRepository = Mock.Create<ICompanyRepository>();

            Mock.Arrange(() => productCacheRepository.GetProductCaches(Arg.IsAny<long>(), Arg.IsAny<int>())).Returns(new List<ProductCache>()
            {
                new ProductCache(),
                new ProductCache()
            }).OccursAtLeast(1);

            Mock.Arrange(() => downloader.GetHtml(Arg.IsAny<string>())).Returns("htmlTest").OccursAtLeast(1);
            Mock.Arrange(() => analysicProduct.Analysic(Arg.IsAny<string>(),Arg.IsAny<Company>())).Returns(new ProductCrawler()).OccursAtLeast(1);
            Mock.Arrange(() => companyRepository.GetById(Arg.IsAny<long>())).Returns(new Company()).OccursAtLeast(1);

            WorkerCrawler workerCrawler = new WorkerCrawler(1, productCacheRepository, downloader, productRepository, companyRepository, analysicProduct);
            workerCrawler.Start();

            Mock.Assert(productCacheRepository,"one");
            Mock.Assert(downloader);
            Mock.Assert(productRepository);
            Mock.Assert(analysicProduct);

        }
    }
}
