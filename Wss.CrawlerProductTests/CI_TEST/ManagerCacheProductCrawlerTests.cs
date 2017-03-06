using NUnit.Framework;
using Wss.Crawl.CaheProduct;
using Wss.Repository;
using Wss.Repository.Crawler;

namespace Wss.CrawlerProductTests.CI_TEST
{
    [TestFixture()]
    public class ManagerCacheProductCrawlerTests
    {
       
        
        [NUnit.Framework.Ignore("CI Test")]
        public void ShouldRunSuccessForOneCompany()
        {
            ManagerCacheProductCrawler managerCacheProductCrawler = new ManagerCacheProductCrawler(new ProductCacheRepository(), new ProductRepository(), new CompanyRepository());
            managerCacheProductCrawler.ResetCache(3309611577843405659);
        }


        [NUnit.Framework.Ignore("CI Test")]
        public void ShouldRunSuccessForAllCompanys()
        {
            ManagerCacheProductCrawler managerCacheProductCrawler = new ManagerCacheProductCrawler(new ProductCacheRepository(), new ProductRepository(), new CompanyRepository());
            managerCacheProductCrawler.ResetCache();
        }

    }
}
