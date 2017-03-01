using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wss.Repository.Basic;
using NUnit.Framework;
namespace Wss.Repository.Basic.Tests
{
    [TestFixture()]
    public class ProductRepositoryTests
    {
        [Test()]
        public void GetByIdTest()
        {
            IDbConnection connection = new SqlConnection(@"Data Source=42.112.28.93;Initial Catalog=QT_2;Persist Security Info=True;User ID=wss_price;Password=HzlRt4$$axzG-*UlpuL2gYDu;connection timeout=200");
            ProductRepository productRepository = new ProductRepository(connection);
            var x = productRepository.GetById(35589);
            Assert.IsNotNull(x);
        }
    }
}
