using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wss.Repository;

namespace Wss.Crawl.CaheProduct
{
    public class CacheCrawlerManager
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductCrawlerCache _productCrawlerCache;

        public CacheCrawlerManager(IProductRepository productRepository, IProductCrawlerCache productCrawlerCache)
        {
            _productRepository = productRepository;
            _productCrawlerCache = productCrawlerCache;
        }

        public void SyncCode(long company)
        {
            var products = _productRepository.GetProducts(24709975467303384, 1, 100);
            _productCrawlerCache.SyncCache(products);
        }
    }
}
