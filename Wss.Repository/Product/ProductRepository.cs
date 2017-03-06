using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Wss.Entities;

namespace Wss.Repository
{
    public class ProductRepository:IProductRepository
    {
        private readonly IDbConnection _connection=null;

        public ProductRepository()
        {
            this._connection = new SqlConnection(WSS.StaticConnect.Connection.ConnectionProduct);
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
           
        }

        public void SetValidProduct(long productId, bool isValid)
        {
            
        }

        public void UpdateProductByCrawler(Product pt)
        {
            
        }


        public IEnumerable<Product> GetProducts(long companyId, int pageId, int rowInPage)
        {
            string sql = string.Format(@"Select Id, Name, Price, ImageId From Product pt Where pt.company = {0}", companyId);
            return _connection.Query<Product>(sql);
        }

        public void UpdateProducts(IEnumerable<Product> products)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(IEnumerable<long> productIds)
        {
          
        }

        public void Insert(IEnumerable<Product> product)
        {
          
        }


        public void UpdateImageBatch(List<Tuple<long, string, string>> imageProducts)
        {
            
        }
    }
}
