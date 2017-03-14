using System.Data;
using NUnit.Framework;
using Wss.Repository;
using Wss.Repository.Product;

namespace Wss.RepositoryTests
{
    [TestFixture()]
    public class ProductRepositoryTests
    {
        [Test()]
        public void ShouldBeReturnProductsOfCompany()
        {
            ProductRepository productRepository = new ProductRepository();
        }
    }
}
