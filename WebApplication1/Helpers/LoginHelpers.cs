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
        public void LoginHelper(LoginData alogin)
        {
            User aUser = new User();
            aUser.User_Id = alogin.User_Id;
            aUser.Password = alogin.Password;
            //aUser.Active = (alogin.Active == "YES") ? 1 : 0;
            //aUser.ActiveStartTime = DateTime.UtcNow.ToString("o");
            var factory = new DbConnectionFactory("testDatabase");
            var context = new DbContext(factory);
            UserRepository arepo = new UserRepository(context);
            //arepo.CheckLoginData(aUser);
            if (arepo.CheckLoginData(aUser))
            {
                arepo.MakeActive(aUser);

            }
        }
        public IList<User> RegisterHelpers(UserRegister userdata)
        {
            User user = new User();
            user.User_Id = userdata.User_Id;
            user.UserName = userdata.UserName;
            user.Password = userdata.Password;
            user.Age = userdata.Age;
            user.Gender = userdata.Gender;
            user.Email= userdata.Email; 
            var factory = new DbConnectionFactory("testDatabase");
            var context = new DbContext(factory);
            UserRepository arepo = new UserRepository(context);
            IList<User> existinguserlist= arepo.CheckExistingUser(user.UserName,user.Email).ToList();
            return existinguserlist;
        }
        public IList<User> CheckUser(UserLogin userdata)
        {
            User user = new User();
            user.UserName = userdata.UserName;
            user.Password = userdata.Password;
            var factory = new DbConnectionFactory("testDatabase");
            var context = new DbContext(factory);
            UserRepository arepo = new UserRepository(context);
            IList<User> existinguserlist = arepo.ExistingUser(user.UserName).ToList();
            return existinguserlist;
        }
        public void SaveNewUser(User NewUser)
        {
            var factory = new DbConnectionFactory("testDatabase");
            var context = new DbContext(factory);
            UserRepository arepo = new UserRepository(context);
            arepo.Insert(NewUser);
        }

        public List<User> ReturnNewUSer(string username)
        {
            var factory = new DbConnectionFactory("testDatabase");
            var context = new DbContext(factory);
            UserRepository arepo = new UserRepository(context);
            var newuser= arepo.Retrurn_NewUser_OnRegister(username);
            return newuser.ToList();
            
        }

        public void SaveToken(int user_id, string token)
        {
            var factory = new DbConnectionFactory("testDatabase");
            var context = new DbContext(factory);
            UserRepository arepo = new UserRepository(context);
            var newuser = arepo.TokenSaver(user_id, token);
            
        }

        public bool checktokens(string token, int user_id)
        {
            var factory = new DbConnectionFactory("testDatabase");
            var context = new DbContext(factory);
            UserRepository arepo = new UserRepository(context);
            var newuser = arepo.checktoken(token, user_id);
            return newuser;

        }

    }
}