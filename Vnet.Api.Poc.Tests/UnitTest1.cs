using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vnet.Api.Poc.Data.Entities.Jnl;

namespace Vnet.Api.Poc.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var x = new JNLSuperFulfillmentEntities();
            x.Carts.Take(100).ToList();
        }
        
    }
}
