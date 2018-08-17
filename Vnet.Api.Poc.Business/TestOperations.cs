namespace Vnet.Api.Poc.Business
{
    public class TestOperations : BaseOperations
    {
        private static string _client;

        public TestOperations(string client)
        {
            _client = client;
        }

        public override string GetValues()
        {
            return "test";
        }
    }
}
