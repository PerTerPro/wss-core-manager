using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wss.Crawl.CaheProduct
{
    public interface IProductCrawlerCache
    {
        void SyncCache(IEnumerable<Entities.Product> products);
    }
}
