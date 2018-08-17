using System;
using Vnet.Api.Poc.Business.Interface;

namespace Vnet.Api.Poc.Business.Factory
{
    public class CartFactory
    {
        public static ICartOperations CreateOperations(string client)
        {
            switch (client.ToLower())
            {
                case "jnl":
                    return new JnlCartOperations(client);
                case "abc":
                    return new CartOperations(client);
                case "kaiser":
                    return new CartOperations(client);
                default:
                    throw new NotImplementedException($"Cart operations for client {client} has not been implamented.");
            }
        }
    }
}