using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vnet.Api.Poc.Authorization;
using Vnet.Api.Poc.Business.Factory;

namespace Vnet.Api.Poc.Api.Controllers
{
    public class CartController : ApiController
    {
        [JwtAuthorization]
        [HttpGet]
        public HttpResponseMessage GetCarts()
        {
            try
            {
                //Get required data from the jwt token
                var client = JwtUtilities.GetFromClaimToken(Request, "client");

                //Call the factory to get the correct business logic
                var operations = CartFactory.CreateOperations(client);

                //Return the value from the business logic
                return Request.CreateResponse(HttpStatusCode.Accepted, operations.GetCarts());
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