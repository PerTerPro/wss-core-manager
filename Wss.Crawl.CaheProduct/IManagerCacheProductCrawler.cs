using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Infrastructure.Language;
using Wss.Entities;
using Wss.Entities.Crawler;
using Wss.Lib.Hash;
using Wss.Repository;
using Wss.Repository.Crawler;

namespace Wss.Crawl.CacheProduct
{
    public interface IManagerCacheProductCrawler
    {
        void ResetCache(long companyId);
        void ResetCache();
        void CleanCache(long companyId);

    }

    public class ManagerCacheProductCrawler : IManagerCacheProductCrawler
    {
        private readonly IProductCacheRepository _productCacheRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICompanyRepository _companyRepository;

        public ManagerCacheProductCrawler(IProductCacheRepository productCacheRepository, IProductRepository productRepository, ICompanyRepository companyRepository)
        {
            _productCacheRepository = productCacheRepository;
            _productRepository = productRepository;
            _companyRepository = companyRepository;
        }


        public void ResetCache(IEnumerable<long> companyIds)
        {
            foreach (var companyId in companyIds)
            {
                ResetCache(companyId);
            }
        }


       
        public void ResetCache(long companyId)
        {
            _productCacheRepository.Delete(companyId);
            var products = _productRepository.GetProductsForCacheCrawler(companyId, 0, 100000);
            List<HashProduct> productCaches = products.Select(variable => new HashProduct(variable)).ToList();
            _productCacheRepository.UpsertProductHashCache(companyId, productCaches);
            _productCacheRepository.IncreateCode(companyId, productCaches.Select(a => a.Id).ToList());
        }



        public void CleanCache(long companyId)
        {
            _productCacheRepository.Clean(companyId);
        }


        public void ResetCache()
        {
            var companies = _companyRepository.GetAllCompanyIdsCrawler();
            foreach (var companyId in companies)
            {
                ResetCache(companyId.Id);
            }
        }
    }
}
