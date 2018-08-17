using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Vnet.Api.Poc.Api.Controllers
{
    public class FileController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage SaveFile()
        {
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count < 1 || !httpRequest.Form.HasKeys())
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            var filename = JsonConvert.DeserializeObject<filejson>(httpRequest.Form.GetValues("json").FirstOrDefault());

            foreach (string file in httpRequest.Files)
            {
                var postedFile = httpRequest.Files[file];
                var filePath = HttpContext.Current.Server.MapPath($"~/{filename.filename}");
                postedFile.SaveAs(filePath);
                // NOTE: To store in memory use postedFile.InputStream
            }
            
            return Request.CreateResponse(HttpStatusCode.Created,$"File name saved {filename.filename}");
        }
    }

    public class filejson
    {
        public string filename { get; set; }
    }
}