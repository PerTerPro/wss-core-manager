using System.Collections.Generic;
using log4net;
using Wss.Bll;
using Wss.Entities;
using Wss.Entities.Crawler;
using Wss.Lib.Web;
using Wss.Repository;
using Wss.Repository.Crawler;

namespace Wss.Crawl.CacheProduct
{
    public class WorkerCrawler
    {
        private readonly IProductCacheRepository _productCacheRepository;
        private readonly IManagerProduct _productRepository;
        private readonly long _companyId;
        private readonly IAnalysicProduct _analysicProduct;
        private readonly IDownloader _downloader;
        private readonly Company _company;
        private readonly ILog _log = LogManager.GetLogger(typeof (WorkerCrawler));

        public WorkerCrawler(long companyId, IProductCacheRepository productCacheRepository, IDownloader downloader, IManagerProduct productRepository, ICompanyRepository companyRepository,
            IAnalysicProduct analysicProduct)
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
            var productsInCache = _productCacheRepository.GetTopProductCaches(_companyId, 1000);
            foreach (var productCache in productsInCache)
            {
                string url = productCache.DetailUrl;
                ProductCrawler productCrawler = _analysicProduct.Analysic(_downloader.GetHtml(url), _company);
                if (productCrawler != null)
                {
                    var productCacheCrawler = new ProductCache(productCrawler);
                    if (productCache.Hash != productCacheCrawler.Hash)
                    {
                        Product ptNew = new Product(productCrawler);
                        _log.Debug(string.Format("Product {0} change", ptNew.Id));
                        _productRepository.Update(new List<Product>() {ptNew});
                    }
                }
            }
        }
    }
}
