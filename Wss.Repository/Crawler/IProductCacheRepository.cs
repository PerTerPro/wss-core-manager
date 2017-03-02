using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wss.Entities.Crawler;

namespace Wss.Repository.Crawler
{
    public class IProductCacheRepository : IRepository<ProductCache>
    {

        public void Insert(ProductCache entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public ProductCache GetById(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductCache> GetProductCaches(long _companyId, int p)
        {
            throw new NotImplementedException();
        }
    }
}
