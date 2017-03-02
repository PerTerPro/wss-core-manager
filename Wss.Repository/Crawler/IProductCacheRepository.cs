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
        IEnumerable<ProductCache> GetProductCaches(long companyId, int numberItems);


    }
}
