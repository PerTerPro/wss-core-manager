using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wss.Entities
{
    public class ChangeInfo
    {
        public long ProductId { get; set; }

        public ChangeInfo(long productId)
        {
            ProductId = productId;
        }
    }
}
