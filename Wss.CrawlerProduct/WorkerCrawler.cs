using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wss.Bll;
using Wss.Bll.Crawler;
using Wss.Entities;
using Wss.Entities.Crawler;
using Wss.Lib.Web;
using Wss.Repository;
using Wss.Repository.Crawler;

namespace Wss.CrawlerProduct
{
    public class WorkerCrawler
    {
        private readonly IProductCacheRepository _productCacheRepository;
        private readonly IProductRepository _productRepository;
        private readonly long _companyId;
        private readonly IAnalysicProduct _analysicProduct;
        private readonly IDownloader _downloader;
        private readonly Company _company;

        public WorkerCrawler(long companyId, IProductCacheRepository productCacheRepository, IDownloader downloader, IProductRepository productRepository, ICompanyRepository companyRepository, IAnalysicProduct analysicProduct)
        {
            _companyId = companyId;
            _productCacheRepository = productCacheRepository;
            _analysicProduct = analysicProduct;
            _downloader = downloader;
            _productRepository = productRepository;
            _company = companyRepository.GetById(companyId);
        }

        public void Start()
        {
            var productsInCache = _productCacheRepository.GetProductCaches(_companyId, 1000);
            foreach (var productCache in productsInCache)
            {
                string url = productCache.DetailUrl;
                ProductCrawler productCrawler = _analysicProduct.Analysic(_downloader.GetHtml(url), _company);
                if (productCrawler != null)
                {
                    ProductCache productCacheCrawler  = new ProductCache(productCrawler);
                    if (productCache.GetHashCode() != productCacheCrawler.GetHashCode())
                    {
                        _productRepository.UpdateCrawlInfo(new Product(productCrawler));
                    }
                }
            }
        }
    }
}
