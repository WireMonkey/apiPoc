using Vnet.Api.Poc.Data.Factory;

namespace Vnet.Api.Poc.Business
{
    public class SqlOperations : BaseOperations
    {
        private static string _client;

        public SqlOperations(string client)
        {
            _client = client;
        }

        public override string GetValues()
        {
            using (var context = EntityFactory.CreteContext(_client))
            {
                return context.Database.Connection.ConnectionString;
            }
        }
    }
}