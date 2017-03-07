using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wss.Entities;
using Wss.Repository;

namespace Wss.Service.UpdateImageId
{
    public class Program
    {

        public static void Main()
        {
            
        }

        private IProductRepository _productRepository;
        private List<ImageProductInfo> _lstImageProductInfos=new List<ImageProductInfo>();
        private DateTime _lastRun = DateTime.Now;
        private  const int LimitMinuteTimeRun = 5;

        

        public void UpdateImageId()
        {
         
        }
    }
}
