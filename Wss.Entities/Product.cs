using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wss.Entities
{
    public class Product:Entity
    {
        public string Name { get; set; }
        public long Price { get; set; }
        public string ImageId { get; set; }

       
    }
}
