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
using System.Data.SqlClient;

namespace WebApplication1.Controllers
{
    public class AccountController : ApiController
    {
        [AllowAnonymous]
        [HttpPost]
        public HttpResponseMessage Register(UserRegister model)
        {
            HttpResponseMessage response;
            try
            {
                if (ModelState.IsValid)
                {

                    LoginHelpers User = new LoginHelpers();
                    var existingUser = User.RegisterHelpers(model);
                    if (existingUser.Count != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "User already exist.");
                    }
                    else
                    {
                        //Create user and save to database
                        var user = CreateUser(model);
                        object dbUser;
                        //Create token
                        var token = CreateToken(user[0], out dbUser);
                        User.SaveToken(user[0].User_Id, token);
                        response = Request.CreateResponse(new { dbUser, token });
                    }
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, new { success = false });
                }
            }
                catch(SqlException)
                 {
                    response= Request.CreateResponse("Feilds Missing");
                 }
            return response;
        }
        private static string CreateToken(User user, out object dbUser)
        {
            var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var secondsSinceEpoch = Math.Round((DateTime.UtcNow - unixEpoch).TotalSeconds);
            var expiry = Math.Round((DateTime.UtcNow.AddYears(10) - unixEpoch).TotalSeconds);
            var issuedAt = Math.Round((DateTime.UtcNow - unixEpoch).TotalSeconds);
            var notBefore = Math.Round((DateTime.UtcNow - unixEpoch).TotalSeconds);
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
            dbUser = new { user.User_Id, user.UserName};
            return token;
        }

        /// Create a new user and saves it to the database
        private IList<User> CreateUser(UserRegister NewUser)
        {
            LoginHelpers Newuser = new LoginHelpers();
            var passwordSalt = CreateSalt();
            var user = new User
            {
                Email = NewUser.Email,
                Password = EncryptPassword(NewUser.Password, passwordSalt),
                UserName = NewUser.UserName,
                Age = NewUser.Age,
                Gender = NewUser.Gender,
                Salt = passwordSalt,
                Token = ""
            };
            Newuser.SaveNewUser(user);
            var newUSer = Newuser.ReturnNewUSer(user.UserName);
            return newUSer;
        }

        /// Creates a random salt to be used for encrypting a password
        public static string CreateSalt()
        {
            var data = new byte[0x10];
            using (var cryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                cryptoServiceProvider.GetBytes(data);
                return Convert.ToBase64String(data);
            }
        }

        ///Encrypts a password using the given salt
        public static string EncryptPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                if (password != null)
                {
                    var saltedPassword = string.Format("{0}{1}", salt, password);
                    var saltedPasswordAsBytes = Encoding.UTF8.GetBytes(saltedPassword);
                    return Convert.ToBase64String(sha256.ComputeHash(saltedPasswordAsBytes));
                }
                else
                {
                    return null;

                }
            }
        }
    }
}
