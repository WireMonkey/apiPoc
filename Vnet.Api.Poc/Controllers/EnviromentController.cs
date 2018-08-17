using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vnet.Api.Poc.Authorization;
using Vnet.Api.Poc.Business.Factory;

namespace Vnet.Api.Poc.Api.Controllers
{
    public class EnviromentController : ApiController
    {
        [JwtAuthorization]
        [HttpGet]
        public HttpResponseMessage GetAllSettings()
        {
            try
            {
                //Get required data from the jwt token
                var client = JwtUtilities.GetFromClaimToken(Request, "client");

                //Call the factory to get the correct business logic
                var operations = EnviromentFactory.CreateOperations(client);

                //Return the value from the business logic
                return Request.CreateResponse(HttpStatusCode.Accepted, operations.GetAllSettings());
            }
            catch (Exception e)
            {
                //Handle all error is code gracefully and let the front end know that something happened
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    $"An error occured getting information. Error:{e.Message}");
            }
        }

        [JwtAuthorization]
        [HttpGet]
        public HttpResponseMessage GetAllSettings(string code)
        {
            try
            {
                //Get required data from the jwt token
                var client = JwtUtilities.GetFromClaimToken(Request, "client");

                //Call the factory to get the correct business logic
                var operations = EnviromentFactory.CreateOperations(client);

                //Return the value from the business logic
                return Request.CreateResponse(HttpStatusCode.Accepted, operations.GetSetting(code));
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