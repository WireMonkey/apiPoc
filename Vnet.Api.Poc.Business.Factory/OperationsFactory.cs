using System;
using Vnet.Api.Poc.Business.Interface;
using Vnet.Api.Poc.Enum;

namespace Vnet.Api.Poc.Business.Factory
{
    public class OperationsFactory
    {
        public static IOperations CreateOperations(string client)
        {
            //Using switch the specific class can be created for a givin client
            //If the client only uses generic operations then the base can be used
            //The client specific code needs to only ovride the methods that are diferent
            switch (clients.cast(client))
            {
                case clients.apiClients.test:
                    return new TestOperations(client);
                case clients.apiClients.basic:
                    return new BaseOperations(client);
                case clients.apiClients.jnl:
                    return new SqlOperations(client);
                case clients.apiClients.abc:
                    return new SqlOperations(client);
                case clients.apiClients.kaiser:
                    return new SqlOperations(client);
                default:
                    throw new NotImplementedException($"Operations for client {client} has not been implamented.");
            }
        }
    }
}
