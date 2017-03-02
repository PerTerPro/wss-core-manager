using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wss.Bll;
using NUnit.Framework;
using Telerik.JustMock;
using Wss.Entities;
using Wss.Repository;

namespace Wss.Bll.Tests
{
    [TestFixture()]
    public class ProductBllTests
    {
        [Test]
        public void ShouldGetProductsOfCompany()
        {
            
        }

        [Test()]
        public void ShouldBeCallInsertOfRepositoryOneTimeWhenInsertProduct()
        {
            var repository = Mock.Create<IProductRepository>();
            Mock.Arrange(() => repository.Insert(Arg.IsAny<Product>())).DoNothing();
            ProductBll productBll = new ProductBll(repository, null, null);
            productBll.InsertProduct(new Product()
            {
            });
            Mock.Assert(() => repository.Insert(Arg.IsAny<Product>()), Occurs.Once());
        }

        [Test()]
        public void ShouldBeCallDeleteOfRepositoryOneTimeWhenDeleteProduct()
        {
            var repository = Mock.Create<IProductRepository>();
            Mock.Arrange(() => repository.Delete(Arg.IsAny<long>())).DoNothing();
            ProductBll productBll = new ProductBll(repository, null, null);
            productBll.DeleteById(100);
            Mock.Assert(() => repository.Delete(Arg.IsAny<long>()), Occurs.Once());
        }

        [Test()]
        public void ShouldBeCallTriggerBeforeInsertOneTimeWhenInsertProductWithTriggerBefore()
        {
            var repository = Mock.Create<IProductRepository>();
            Mock.Arrange(() => repository.Insert(Arg.IsAny<Product>())).DoNothing();

            var triggerBefore = Mock.Create<ITriggerBeforeChangeProduct>();
            Mock.Arrange(() => triggerBefore.TriggerInsert(Arg.IsAny<Product>())).DoNothing();

            ProductBll productBll = new ProductBll(repository, triggerBefore, null);
            productBll.InsertProduct(new Product());

            Mock.Assert(() => triggerBefore.TriggerInsert(Arg.IsAny<Product>()), Occurs.Once());
        }

           [Test()]
        public void ShouldBeCallTriggerAfterUpdateOneTimeForCrawlerInfoProduct()
        {
            var repository = Mock.Create<IProductRepository>();
            Mock.Arrange(() => repository.UpdateCrawlInfo(Arg.IsAny<Product>())).DoNothing();
            ITriggerAfterChangeProduct triggerAfter = Mock.Create<ITriggerAfterChangeProduct>();
            Mock.Arrange(() => triggerAfter.TriggerUpdate(Arg.IsAny<Product>())).DoNothing();
            ProductBll productBll = new ProductBll(repository, null, triggerAfter);
            productBll.UpdateCrawlInfoProduct(new Product());
            Mock.Assert(() => triggerAfter.TriggerUpdate(Arg.IsAny<Product>()), Occurs.Once());
        }

        [Test()]
        public void ShouldBeCallTriggerBeforeUpdateOneTimeBeforeUpdateCrawlInfoProduct()
        {
            var repository = Mock.Create<IProductRepository>();
            Mock.Arrange(() => repository.UpdateCrawlInfo(Arg.IsAny<Product>())).DoNothing();
            var triggerBefore = Mock.Create<ITriggerBeforeChangeProduct>();
            Mock.Arrange(() => triggerBefore.TriggerUpdate(Arg.IsAny<Product>())).DoNothing();

            ProductBll productBll = new ProductBll(repository, triggerBefore, null);
            productBll.UpdateCrawlInfoProduct(new Product());

            Mock.Assert(() => triggerBefore.TriggerUpdate(Arg.IsAny<Product>()), Occurs.Once());
        }

        [Test()]
        public void ShouldBeCallTriggerBeforeDeleteOneTimeBeforeDeleteCrawlInfoProduct()
        {
            var repository = Mock.Create<IProductRepository>();
            Mock.Arrange(() => repository.Delete(Arg.IsAny<long>())).DoNothing();
            var triggerBefore = Mock.Create<ITriggerBeforeChangeProduct>();
            Mock.Arrange(() => triggerBefore.TriggerUpdate(Arg.IsAny<Product>())).DoNothing();

            ProductBll productBll = new ProductBll(repository, triggerBefore, null);
            productBll.DeleteById(0);

            Mock.Assert(() => triggerBefore.TriggerDelete(Arg.IsAny<Product>()), Occurs.Once());
        }
    }
}
