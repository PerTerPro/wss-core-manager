using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Websosanh.Core.Drivers.RabbitMQ;

namespace Wss.Lib.RabbitMq
{
    public class ConsumerBasic<T> : QueueingConsumer
    {
        public delegate void DelegateProcessJob(T objectData);
        public DelegateProcessJob _eventProcessJob;

        public ConsumerBasic(RabbitMQServer rabbitmqServer, string queueName) :
            base(rabbitmqServer, queueName, false)
        {
        }

        public override void ProcessMessage(RabbitMQ.Client.Events.BasicDeliverEventArgs message)
        {
            if (typeof(T) == typeof(string))
            {
                var t = Encoding.UTF8.GetString(message.Body);
                Logger.InfoFormat("Get mss: {0}", t);
                _eventProcessJob?.Invoke((T)Convert.ChangeType(t, typeof(T)));
                this.GetChannel().BasicAck(message.DeliveryTag, true);
            }
            else
            {
                var t = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(message.Body));
                Logger.InfoFormat("Get mss: {0}", t);
                _eventProcessJob?.Invoke(t);
                this.GetChannel().BasicAck(message.DeliveryTag, true);
            }
        }

        public override void Init()
        {
        }

    }
}
