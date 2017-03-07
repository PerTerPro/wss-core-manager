using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wss.Bll;
using Wss.Entities;
using Wss.Repository;

namespace Wss.Service.UpdateImageId.Lib
{
    public class HandlerBulkImageIdToSql:BulkRunnerBasic
    {
        private readonly IProductRepository _productRepository;
        private  DateTime _lastRun = DateTime.Now;
        private readonly List<ImageProductInfo> _imageProductInfos=new List<ImageProductInfo>();

        public HandlerBulkImageIdToSql(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public override bool CheckRun()
        {
            lock (this.objLockRun)
            {
                return ((_lastRun - DateTime.Now).TotalMinutes > 5 || _imageProductInfos.Count() > 10);
            }
        }

        public override void Run()
        {
           
            lock (this.objLockRun)
            {
                _productRepository.UpdateImageBatch(_imageProductInfos);
                _imageProductInfos.Clear();
                _lastRun = DateTime.Now;
            }
          
        }

        public void AddItem(ImageProductInfo productInfo)
        {
            lock (this.objLockRun)
            {
                _imageProductInfos.Add(productInfo);
            } 
        }
    }
}
