using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wss.Bll;

namespace Wss.WorkerRabbitMq
{
    public class WorkerDeleteProduct
    {
        private IProductBll productBll;

        public WorkerDeleteProduct(IProductBll productBll)
        {
            this.productBll = productBll;
        }

    }
}
