using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Extensions;
using WebApplication1.Models.DB;

namespace WebApplication1.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        public override User Delete(User tentity)
        {
            throw new NotImplementedException();
        }

        public override User Insert(User tentity)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"INSERT INTO [dbo].[User] VALUES (@Username,@Password,@Email,@Age,@Gender,@Salt,@Token)";
                command.Parameters.Add(command.CreateParameter("Password", tentity.Password));
                command.Parameters.Add(command.CreateParameter("Username", tentity.UserName));
                command.Parameters.Add(command.CreateParameter("Gender", tentity.Gender));
                command.Parameters.Add(command.CreateParameter("Age", tentity.Age));
                command.Parameters.Add(command.CreateParameter("Email", tentity.Email));
                //command.Parameters.Add(command.CreateParameter("UserId", tentity.User_Id));
                command.Parameters.Add(command.CreateParameter("Salt", tentity.Salt));
                command.Parameters.Add(command.CreateParameter("Token", tentity.Token));
                return this.ToList(command).FirstOrDefault();
            }
        }

        public override User Update(User tentity)
        {
            throw new NotImplementedException();
        }

        public User MakeActive(User tentity)
        {

            using (var command = _context.CreateCommand())
            {
                command.CommandText = "UPDATE[dbo].[User] SET [Active] = @Active, [ActiveStartTime] = @ActiveStartTime WHERE [User_Id] = @User_Id AND [Password] = @Password";

                command.Parameters.Add(command.CreateParameter("User_Id", tentity.User_Id));
                command.Parameters.Add(command.CreateParameter("Password", tentity.Password));
                return this.ToList(command).FirstOrDefault();
            }
        }

        public User TokenSaver(int userid, string token)
        {

            using (var command = _context.CreateCommand())
            {
                command.CommandText = "UPDATE[dbo].[User] SET [Token] = @Token WHERE [User_Id] = @User_Id";

                command.Parameters.Add(command.CreateParameter("User_Id", userid));
                command.Parameters.Add(command.CreateParameter("Token" , token));
                return this.ToList(command).FirstOrDefault();
            }
        }


        public bool CheckLoginData(User tentity)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [dbo].[User] where [User_Id]= @User_Id and [Password]=@Password ";

                command.Parameters.Add(command.CreateParameter("User_Id", tentity.User_Id));
                command.Parameters.Add(command.CreateParameter("Password", tentity.Password));
    
                int i = this.ToList(command).Count();

                if(i == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
        public IList<User> CheckExistingUser(string UserName, string email)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [dbo].[User] where [UserName]= @UserName and [Email]= @Email";
                command.Parameters.Add(command.CreateParameter("UserName", UserName));
                command.Parameters.Add(command.CreateParameter("Email", email));
                return ToList(command).ToList();
            }

        }
        public User GetUserID(string username)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [dbo].[User] where [UserName]= @UserName";
                command.Parameters.Add(command.CreateParameter("UserName", username));
                return ToList(command).First();
            }

        }
        public IList<User> ExistingUser(string UserName)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [dbo].[User] where [UserName]= @UserName";
                command.Parameters.Add(command.CreateParameter("UserName", UserName));
                return ToList(command).ToList();
            }

        }
        public IList<User> Retrurn_NewUser_OnRegister(string UserName)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [dbo].[User] where [UserName]= @UserName";
                command.Parameters.Add(command.CreateParameter("UserName", UserName));
                return ToList(command).ToList();
            }

        }

        public bool checktoken(string token, int user_id)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [dbo].[User] where [User_Id]= @User_Id and [Token]=@Token";
                command.Parameters.Add(command.CreateParameter("User_Id", user_id));
                command.Parameters.Add(command.CreateParameter("Token", token));

                int i = ToList(command).Count();
                if ( i==1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

        }
        public new IList<User> GetAll()
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM [dbo].[User]";
                return ToList(command).ToList();
            }
        }
    }
}