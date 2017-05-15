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
                command.CommandText = @"INSERT INTO [dbo].[User] VALUES (@Username,@Password,@Email,@Age,@Gender,@Salt)";
                command.Parameters.Add(command.CreateParameter("Password", tentity.Password));
                command.Parameters.Add(command.CreateParameter("Username", tentity.UserName));
                command.Parameters.Add(command.CreateParameter("Gender", tentity.Gender));
                command.Parameters.Add(command.CreateParameter("Age", tentity.Age));
                command.Parameters.Add(command.CreateParameter("Email", tentity.Email));
                //command.Parameters.Add(command.CreateParameter("UserId", tentity.User_Id));
                command.Parameters.Add(command.CreateParameter("Salt", tentity.Salt));
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
                //command.Parameters.Add(command.CreateParameter("Active", tentity.Active));
                //command.Parameters.Add(command.CreateParameter("ActiveStartTime", tentity.ActiveStartTime));


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
        public IList<User> CheckExistingUser(string email)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [dbo].[User] where [Email]= @Email";
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