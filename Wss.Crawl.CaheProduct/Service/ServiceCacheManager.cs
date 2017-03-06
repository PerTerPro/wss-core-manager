using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wss.Crawl.CaheProduct.Service
{
    public  class ServiceCacheManager
    {
        private IManagerCacheProductCrawler _managerCacheProductCrawler;

        public ServiceCacheManager(IManagerCacheProductCrawler managerCacheProductCrawler)
        {
            _managerCacheProductCrawler = managerCacheProductCrawler;
        }

        public static ServiceCacheManager GetInstance()
        {
            return null;
        }

        public  void ResetCache(long companyId)
        {
            _managerCacheProductCrawler.ResetCache(companyId);
        }
    }

}
