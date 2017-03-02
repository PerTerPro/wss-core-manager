using System.Data;
using System.Linq;
using Dapper;
using Wss.Entities;
using Wss.Repository.Basic;

namespace Wss.Repository
{
    public class ProductRepository:IRepository<Product>
    {
        private readonly IDbConnection _connection=null;

        public ProductRepository(IDbConnection connection)
        {
            this._connection = connection;
        }


        public void Insert(Product entity)
        {

        }

        public void Delete(Product entity)
        {
            
        }

        public Product GetById(long id)
        {
            string sql = string.Format(@"Select Id, Name, Price, ImageId From Product pt Where pt.Id = {0}", id);
            return this._connection.Query<Product>(sql).First();
        }


        public void Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public void SetValidProduct(long productId, bool isValid)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCrawlInfo(Product pt)
        {
            throw new System.NotImplementedException();
        }
    }
}
