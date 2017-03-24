using System.Data;
using NUnit.Framework;
using Telerik.JustMock;
using Wss.Entities;
using Wss.Repository;

namespace Wss.RepositoryTests
{
    [TestFixture()]
    public class ProductRepositoryTests
    {

        [Test()]
        public void ShouldUpdateProductToSql()
        {
            ITriggerAfterChangeProduct triigTriggerAfterChangeProduct = Mock.Create<ITriggerAfterChangeProduct>();
            Mock.Arrange(() => triigTriggerAfterChangeProduct.SendProduct(Arg.IsAny<ChangeInfo>())).DoNothing();
            IProductRepository productRepository = new ProductRepository();
            productRepository.UpdateMainInfoProduct(100, "trang", 100);

        }


        [Test()]
        public void ShouldInsertProductToSql()
        {
            ITriggerAfterChangeProduct triigTriggerAfterChangeProduct = Mock.Create<ITriggerAfterChangeProduct>();
            Mock.Arrange(() => triigTriggerAfterChangeProduct.SendProduct(Arg.IsAny<ChangeInfo>())).DoNothing();
            IProductRepository productRepository = new ProductRepository();
            productRepository.InsertProduct(100, "trang", 100);

        }

        [Test()]
        public void ShouldCallTriggerAfterChangeInfoProduct()
        {

           

        }
    }
}
