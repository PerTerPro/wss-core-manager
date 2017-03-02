using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wss.Bll;
using Wss.Entities;
using Wss.Entities.Crawler;
using Wss.Lib.Web;
using Wss.Repository.Crawler;

namespace Wss.CrawlerProduct
{
    public class WorkerCrawler
    {
        private readonly IProductCacheRepository _productCacheRepository;
        private readonly long _companyId;
        private readonly IAnalysicProduct _analysicProduct;
        private readonly IDownloader _downloader;

        public WorkerCrawler(long companyId, IProductCacheRepository productCacheRepository, IAnalysicProduct analysicProduct, IDownloader downloader)
        {
            this._companyId = companyId;
            this._productCacheRepository = productCacheRepository;
            this._analysicProduct = analysicProduct;
            _downloader = downloader;
        }

        public void Start()
        {
            var productsCache = _productCacheRepository.GetProductCaches(_companyId, 1000);
            foreach (var product in productsCache)
            {
                long productId = product.Id;
                string url = product.DetailUrl;
                ProductCrawler productCrawler = _analysicProduct.Analysic(_downloader.GetHtml(url));
                if (productCrawler != null)
                {
                    
                }
            }
        }

    }
}
