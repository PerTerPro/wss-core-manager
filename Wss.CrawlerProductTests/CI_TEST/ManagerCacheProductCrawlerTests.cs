using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wss.Crawl.CaheProduct;
using NUnit.Framework;
using Wss.Repository;
using Wss.Repository.Crawler;

namespace Wss.Crawl.CaheProduct.Tests
{

    /// <summary>
    /// CI Test
    /// </summary>
    [TestFixture()]
    public class ManagerCacheProductCrawlerTests
    {
     

        [Test()]
        public void ResetCacheTest()
        {
            ManagerCacheProductCrawler managerCacheProductCrawler = new ManagerCacheProductCrawler(new ProductCacheRepository(), new ProductRepository());
            managerCacheProductCrawler.ResetCache(3309611577843405659);
        }

      
    }
}
