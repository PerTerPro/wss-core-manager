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
        private readonly ITriggerBeforeChange _triggerBeforeChange;
        private readonly ITriggerBeforeChange _triggerAfterChange;
        

        public ProductBll(IRepository<Product> repositoryProduct, ITriggerBeforeChange triggerBeforeChange, ITriggerBeforeChange triggerAfterChange)
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
                Task.Run(() =>
                {
                    _triggerBeforeChange.TriggerDelete(productId);
                });
            }

            _repositoryProduct.Delete(productId);

            if (this._triggerAfterChange != null)
            {
                Task.Run(() =>
                {
                    _triggerAfterChange.TriggerDelete(productId);
                });
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
