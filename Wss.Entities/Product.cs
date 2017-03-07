using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wss.Entities
{
    public class Product:Entity
    {
        public Product()
        {
            
        }
        private Crawler.ProductCrawler productCrawler;

        public Product(Crawler.ProductCrawler productCrawler)
        {
            // TODO: Complete member initialization
            this.productCrawler = productCrawler;
        }
        public string Name { get; set; }
        public long Price { get; set; }
        public string ImageId { get; set; }
        public string ImageUrl { get; set; }

        public string DetailUrl { get; set; }
    }
}
