using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wss.Repository;

namespace Wss.Crawl.CaheProduct
{
    public class CacheCrawlerManager : IManagerCacheProductCrawler
    {
        private readonly IProductRepository _productRepository;
        private readonly IManagerCacheProductCrawler _productCrawlerCache;

        public CacheCrawlerManager(IProductRepository productRepository, IManagerCacheProductCrawler productCrawlerCache)
        {
            _productRepository = productRepository;
            _productCrawlerCache = productCrawlerCache;
        }

      

        public void ResetCache(long companyId)
        {
            _productCrawlerCache.CleanCache(companyId);
            _productCrawlerCache.ResetCache(companyId);
        }

        public void CleanCache(long companyId)
        {
            
        }
    }
}
