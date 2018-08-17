using System;
using Vnet.Api.Poc.Data.Entities.Abc;
using Vnet.Api.Poc.Data.Entities.Jnl;
using Vnet.Api.Poc.Data.Entities.kaiser;
using Vnet.Api.Poc.Enum;

namespace Vnet.Api.Poc.Data.Factory
{
    public class EntityFactory
    {
        //Using dynamic any entity framework object can be pulled
        //The only downside is that this breaks intelisence
        public static dynamic CreteContext(string client)
        {
            switch (clients.cast(client))
            {
                case clients.apiClients.abc:
                    return new  ABCEntities();
                case clients.apiClients.jnl:
                    return new JNLSuperFulfillmentEntities();
                case clients.apiClients.kaiser:
                    return new KaiserPermanenteEntities();
                default:
                    throw new NotImplementedException($"Entity for client {client} has not been implamented.");
            }
        }
    }
}