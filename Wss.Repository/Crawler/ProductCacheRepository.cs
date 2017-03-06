using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;
using Websosanh.Core.Drivers.Redis;
using Wss.Entities.Crawler;

namespace Wss.Repository.Crawler
{
    public class ProductCacheRepository:IProductCacheRepository
    {
        private const string PREFIX_LASTCRL_PRODUCT = "lst_crl:";
        private const string PREFIX_CACHE_PRODUCT = "prd_cache:";

        private IDatabase _database;

        public ProductCacheRepository()
        {
            _database = RedisManager.GetRedisServer("redisCacheCrawlerDuplicate").GetDatabase(0);
        }

        public IEnumerable<ProductCache> GetTopProductCaches(long companyId, int numberItems)
        {
            RedisValue[] productIds = _database.SortedSetRangeByRank(PREFIX_LASTCRL_PRODUCT + companyId, 0, numberItems, Order.Ascending);
            RedisValue[] productInCaches = _database.HashGet(PREFIX_CACHE_PRODUCT + companyId, productIds);
            List<ProductCache> productCaches = new List<ProductCache>();
            foreach (var strProduct in productInCaches)
            {
                var product = ProductCache.GetFromJsonProtobuf(strProduct);
                if (product != null)
                {
                    productCaches.Add(product);
                }
            }
            return null;
        }

        public void UpsertProducts(IEnumerable<ProductCache> productCaches)
        {
            foreach (var productCache in productCaches)
            {
                _database.SortedSetIncrement(PREFIX_LASTCRL_PRODUCT + productCache.CompanyId.ToString(), productCache.Id, 1);
                _database.HashSet(PREFIX_CACHE_PRODUCT + productCache.CompanyId, productCache.Id.ToString(), productCache.GetJsonProtobuf());
            }
        }

        public void Clean(long companyId)
        {
            _database.KeyDelete(PREFIX_CACHE_PRODUCT + companyId.ToString());
            _database.KeyDelete(PREFIX_LASTCRL_PRODUCT + companyId.ToString());
        }

        public void Insert(Entities.Crawler.ProductCache entity)
        {
           
        }

        public void Delete(long id)
        {
            _database.KeyDelete(id.ToString());
        }

        public Entities.Crawler.ProductCache GetById(long id)
        {
            return null;
        }


        public void UpsertProductHashCache(long companyId, IEnumerable<HashProduct> productCaches)
        {
            var lst = productCaches.Select(v => new HashEntry(v.Id, v.GetJson())).ToArray();
            _database.HashSet(PREFIX_CACHE_PRODUCT + companyId, lst);
        }
    }
}
