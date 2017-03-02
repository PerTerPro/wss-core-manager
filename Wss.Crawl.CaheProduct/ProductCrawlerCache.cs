using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace Wss.Crawl.CaheProduct
{
    public class ProductCrawlerCache : IProductCrawlerCache
    {
        private IDatabase _database; 


        public void SyncCache(IEnumerable<Entities.Product> products)
        {
           
        }
    }
}
