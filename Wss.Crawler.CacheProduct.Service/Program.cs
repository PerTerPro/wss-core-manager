using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Wss.Bll;
using Wss.Bll.Crawler;
using Wss.Crawl.CacheProduct;
using Wss.Lib.Web;
using Wss.Repository;
using Wss.Repository.Crawler;

namespace Wss.Crawler.CacheProduct.Service
{
    public static class Program
    {
        public static void Main()
        {



            //using (IKernel kernal = new StandardKernel())
            //{
            //    kernal.Bind<IProductRepository>().To<ProductRepository>();
            //    kernal.Bind<IManagerCacheProductCrawler>().To<ProductCrawlerCache>();
            //    kernal.Bind<IAnalysicProduct>().To<AnalysicProduct>();
            //    kernal.Bind<ICompanyRepository>().To<CompanyRepository>();
            //    kernal.Bind<IProductCacheRepository>().To<ProductCacheRepository>();
            //    kernal.Bind<IDownloader>().To<Downloader>();

            //    var paraCompany = new Ninject.Parameters.ConstructorArgument("companyId", 19379239237500733);
            //    WorkerCrawler workerCrawler = kernal.Get<WorkerCrawler>(paraCompany);
            //    workerCrawler.Start();
            //}
            //return;

           
        }
    }
}
