using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wss.Entities;
using Wss.Lib.RabbitMq;
using Wss.Repository.Basic;

namespace Wss.Bll
{
    public class ProductBll
    {
        private readonly IRepository<Product> _repositoryProduct ;

        private readonly IProducer _producerTriggerAfterInsertProduct;
        private readonly IProducer _producerTriggerAfterUpdateProduct;
        private readonly IProducer _producerTriggerAfterDeleteProduct;

        public ProductBll(IRepository<Product> repositoryProduct, IProducer producerTriggerAfterInserProduct, IProducer producerTriggerAfterChangeProduct, IProducer producerTriggerAfterDeleteProduct)
        {
            _repositoryProduct = repositoryProduct;
            _producerTriggerAfterInsertProduct = producerTriggerAfterInserProduct;
            _producerTriggerAfterUpdateProduct = producerTriggerAfterChangeProduct;
            _producerTriggerAfterDeleteProduct = producerTriggerAfterDeleteProduct;
        }

        public void InsertProduct(Product product)
        {
            _repositoryProduct.Insert(product);
            Task.Run(() =>
            {
                _producerTriggerAfterInsertProduct.PublishString(product.Id.ToString());
            });
        }

        public void DeleteById(long productId)
        {
            _repositoryProduct.Delete(productId);
            Task.Run(() =>
            {
               _producerTriggerAfterDeleteProduct.PublishString(productId.ToString());
            });
        }

        public void UpdateCrawlInfoProduct(long productId, string name, long price, string imageUrl)
        {
            Product pt = new Product()
            {
                Id = productId,
                Name = name,
                ImageUrl = imageUrl
            };

            _repositoryProduct.UpdateCrawlInfo(productId);
            Task.Run(() =>
            {
                _producerTriggerAfterUpdateProduct.PublishString(productId.ToString());
            });
        }

        public void SetValidProduct(long productId, bool isValid)
        {
            _repositoryProduct.SetValidProduct(productId, isValid);

        }
    }
}
