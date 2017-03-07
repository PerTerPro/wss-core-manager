using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wss.Entities
{
    public class ImageProductInfo
    {
        public long ProductId { get; set; }
        public string ImageId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
