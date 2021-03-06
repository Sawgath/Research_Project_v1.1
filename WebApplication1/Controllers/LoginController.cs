﻿using System;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using WebApplication1.Models;
using WebApplication1.Helpers;
using System.Data.SqlClient;

namespace WebApplication1.Controllers
{
    public class LoginController : ApiController
    {

        [HttpGet]
        public UserLogin Get()
        {
            UserLogin alogin = new UserLogin();
            alogin.UserName = "K2";
            alogin.Password = "MAC";
            //alogin.Active = "YES";
            return alogin;
        }
        //[Route("api/Login/signin")]

        [HttpPost]
        public HttpResponseMessage Login( UserLogin model)
        {
            HttpResponseMessage response = null;

            if (ModelState.IsValid)
            {
                try
                {
                    LoginHelpers User = new LoginHelpers();
                    var existingUser = User.CheckUser(model);
                    if (existingUser.Count == 0)
                    {
                        response = Request.CreateResponse(HttpStatusCode.NotFound, "User Doesn't exist.");
                    }
                    else
                    {
                        if ((!String.IsNullOrWhiteSpace(model.UserName))&&(!String.IsNullOrWhiteSpace(model.Password)))
                        {
                            var loginSuccess =
                              string.Equals(EncryptPassword(model.Password, existingUser[0].Salt),
                                  existingUser[0].Password);

                            if (loginSuccess)
                            {
                                response = Request.CreateResponse(new { existingUser[0].User_Id, existingUser[0].UserName, existingUser[0].Token } );
                            }
                            else
                            {
                                response = Request.CreateResponse(HttpStatusCode.Forbidden,"Please Provide correct User Credentials");
                            }
                        }
                        else
                        {
                            response = Request.CreateResponse(HttpStatusCode.Forbidden, "Password or Username not provided");
                        }
                    }
                    
                }
                catch (SqlException)
                {
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            }
                return response;
            }
        
        public static string EncryptPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = string.Format("{0}{1}", salt, password);
                var saltedPasswordAsBytes = Encoding.UTF8.GetBytes(saltedPassword);
                return Convert.ToBase64String(sha256.ComputeHash(saltedPasswordAsBytes));
            }
        }
    }
}
