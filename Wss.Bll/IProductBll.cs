using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wss.Entities;

namespace Wss.Bll
{
    public interface IProductBll
    {
        void InsertProduct(Product product);
        void DeleteById(long productId);
        void UpdateCrawlInfoProduct(Product product);
        void SetValidProduct(long productId, bool isValid);
    }
}
