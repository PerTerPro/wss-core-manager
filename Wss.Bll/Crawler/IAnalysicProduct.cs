using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wss.Entities;
using Wss.Entities.Crawler;
namespace Wss.Bll
{
    public interface IAnalysicProduct
    {
         ProductCrawler Analysic(string html, Company company);
    }
}
