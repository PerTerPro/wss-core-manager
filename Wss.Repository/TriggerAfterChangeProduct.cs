using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wss.Lib.RabbitMq;

namespace Wss.Repository
{


    /// <summary>
    /// XuanTrang
    /// </summary>
    public interface ITriggerAfterChangeProduct
    {
        void SendProduct(Entities.ChangeInfo changeInfo,string typeChange);
    }

    public class TriggerAfterChangeProduct : ITriggerAfterChangeProduct
    {
        private IProducer _producer;

        public TriggerAfterChangeProduct()
        {
            
        }

        public void SendProduct(Entities.ChangeInfo changeInfo, string typeChange)
        {
            
        }
    }
}
