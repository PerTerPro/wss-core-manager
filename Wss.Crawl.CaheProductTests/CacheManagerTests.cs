using System.Collections.Generic;
using NUnit.Framework;
using Telerik.JustMock;
using Telerik.JustMock.Core;
using Wss.Crawl.CaheProduct;
using Wss.Entities;
using Wss.Repository;
using Wss.Repository.Crawler;
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
            IManagerCacheProductCrawler productCrawlerCache = Mock.Create<IManagerCacheProductCrawler>();
            
            Mock.Arrange(() => productRepository.GetProductsForCacheCrawler(Arg.IsAny<long>(), Arg.IsAny<int>(), Arg.IsAny<int>())).Returns(new List<Product>()).OccursOnce();
            Mock.Arrange(() => productCrawlerCache.ResetCache(Arg.IsAny<long>())).DoNothing().OccursOnce();
            
            Wss.Crawl.CaheProduct.CacheCrawlerManager cacheManager = new CacheCrawlerManager(productRepository, productCrawlerCache);
          

            Mock.Assert(productRepository);
            Mock.Assert(productCrawlerCache);
        }

        public void ShouldBeNotExceptionWhenResetCacheForCompany()
        {
            IProductCacheRepository prodcCacheRepository = new ProductCacheRepository();
           

        }
    }
}
