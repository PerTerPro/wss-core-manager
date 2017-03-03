using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wss.Entities;

namespace Wss.Bll.Crawler
{
    public class AnalysicProduct : IAnalysicProduct
    {
        public Company _company;

        public Entities.Crawler.ProductCrawler Analysic(string html, Company company)
        {
            return null;
        }
    }
}
