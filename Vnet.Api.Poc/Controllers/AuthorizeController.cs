using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vnet.Api.Poc.Authorization;

namespace Vnet.Api.Poc.Api.Controllers
{
    [RoutePrefix("api/Authorize")]
    public class AuthorizeController : ApiController
    {
        //Create jwt that other methods use for auth
        [HttpGet]
        public HttpResponseMessage GetToken(string client)
        {
            try
            {
                var claims = new Dictionary<string, string>
                {
                    {"client", client},
                    {"exp", DateTimeOffset.Now.AddMinutes(5).ToUnixTimeSeconds().ToString()}
                };
                return Request.CreateResponse(HttpStatusCode.Accepted,
                    JwtUtilities.GenerateToken(claims, ConfigurationManager.AppSettings["Jwtsecret"]));
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [Route("Refresh")]
        [HttpGet]
        [JwtAuthorization]
        public HttpResponseMessage RefreshToken()
        {
            try
            {
                var token = JwtUtilities.FetchFromHeader(ActionContext);
                return Request.CreateResponse(HttpStatusCode.Accepted,
                    JwtUtilities.RefreshToken(token, ConfigurationManager.AppSettings["Jwtsecret"]));
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}