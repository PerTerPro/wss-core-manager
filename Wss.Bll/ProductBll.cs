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
        private readonly ITriggerBeforeChangeProduct _triggerBeforeChange;
        private readonly ITriggerAfterChangeProduct _triggerAfterChange;

        public ProductBll(IRepository<Product> repositoryProduct, ITriggerBeforeChangeProduct triggerBeforeChange, ITriggerAfterChangeProduct triggerAfterChange)
        {
            _repositoryProduct = repositoryProduct;
            _triggerBeforeChange = triggerBeforeChange;
            _triggerAfterChange = triggerAfterChange;
        }

        public void InsertProduct(Product product)
        {
            if (this._triggerBeforeChange != null)
            {
                this._triggerBeforeChange.TriggerInsert(product);
            }
            _repositoryProduct.Insert(product);
            Task.Run(() =>
            {
            });
        }

        public void DeleteById(long productId)
        {
            if (this._triggerBeforeChange != null)
            {
                var product = _repositoryProduct.GetById(productId);
                _triggerBeforeChange.TriggerDelete(product);
            }
            _repositoryProduct.Delete(productId);
            if (this._triggerAfterChange != null)
            {
                _triggerAfterChange.TriggerDelete(productId);
            }
        }

        public void UpdateCrawlInfoProduct(Product product)
        {
            if (_triggerBeforeChange != null)
            {
                var productOld = _repositoryProduct.GetById(product.Id);
                _triggerBeforeChange.TriggerUpdate(productOld);
            }

            _repositoryProduct.UpdateCrawlInfo(product);

            if (_triggerAfterChange != null)
            {
                _triggerAfterChange.TriggerUpdate(product);
            }
           
        }

        public void SetValidProduct(long productId, bool isValid)
        {
            _repositoryProduct.SetValidProduct(productId, isValid);

        }
    }
}
