using System.Collections.Generic;
using System.Linq;
using Vnet.Api.Poc.Business.Interface;
using Vnet.Api.Poc.Data.Factory;

namespace Vnet.Api.Poc.Business
{
    public class EnviromentOperations : IEnviromentOperations
    {
        private readonly string _client;
        public EnviromentOperations(string client)
        {
            _client = client;
        }

        public EnviromentOperations() { }

        public List<object> GetAllSettings()
        {
            using (var context = EntityFactory.CreteContext(_client))
            {
                //Must be cast to ienumerable to allow for linq queries against
                //Downside is that this breaks intelisense
                return ((IEnumerable<dynamic>)context.EnvironmentSettings).ToList();
            }
        }

        public object GetSetting(string code)
        {
            using (var context = EntityFactory.CreteContext(_client))
            {
                return ((IEnumerable<dynamic>) context.EnvironmentSettings).Where(y => y.Code == code).ToList();
            }
            
        }
    }
}