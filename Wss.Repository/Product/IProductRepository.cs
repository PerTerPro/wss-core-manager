using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wss.Entities;

namespace Wss.Repository
{
    public interface IProductRepository:IRepository<Product>
    {
        void SetValidProduct(long productId, bool isValid);
        
        void UpdateProductByCrawler(Product product);

        /// <summary>
        /// Tuple. ProductId-ImageOld-ImageNew
        /// </summary>
        /// <param name="imageProducts"></param>
        void UpdateImageBatch(List<Tuple<long, string, string>> imageProducts);

        IEnumerable<Product> GetProductsForCacheCrawler(long companyId, int pageIndex, int rowInPage);

        void UpdateProducts(IEnumerable<Product> products);

        void DeleteProduct(IEnumerable<long> productIds);

        void Insert(IEnumerable<Product> product);
    }

}
