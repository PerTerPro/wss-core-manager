using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wss.Entities.Crawler
{
    public class ProductCrawler
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime LastCrawler { set; get; }

        public bool GetHashCrawler()
        {
            throw new NotImplementedException();
        }
    }
}
