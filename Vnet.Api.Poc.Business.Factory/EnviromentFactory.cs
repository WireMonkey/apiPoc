using System;
using Vnet.Api.Poc.Business.Interface;

namespace Vnet.Api.Poc.Business.Factory
{
    public class EnviromentFactory
    {
        public static IEnviromentOperations CreateOperations(string client)
        {
            switch (client.ToLower())
            {
                case "jnl":
                    return new EnviromentOperations(client);
                case "abc":
                    return new EnviromentOperations(client);
                case "kaiser":
                    return new EnviromentOperations(client);
                default:
                    throw new NotImplementedException($"Enviroment operations for client {client} has not been implamented.");
            }
        }
    }
}