using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using WebApplication1.Models;
using WebApplication1.Models.DB;
using WebApplication1.Helpers;
using JWT;
using JWT.Serializers;
using JWT.Algorithms;
using System.Web.Script.Serialization;

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
        public HttpResponseMessage Login(UserLogin model)
        {
            HttpResponseMessage response = null;
            if (ModelState.IsValid)
            {
                LoginHelpers User = new LoginHelpers();
                var existingUser = User.CheckUser(model);
                if (existingUser.Count == 0)
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "User Doesn't exist.");
                }
                else
                {
                    var loginSuccess =
                        string.Equals(EncryptPassword(model.Password, existingUser[0].Salt),
                            existingUser[0].Password);

                    if (loginSuccess)
                    {
                        object dbUser;
                        var token = CreateToken(existingUser[0], out dbUser);
                        response = Request.CreateResponse(new { dbUser, token } + "Login Sucessful");
                    }
                }
            }
            else
            {
                response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            return response;
        }

        private static string CreateToken(User user, out object dbUser)
        {
            var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var expiry = Math.Round((DateTime.UtcNow.AddHours(2) - unixEpoch).TotalSeconds);
            var issuedAt = Math.Round((DateTime.UtcNow - unixEpoch).TotalSeconds);
            var notBefore = Math.Round((DateTime.UtcNow.AddMonths(6) - unixEpoch).TotalSeconds);
            var payload = new Dictionary<string, object>
            {
                {"username", user.UserName},
                {"userId", user.User_Id},
                {"nbf", notBefore},
                {"iat", issuedAt},
                {"exp", expiry}
            };

            //var secret = ConfigurationManager.AppSettings.Get("jwtKey");
            var secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            var token = encoder.Encode(payload, secret);
            dbUser = new { user.UserName};
            //var jsonSerializer = new JavaScriptSerializer();
            //var jsonPayload = JWT.JsonWebToken.Decode(token,secret);
            //var payloadData = jsonSerializer.Deserialize<Dictionary<string, object>>(jsonPayload);
            //return payloadData;
            return token;
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
