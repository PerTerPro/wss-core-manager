using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wss.Entities;

namespace Wss.Repository.Basic
{
    public class ProductRepository:IRepository<Product>
    {
        public void Insert(Product entity)
        {
           
        }

        public void Delete(Product entity)
        {
            
        }

        public Product GetById(int id)
        {
            return null;
        }
    }
}
