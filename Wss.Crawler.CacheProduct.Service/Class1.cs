using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Wss.Crawl.CaheProduct;
using Wss.Repository;

namespace Wss.Crawler.CacheProduct.Service
{
    public static class Program
    {
        public static void Main()
        {
            using (IKernel kernal = new StandardKernel())
            {
                kernal.Bind<IProductRepository>().To<ProductRepository>();
                kernal.Bind<IProductCrawlerCache>().To<ProductCrawlerCache>();
                var tc = kernal.Get<CacheCrawlerManager>();
                tc.SyncCode(24709975467303384);
            }
        }
    }
}
