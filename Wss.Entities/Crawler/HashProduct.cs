using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Wss.Lib.Hash;

namespace Wss.Entities.Crawler
{
    [ProtoBuf.ProtoContract]
    public class HashProduct
    {
        public HashProduct(Product product)
        {
            Hash = CommonCrc.Crc64(string.Join("|", new[] {product.Name, product.ImageUrl, product.Price.ToString()}));
            HashImage = CommonCrc.Crc32(product.ImageUrl);
            Id = product.Id;
            DetailUrl = product.DetailUrl;
        }

        public HashProduct()
        {
          
        }

        [ProtoBuf.ProtoMember(3)]
        public long Id { get; set; }

        [ProtoBuf.ProtoMember(1)]
        public long Hash { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public int HashImage { get; set; }
        [ProtoBuf.ProtoMember(3)]
        public string DetailUrl { get; set; }



        public string GetJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static HashProduct FromJsonProtobuf(string str)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<HashProduct>(str);
        }

      
    }
}
