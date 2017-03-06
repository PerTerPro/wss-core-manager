using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wss.Entities;
using Wss.Entities.Crawler;
using Wss.Repository.Crawler;

namespace Wss.Repository.CrawlerCache
{
    public  class ServiceCrawlerCache
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductCacheRepository _productRepositoryProductCache;

        public ServiceCrawlerCache(IProductRepository productRepository, IProductCacheRepository productRepositoryProductCache)
        {
            _productRepository = productRepository;
            _productRepositoryProductCache = productRepositoryProductCache;
        }

        public void ResetCache(long companyId)
        {
            _productRepositoryProductCache.Clean(companyId);
            const int pageCount = 1000;
            int page = 0;
            do
            {
                var products = _productRepository.GetProducts(companyId, page++, pageCount);
                var enumerableProduct = products as Product[] ?? products.ToArray();
                if (!enumerableProduct.Any())
                {
                    var productCaches = enumerableProduct.Select(variable => new ProductCache(variable)).ToList();
                    _productRepositoryProductCache.UpsertProducts(productCaches);
                }
            } while (true);
        }
    }
}
