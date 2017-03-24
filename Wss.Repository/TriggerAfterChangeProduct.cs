using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wss.Lib.RabbitMq;

namespace Wss.Repository
{

    public interface ITriggerAfterChangeProduct
    {
        void SendProduct(Entities.ChangeInfo changeInfo);
    }

    public class TriggerAfterChangeProduct : ITriggerAfterChangeProduct
    {
        public TriggerAfterChangeProduct(IMqProducer producer)
        {
            this.producer = producer;
        }

        private IMqProducer producer;

      

        public void SendProduct(Entities.ChangeInfo changeInfo)
        {
            producer.PublishString(changeInfo.JsonString());
        }
    }
}
