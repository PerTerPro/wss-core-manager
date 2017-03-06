using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wss.Entities;

namespace Wss.Repository
{
    public interface ICompanyRepository:IRepository<Company>
    {
        IEnumerable<Company> GetAllCompanyCrawler();
    }
}
