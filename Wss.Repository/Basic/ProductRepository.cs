using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Wss.Entities;

namespace Wss.Repository.Basic
{
    public class ProductRepository:IRepository<Product>
    {
        private IDbConnection _connection=null;

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
            string sql = string.Format(@"Select Id, Name, Price From Product pt Where pt.Id = {0}", id);
            return this._connection.Query<Product>(sql).First();
        }

       
    }
}
