using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wss.Repository.Crawler
{
    public class ProductCacheRepository:IProductCacheRepository
    {
        IDbConnection _dbConnection;

        public IEnumerable<Entities.Crawler.ProductCache> GetProductCaches(long companyId, int numberItems)
        {
            return null;
        }

        public void Insert(Entities.Crawler.ProductCache entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Entities.Crawler.ProductCache GetById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
