using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;
using Websosanh.Core.Drivers.Redis;

namespace Wss.Crawl.CaheProduct
{
    public class ProductCrawlerCache : IProductCrawlerCache
    {
        private IDatabase _database;

        public ProductCrawlerCache()
        {
            _database = RedisManager.GetRedisServer("RedisCacheCrawlerProduct").GetDatabase(0);
        }

        public void SyncCache(IEnumerable<Entities.Product> products)
        {
           
        }
    }
}
