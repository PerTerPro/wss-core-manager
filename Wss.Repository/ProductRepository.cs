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

        private readonly SqlConnection _connection = null;
        private readonly ITriggerAfterChangeProduct _eventAfterChange = null; 

       
        public ProductRepository()
        {
            this._connection = new SqlConnection(@"Data Source=192.168.100.178;Initial Catalog=QT_2;Persist Security Info=True;User ID=sa;Password=123456a@;connection timeout=5000");
        }


        public ProductRepository(ITriggerAfterChangeProduct triggerAfterChangeProduct)
        {
            
        }


        public void Insert(Entities.Product entity)
        {

        }

        public void Delete(Entities.Product entity)
        {
            
        }

        public Entities.Product GetById(long id)
        {
            string sql = string.Format(@"Select Id, Name, Price, ImageId From Product pt Where pt.Id = {0}", id);
            return this._connection.Query<Entities.Product>(sql).First();
        }


      

        public void Delete(long id)
        {
           
        }

        Entities.Product IRepository<Entities.Product>.GetById(long id)
        {
            throw new NotImplementedException();
        }

        public void SetValidProduct(long productId, bool isValid)
        {
            
        }

   


        public IEnumerable<Entities.Product> GetProductsForCacheCrawler(long companyId, int pageId, int rowInPage)
        {
            string sql = string.Format(@"Select Id, Name, Price, ImageId, ImageUrls as ImageUrl, Company as CompanyId, DetailUrl From Product pt Where pt.company = {0}", companyId);
            return _connection.Query<Entities.Product>(sql);
        }

       
        public void DeleteProduct(IEnumerable<long> productIds)
        {
          
        }

       

        public void UpdateImageBatch(List<Tuple<long, string, string>> imageProducts)
        {
            
        }

        IEnumerable<Entities.Product> IProductRepository.GetProductsForCacheCrawler(long companyId, int pageIndex, int rowInPage)
        {
            throw new Exception();
        }


        public void UpdateProductByCrawler(Entities.Product product)
        {
            throw new NotImplementedException();
        }

        public void UpdateProducts(IEnumerable<Entities.Product> products)
        {
            throw new NotImplementedException();
        }

        public void Insert(IEnumerable<Entities.Product> product)
        {
            throw new NotImplementedException();
        }

        public void UpdateImageBatch(IEnumerable<ImageProductInfo> imageProductInfos)
        {
            string pattern = "Update Product Set ImageId = '{0}', Width = {1}, Height = {2} Where Id = {3}";
            var productInfos = imageProductInfos as ImageProductInfo[] ?? imageProductInfos.ToArray();
            List<string> str = productInfos.Select(a => string.Format(pattern, a.ImageId, a.Width, a.Height, a.ProductId)).ToList();
            this._connection.Execute(string.Join(";", str));

            foreach (var variable in productInfos)
            {
                _eventAfterChange.SendProduct(new ChangeInfo(variable.ProductId));
            }


        }

        public void InsertProduct(long productId, string name, long price)
        {
            var command = this._connection.CreateCommand();
            command.CommandText = "Insert Product (Id, Name, Price) Values (@Id, @Name, @Price)";
            command.CommandType = CommandType.Text;
            command.Parameters.AddRange(new[]
            {
                new SqlParameter()
                {
                    ParameterName = "Id",
                    SqlValue = productId,
                    SqlDbType = SqlDbType.BigInt
                },
                new SqlParameter()
                {
                    ParameterName = "Price",
                    SqlValue = price,
                    SqlDbType = SqlDbType.BigInt
                },

                new SqlParameter()
                {
                    ParameterName = "Name",
                    SqlDbType = SqlDbType.NVarChar,
                    SqlValue = name
                }
            });

            _connection.Open();
            command.ExecuteNonQuery();
            _connection.Close();
        }


        public void UpdateMainInfoProduct(long productId, string name, long price)
        {
            var command = this._connection.CreateCommand();
            command.CommandText = "Update Product Set Name = @Name, Price = @Price Where Id = @Id";
            command.CommandType=CommandType.Text;
            command.Parameters.AddRange(new[]
            {
                new SqlParameter()
                {
                    ParameterName = "Id",
                    SqlValue = productId,
                    SqlDbType = SqlDbType.BigInt
                },
                new SqlParameter()
                {
                    ParameterName = "Price",
                    SqlValue = price,
                    SqlDbType = SqlDbType.BigInt
                },

                new SqlParameter()
                {
                    ParameterName = "Name",
                    SqlDbType = SqlDbType.NVarChar,
                    SqlValue = name
                }
            });

            _connection.Open();
            command.ExecuteNonQuery();
            _connection.Close();

            return;
        }
    }
}
