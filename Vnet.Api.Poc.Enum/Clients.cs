using System;

/// <summary>
/// 
/// </summary>
namespace Vnet.Api.Poc.Enum
{
    public class clients
    {
        public enum apiClients
        {
            test,
            basic,
            jnl,
            abc,
            kaiser
        };

        public static apiClients cast(string client)
        {
            var c = apiClients.abc;
            if (System.Enum.TryParse(client, out c))
            {
                return c;
            }
            else
            {
                throw new NotImplementedException($"Operations for client {client} has not been implamented.");
            }

        }
    }
}
