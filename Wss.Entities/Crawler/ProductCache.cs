using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wss.Entities.Crawler
{
    public class ProductCache : Entity
    {
        private ProductCrawler productCrawler;

        public ProductCache()
        {
            
        }

        public ProductCache(ProductCrawler productCrawler)
        {
            // TODO: Complete member initialization
            this.productCrawler = productCrawler;
        }
        public long Hash { get; set; }

        public string DetailUrl { get; set; }
    }
}
