using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.Models.DB;
using WebApplication1.Repositories;

namespace WebApplication1.Helpers
{
    public class LoginHelpers
    {


        public LoginHelpers(LoginData alogin)
        {
            User aUser = new User();

            aUser.User_Id = alogin.User_Id;
            aUser.Password = alogin.Password;
            aUser.Active = (alogin.Active == "YES") ? 1 : 0;
            aUser.ActiveStartTime = DateTime.UtcNow.ToString("o");


            var factory = new DbConnectionFactory("testDatabase");
            var context = new DbContext(factory);
            UserRepository arepo = new UserRepository(context);

            //arepo.CheckLoginData(aUser);
            if (arepo.CheckLoginData(aUser))
            {
                arepo.MakeActive(aUser);

            }


        }
        

    }
}