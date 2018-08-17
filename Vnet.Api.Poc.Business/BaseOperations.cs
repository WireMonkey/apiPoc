using Vnet.Api.Poc.Business.Interface;

namespace Vnet.Api.Poc.Business
{
    //All shared logic can go here
    public class BaseOperations : IOperations
    {
        private static string _client;

        public BaseOperations() { }

        public BaseOperations(string client)
        {
            _client = client;
        }

        public virtual string GetValues()
        {
            return "base";
        }
    }
}
