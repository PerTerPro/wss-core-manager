using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wss.Entities
{
    public partial class  Product:Entity
    {
        public Product()
        {
            
        }
        public string Name { get; set; }
        public long Price { get; set; }
        public string ImageId { get; set; }
        public string ImageUrl { get; set; }

        public string DetailUrl { get; set; }
    }
}
