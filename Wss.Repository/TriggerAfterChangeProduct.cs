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
        void SendProduct(Entities.ChangeInfo changeInfo,string typeChange);
    }

    public class TriggerAfterChangeProduct : ITriggerAfterChangeProduct
    {
        private readonly IMqProducer _producer;

        public TriggerAfterChangeProduct(IMqProducer producer, IMqProducer producer1)
        {
            _producer = producer1;
        }

        public void SendProduct(Entities.ChangeInfo changeInfo, string typeChange)
        {
            _producer.PublishString(changeInfo.ProductId.ToString());
        }
    }
}
