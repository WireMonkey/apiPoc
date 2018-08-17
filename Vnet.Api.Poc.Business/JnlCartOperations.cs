using System.Collections.Generic;
using System.Linq;
using Vnet.Api.Poc.Data.Entities.Jnl;
using Vnet.Api.Poc.Data.Factory;

namespace Vnet.Api.Poc.Business
{
    public class JnlCartOperations : CartOperations
    {
        private readonly string _client;

        public JnlCartOperations(string client)
        {
            _client = client;
        }
        public override List<dynamic> GetCarts()
        {
            //For nested linq queries the dynamic context can't be used the exact context must be used
            using (var context = (JNLSuperFulfillmentEntities)EntityFactory.CreteContext(_client))
            {
                var carts = (from sc in context.CartSaveds
                    select new
                    {
                        id = sc.CartSavedID,
                        name = sc.SavedName,
                        carts = (from c in context.Carts
                                 where c.CartSavedID == sc.CartSavedID
                                 select c).ToList()
                    }).Take(100).ToList();

                return carts.Select(x =>
                {
                    dynamic cart = x;
                    return cart;
                }).ToList();
            }
        }
    }
}