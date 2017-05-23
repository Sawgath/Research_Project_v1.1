using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Extensions;
using WebApplication1.Models.DB;

namespace WebApplication1.Repositories
{
    public class Session_HistoryRepository : Repository<Session_History>
    {
        public Session_HistoryRepository(DbContext context) : base(context)
        {
        }

        public override Session_History Delete(Session_History tentity)
        {
            throw new NotImplementedException();
        }

        public override Session_History Insert(Session_History tentity)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = "INSERT INTO [dbo].[Session_History](Session_Id, User_Id, Start_Time) "+
                                    " VALUES(@Session_Id, @User_Id, @Start_Time)";

                command.Parameters.Add(command.CreateParameter("User_Id", tentity.User_Id));
                command.Parameters.Add(command.CreateParameter("Session_Id", tentity.Session_Id));
                //command.Parameters.Add(command.CreateParameter("Data_Id", tentity.Data_Id));
                command.Parameters.Add(command.CreateParameter("Start_Time", tentity.Start_time));
                
                return this.ToList(command).FirstOrDefault();

            }
        }

        public override Session_History Update(Session_History tentity)
        {
            throw new NotImplementedException();
        }

        public bool checkSession(string sessionid)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = "SELECT [Session_Id] FROM [dbo].[Session_History] WHERE [Session_Id]=@sessionid";
                command.Parameters.Add(command.CreateParameter("sessionid", sessionid));

                int i = this.ToList(command).Count();

                if (i == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

        }
    }
}