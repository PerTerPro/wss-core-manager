using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wss.Entities.Crawler
{
    [ProtoBuf.ProtoContract]
    public class HashProduct
    {
        [ProtoBuf.ProtoMember(3)]
        public long Id { get; set; }

        [ProtoBuf.ProtoMember(1)]
        public long Hash { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public int HashImage { get; set; }

        public string GetJson()
        {
            var myObjectString = "";
            using (var stream = new System.IO.MemoryStream())
            {
                ProtoBuf.Serializer.Serialize<HashProduct>(stream, this);
                myObjectString = Convert.ToBase64String(stream.ToArray());
            }
            return myObjectString;
        }


    }
}
