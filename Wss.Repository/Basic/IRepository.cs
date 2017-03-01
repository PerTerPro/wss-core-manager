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
        void Delete(T entity);
        T GetById(long id);
    }
}
