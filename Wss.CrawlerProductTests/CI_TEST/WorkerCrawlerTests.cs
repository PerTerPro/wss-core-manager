using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using log4net;
using NUnit.Framework;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;
using Wss.Bll;
using Wss.Bll.Crawler;
using Wss.Bll.EventChangeProduct;
using Wss.Crawl.CaheProduct;
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
        public long companyId = 3309611577843405659;
        public ILog log = LogManager.GetLogger(typeof (WorkerCrawlerTests));

        [Test()]
        public void ShouldCrawlerStepByStep()
        {
            IProductCacheRepository productCacheRepository = Mock.Create<IProductCacheRepository>();

            IDownloader downloader = Mock.Create<IDownloader>();
            IProductRepository productRepository = Mock.Create<IProductRepository>();
            IAnalysicProduct analysicProduct = Mock.Create<IAnalysicProduct>();
            ICompanyRepository companyRepository = Mock.Create<ICompanyRepository>();
            IManagerProduct managerProduct = Mock.Create<IManagerProduct>();

            Mock.Arrange(() => productCacheRepository.GetTopProductCaches(Arg.IsAny<long>(), Arg.IsAny<int>())).Returns(new List<ProductCache>()
            {
                new ProductCache()
            }).OccursAtLeast(1);

            Mock.Arrange(() => downloader.GetHtml(Arg.IsAny<string>())).Returns("htmlTest").OccursAtLeast(1);
            Mock.Arrange(() => analysicProduct.Analysic(Arg.IsAny<string>(),Arg.IsAny<Company>())).Returns(new ProductCrawler()).OccursAtLeast(1);
            Mock.Arrange(() => companyRepository.GetById(Arg.IsAny<long>())).Returns(new Company()).OccursAtLeast(1);
            Mock.Arrange(() => managerProduct.Update(Arg.IsAny<IEnumerable<Product>>())).DoNothing().OccursAtLeast(1);

            WorkerCrawler workerCrawler = new WorkerCrawler(1, productCacheRepository, downloader, managerProduct, companyRepository, analysicProduct);
            workerCrawler.Start();

            Mock.Assert(productCacheRepository,"one");
            Mock.Assert(downloader);
            Mock.Assert(productRepository);
            Mock.Assert(analysicProduct);
        }

        [NUnit.Framework.Ignore]
        public void ShouldCrawlerSuccessExcept()
        {

            IManagerProduct managerProduct = Mock.Create<IManagerProduct>();
            Mock.Arrange(() => managerProduct.Update(Arg.IsAny<IEnumerable<Product>>())).DoInstead(new Action<IEnumerable<Product>>((obj1) =>
            {
                Console.WriteLine(string.Format("Saved {0} products", obj1.Count()));
            }));
            WorkerCrawler w = new WorkerCrawler(companyId,new ProductCacheRepository(), new Downloader(),managerProduct,new CompanyRepository(), new AnalysicProduct());
            w.Start();
        }
        
    }
}
