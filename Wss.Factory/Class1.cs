using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Wss.Repository;
using Wss.Repository.Product;

namespace Wss.Factory
{
    public class BindingNidicrect:NinjectModule
    {
        public override void Load()
        {
            this.Bind<IProductRepository>().To<ProductRepository>();
           
        }
    }

   
}
