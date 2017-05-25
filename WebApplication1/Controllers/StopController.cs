using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Helpers;
using WebApplication1.Models.JsonModel;

namespace WebApplication1.Controllers
{
    public class StopController : ApiController
    {
        // POST: api/Stop
        [HttpPost]
        public HttpResponseMessage post(ProcessData processData)
        {
            HttpResponseMessage response = null;
            try
            {
                ProcessHelper processHelper = new ProcessHelper();
                processHelper.StopProcess(processData);
                response = Request.CreateResponse(HttpStatusCode.OK, "Success");
            }
            catch (Exception)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error");
            }

            return response;
        }
    }
}
