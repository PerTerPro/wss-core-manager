using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wss.Entities.Crawler;

namespace Wss.Repository.Crawler
{
    public interface IProductCacheRepository : IRepository<ProductCache>
    {
        IEnumerable<HashProduct> GetTopProductCaches(long companyId, int numberItems);
        void UpsertProducts(IEnumerable<ProductCache> productCaches);
        void UpsertProductHashCache(long companyId, IEnumerable<HashProduct> productCaches);
        void Clean(long companyId);

        void IncreateCode(long companyId, List<long> productCaches);
    }
    
}
