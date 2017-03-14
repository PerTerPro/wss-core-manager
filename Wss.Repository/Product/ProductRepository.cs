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

        private readonly IDbConnection _connection = null;
        private readonly ITriggerAfterChangeProduct _eventAfterChange = null; 


        public ProductRepository()
        {
            this._connection = new SqlConnection("");
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

        Entities.Product IRepository<Entities.Product>.GetById(long id)
        {
            throw new NotImplementedException();
        }

        public void SetValidProduct(long productId, bool isValid)
        {
            
        }

   


        public IEnumerable<Product> GetProductsForCacheCrawler(long companyId, int pageId, int rowInPage)
        {
            string sql = string.Format(@"Select Id, Name, Price, ImageId, ImageUrls as ImageUrl, Company as CompanyId, DetailUrl From Product pt Where pt.company = {0}", companyId);
            return _connection.Query<Product>(sql);
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


        public void UpdateProductByCrawler(Product product)
        {
            throw new NotImplementedException();
        }

        public void UpdateProducts(IEnumerable<Product> products)
        {
            throw new NotImplementedException();
        }

        public void Insert(IEnumerable<Product> product)
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
                _eventAfterChange.SendProduct(new ChangeInfo(variable.ProductId), "UpdateImageBath");
            }
        }
    }
}
