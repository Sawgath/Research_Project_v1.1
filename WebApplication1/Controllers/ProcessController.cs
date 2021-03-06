﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Helpers;
using WebApplication1.Models.JsonModel;

namespace WebApplication1.Controllers
{
    public class ProcessController : ApiController
    {
        [Authorize]
        // GET: api/Process
        [HttpPost]
        public HttpResponseMessage post(ProcessData processData)
        {
            HttpResponseMessage response = null;
            try
            {
                ProcessHelper processHelper = new ProcessHelper();
                processHelper.StopProcess(processData);
                var sessionScore = processHelper.RunAlgorithms(processData);
                response = Request.CreateResponse(HttpStatusCode.OK, sessionScore);
            }
            catch (Exception)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error");
            }

            return response;
        }

        

    }
}
