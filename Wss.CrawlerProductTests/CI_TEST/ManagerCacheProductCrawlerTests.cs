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

    
    [TestFixture()]
    public class ManagerCacheProductCrawlerTests
    {
       
        //[Test("CI Test")]
        [NUnit.Framework.Ignore("CI Test")]
        public void ShouldRunSuccessForACompany()
        {
            ManagerCacheProductCrawler managerCacheProductCrawler = new ManagerCacheProductCrawler(new ProductCacheRepository(), new ProductRepository());
            managerCacheProductCrawler.ResetCache(3309611577843405659);
        }

        public void ResetCache

    }
}
