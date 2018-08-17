using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vnet.Api.Poc.Authorization;
using Vnet.Api.Poc.Business.Factory;

namespace Vnet.Api.Poc.Api.Controllers
{
    public class ValuesController : ApiController
    {
        [JwtAuthorization]//Makes the call require jwt validation
        [HttpGet]//Http verb that the call uses
        public HttpResponseMessage Get()
        {
            try
            {
                //Get required data from the jwt token
                var client = JwtUtilities.GetFromClaimToken(Request, "client");
                
                //Call the factory to get the correct business logic
                var operations = OperationsFactory.CreateOperations(client);

                //Return the value from the business logic
                return Request.CreateResponse(HttpStatusCode.Accepted,operations.GetValues());
            }
            catch (Exception e)
            {
                //Handle all error is code gracefully and let the front end know that something happened
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    $"An error occured getting information. Error:{e.Message}");
            }
        }
    }
}
