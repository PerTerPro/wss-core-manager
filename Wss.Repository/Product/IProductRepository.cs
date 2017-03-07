using System;
using System.Collections.Generic;
using Wss.Entities;

namespace Wss.Repository
{
    public interface IProductRepository:IRepository<Entities.Product>
    {
        void SetValidProduct(long productId, bool isValid);
        
        void UpdateProductByCrawler(Entities.Product product);

        /// <summary>
        /// Tuple. ProductId-ImageOld-ImageNew
        /// </summary>
        /// <param name="imageProducts"></param>
        void UpdateImageBatch(List<Tuple<long, string, string>> imageProducts);

        IEnumerable<Entities.Product> GetProductsForCacheCrawler(long companyId, int pageIndex, int rowInPage);

        void UpdateProducts(IEnumerable<Entities.Product> products);

        void DeleteProduct(IEnumerable<long> productIds);

        void Insert(IEnumerable<Entities.Product> product);

        void UpdateImageBatch(IEnumerable<ImageProductInfo> imageProductInfos);
    }

}
