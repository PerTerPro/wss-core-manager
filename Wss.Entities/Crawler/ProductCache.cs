using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.JustMock.AutoMock.Ninject;
using Wss.Lib.Hash;

namespace Wss.Entities.Crawler
{
    public class ProductCache : Entity
    {
      

        public ProductCache()
        {
            
        }

        public ProductCache(ProductCrawler productCrawler)
        {
          
        }

        public ProductCache(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Price = product.Price;
            ImageUrl = product.ImageUrl;
        }

        public string Name { get; set; }

        public long Price { get; set; }

        public long Hash { get; set; }

        public string DetailUrl { get; set; }
        public long CompanyId { get; set; }

        public string GetJsonProtobuf()
        {
            throw new NotImplementedException();
        }

        public static ProductCache GetFromJsonProtobuf(string strJson)
        {
            return null;
        }

        public string ImageUrl { get; set; }
    }
}
