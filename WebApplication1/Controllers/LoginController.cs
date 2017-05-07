using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Helpers;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class LoginController : ApiController
    {

        [HttpGet]
        public LoginData Get()
        {
            LoginData alogin = new LoginData();
            alogin.User_Id = 1;
            alogin.Password = "MAC";
            alogin.Active = "YES";

            return alogin;

        }

        [HttpPost]
        public void post(LoginData alogin)
        {

            LoginHelpers aLoginHelpers = new LoginHelpers(alogin);

        }

    }
}
