using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wss.Bll.EventChangeProduct;
using Wss.Entities;
using Wss.Repository;

namespace Wss.Bll
{
    /// <summary>
    /// Quản lí Product trong hệ thống
    /// </summary>
    public interface IManagerProduct
    {
        void Update(IEnumerable<Product> products);
        void Delete(IEnumerable<long> productIds);
        void Insert(IEnumerable<Product> product);

    }

    public class ManagerProduct:IManagerProduct
    {
        private readonly IProductRepository _productRepository;
        private readonly ITriggerChangeProduct _triggerChangeProduct;

        public ManagerProduct(IProductRepository productRepository, ITriggerChangeProduct triggerChangeProduct)
        {
            this._productRepository = productRepository;
            _triggerChangeProduct = triggerChangeProduct;
        }

        public void Update(IEnumerable<Product> products)
        {
            _productRepository.UpdateProducts(products);
            if (_triggerChangeProduct != null)
            {
                _triggerChangeProduct.CallTriggerAfterChange(products);
            }
        }

        public void Delete(IEnumerable<long> productIds)
        {
            _productRepository.DeleteProduct(productIds);
            if (_triggerChangeProduct != null)
            {
                _triggerChangeProduct.CallTriggerAfterChange(productIds, EEvent.Delete);
            }
        }

        public void Insert(IEnumerable<Product> products)
        {
            _productRepository.Insert(products);
            if (_triggerChangeProduct != null)
            {
                _triggerChangeProduct.CallTriggerAfterChange(products, EEvent.Insert);
            }
        }
    }

}
