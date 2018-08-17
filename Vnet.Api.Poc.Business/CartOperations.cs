using System.Collections.Generic;
using System.Linq;
using Vnet.Api.Poc.Business.Interface;
using Vnet.Api.Poc.Data.Factory;

namespace Vnet.Api.Poc.Business
{
    public class CartOperations : ICartOperations
    {
        private readonly string _client;
        public CartOperations() { }

        public CartOperations(string client)
        {
            _client = client;
        }

        public virtual List<dynamic> GetCarts()
        {
            using (var context = EntityFactory.CreteContext(_client))
            {
                return ((IEnumerable<dynamic>) context.Carts).Take(100).Select(x =>
                {
                    dynamic cart = x;
                    return cart;
                }).ToList();
            }
        }
    }
}