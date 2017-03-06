using System.Collections.Generic;
using NUnit.Framework;
using Telerik.JustMock;
using Telerik.JustMock.Core;
using Wss.Crawl.CaheProduct;
using Wss.Entities;
using Wss.Repository;
using Wss.Repository.CrawlerCache;

namespace Wss.Crawl.CaheProductTests
{
    [TestFixture()]
    public class CacheManagerTests
    {
        [Test()]
        public void ShouldCallGetProductAndUpdateToCacheOneTime()
        {
            IProductRepository productRepository = Mock.Create<IProductRepository>();
            IProductCrawlerCache productCrawlerCache = Mock.Create<IProductCrawlerCache>();
            Mock.Arrange(() => productRepository.GetProducts(Arg.IsAny<long>(), Arg.IsAny<int>(), Arg.IsAny<int>())).Returns(new List<Product>()).OccursOnce();
            Mock.Arrange(() => productCrawlerCache.SyncCache(Arg.IsAny<IEnumerable<Product>>())).DoNothing().OccursOnce();
            
            Wss.Crawl.CaheProduct.CacheCrawlerManager cacheManager = new CacheCrawlerManager(productRepository, productCrawlerCache);
            cacheManager.SyncCode(24709975467303384);

            Mock.Assert(productRepository);
            Mock.Assert(productCrawlerCache);
        }

        public void ShouldBeNotExceptionWhenResetCacheForCompany()
        {
             IProductRepository productRepository = Mock.Create<IProductRepository>();
             
              
        }
    }
}
