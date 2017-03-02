using Wss.Entities;

namespace Wss.Repository
{
    public interface IRepository<T> where T : Entity
    {
        void Insert(T entity);
        void Delete(long id);
        T GetById(long id);
      
    }

    
}
