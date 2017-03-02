using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wss.Bll;
using NUnit.Framework;
using Telerik.JustMock;
using Wss.Entities;
using Wss.Repository.Basic;

namespace Wss.Bll.Tests
{
    [TestFixture()]
    public class ProductBllTests
    {
       

        [Test()]
        public void ShouldBeCallInsertOfRepositoryOneTimeWhenInsertProduct()
        {
            var repository = Mock.Create<IRepository<Product>>();
            Mock.Arrange(() => repository.Insert(Arg.IsAny<Product>())).DoNothing();
            ProductBll productBll = new ProductBll(repository, null, null);
            productBll.InsertProduct(new Product()
            {
            });
            Mock.Assert(() => repository.Insert(Arg.IsAny<Product>()), Occurs.Once());
        }

        [Test()]
        public void ShouldBeCallTriggerBeforeInsertOneTimeWhenInsertProductWithTriggerBefore()
        {
            var repository = Mock.Create<IRepository<Product>>();
            Mock.Arrange(() => repository.Insert(Arg.IsAny<Product>())).DoNothing();

            var triggerBefore = Mock.Create<ITriggerBeforeChange>();
            Mock.Arrange(() => triggerBefore.TriggerInsert(Arg.IsAny<Product>())).DoNothing();

            ProductBll productBll = new ProductBll(repository, triggerBefore, null);
            productBll.InsertProduct(new Product()
            {
            });

            Mock.Assert(() => triggerBefore.TriggerInsert(Arg.IsAny<Product>()), Occurs.Once());
        }

         [Test()]
        public void ShouldBeCallCallTriggerBeforeUpdateOneTimeBeforeUpdateCrawlInfoProduct()
        {
            var repository = Mock.Create<IRepository<Product>>();
            Mock.Arrange(() => repository.UpdateCrawlInfo(Arg.IsAny<Product>())).DoNothing();
            var triggerBefore = Mock.Create<ITriggerBeforeChange>();
            Mock.Arrange(() => triggerBefore.TriggerUpdate(Arg.IsAny<Product>())).DoNothing();

            ProductBll productBll = new ProductBll(repository, triggerBefore, null);
            productBll.UpdateCrawlInfoProduct(new Product());

            Mock.Assert(() => triggerBefore.TriggerUpdate(Arg.IsAny<Product>()), Occurs.Once());
        }
    }
}
