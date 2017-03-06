using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wss.Entities;
using Wss.Entities.Crawler;

namespace Wss.Bll.Crawler
{
    public interface IParserProductCrawler
    {
        ProductCrawler Parse(string html, Company company);
    }
}
