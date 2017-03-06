using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wss.Entities;

namespace Wss.Bll.EventChangeProduct
{
    public interface ITriggerChangeProduct
    {
        void CallTriggerAfterChange(Product product, EEvent typeEvent);

        void CallTriggerAfterChange(IEnumerable<Product> products);

        void CallTriggerAfterChange(IEnumerable<long> productIds, EEvent eEvent);
        void CallTriggerAfterChange(IEnumerable<Product> productIds, EEvent eEvent);
    }
}
