using System.Collections.Generic;
using System.Security.AccessControl;
using Wss.Bll.EventChangeProduct;
using Wss.Entities;
using Wss.Entities.Crawler;
using Wss.Lib.Web;
using Wss.Repository;
using Wss.Repository.Crawler;

namespace Wss.Bll.Crawler
{
    public class WorkerCrawler
    {
        private readonly IProductCacheRepository _productCacheRepository;
        private readonly IManagerProduct _productRepository;
        private readonly long _companyId;
        private readonly IAnalysicProduct _analysicProduct;
        private readonly IDownloader _downloader;
        private readonly Company _company;

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
                    ProductCache productCacheCrawler = new ProductCache(productCrawler);
                    if (productCache.Hash != productCacheCrawler.Hash)
                    {
                        Product ptNew = new Product(productCrawler);
                        _productRepository.Update(new List<Product>() {ptNew});

                    }
                }
            }
        }
    }
}
