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
        
        void UpdateCrawlInfo(Product product);

        IEnumerable<Product> GetProducts(long companyId, int pageIndex, int rowInPage);
    }

}
