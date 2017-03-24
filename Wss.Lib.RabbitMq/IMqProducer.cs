using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Wss.Lib.RabbitMq
{

    public interface IMqProducer
    {
        void PublishString(string mss, bool persistence = true, int timeLiveBySecond = 0);
        void Publish(byte[] mss, bool persistence = true, int timeLiveBySecond = 0);
    }

}
