using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wss.Entities;

namespace Wss.Repository.Basic
{
    public interface IRepository<T> where T : Entity
    {
        void Insert(T entity);
        void Delete(long id);
        T GetById(long id);

        void SetValidProduct(long productId, bool isValid);

        void UpdateCrawlInfo(long productId);
    }
}
