using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Websosanh.Core.Drivers.RabbitMQ;
using Wss.Entities;
using Wss.Service.UpdateImageId.Lib;

namespace Wss.Service.UpdateImageId
{
    public class WorkerMq : QueueingConsumer
    {
        private readonly HandlerBulkImageIdToSql _handlerBulkImageIdToSql;

        public override void ProcessMessage(RabbitMQ.Client.Events.BasicDeliverEventArgs message)
        {
            _handlerBulkImageIdToSql.AddItem(Newtonsoft.Json.JsonConvert.DeserializeObject<ImageProductInfo>(UTF8Encoding.UTF8.GetString(message.Body)));
        }

        public override void Init()
        {
            
        }

        public WorkerMq(RabbitMQServer rabbitmqServer, string queueName, bool autoAck, HandlerBulkImageIdToSql handlerBulkImageIdToSql) : base(rabbitmqServer, queueName, autoAck)
        {
            _handlerBulkImageIdToSql = handlerBulkImageIdToSql;
            _handlerBulkImageIdToSql.Start();
        }
    }
}
