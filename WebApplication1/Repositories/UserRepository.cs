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
            throw new NotImplementedException();
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
                command.Parameters.Add(command.CreateParameter("Active", tentity.Active));
                command.Parameters.Add(command.CreateParameter("ActiveStartTime", tentity.ActiveStartTime));


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