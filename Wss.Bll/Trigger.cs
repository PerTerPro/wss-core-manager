using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Wss.Entities;

namespace Wss.Bll
{
   

    public interface ITriggerBeforeChange
    {
        void TriggerInsert(Product product);
        void TriggerUpdate(Product product);
        void TriggerDelete(long product);

    }

    public interface ITriggerAfterChange
    {
        void TriggerInsert(long product);
        void TriggerUpdate(long product);
        void TriggerDelete(long product);

    }
}
