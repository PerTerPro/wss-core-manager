using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wss.Entities;
using Wss.Entities.Crawler;
using Wss.Lib.Hash;
using Wss.Repository;
using Wss.Repository.Crawler;

namespace Wss.Crawl.CaheProduct
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
            List<HashProduct> productCaches = products.Select(variable => new HashProduct()
            {
                Hash = CommonCrc.Crc64(string.Join("|", new[] { variable.Name, variable.ImageUrl, variable.Price.ToString() })),
                HashImage = CommonCrc.Crc32(variable.ImageUrl),
                Id = variable.Id
            }).ToList();
            _productCacheRepository.UpsertProductHashCache(companyId, productCaches);
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
