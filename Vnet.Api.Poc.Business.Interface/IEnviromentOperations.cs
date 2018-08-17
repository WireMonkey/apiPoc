using System.Collections.Generic;

namespace Vnet.Api.Poc.Business.Interface
{
    public interface IEnviromentOperations
    {
        List<object> GetAllSettings();
        object GetSetting(string code);

    }
}