using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Extensions;
using WebApplication1.Models.DB;


namespace WebApplication1.Repositories
{
    public class User_Driving_EventsRepository : Repository<User_Driving_Events>
    {
        public User_Driving_EventsRepository(DbContext context) : base(context)
        {
        }

        public override User_Driving_Events Delete(User_Driving_Events tentity)
        {
            throw new NotImplementedException();
        }

        public override User_Driving_Events Insert(User_Driving_Events tentity)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = "INSERT INTO [dbo].[User_Driving_Events]([Event_Time],[Session_Id],[Event_Type_Id])" +
                                    " VALUES(@Event_Time,@Session_Id,@Event_Type_Id)";
                command.Parameters.Add(command.CreateParameter("Event_Time", tentity.Event_Time));
                command.Parameters.Add(command.CreateParameter("Event_Type_Id", tentity.Event_Type_Id));
                command.Parameters.Add(command.CreateParameter("Session_Id", tentity.Session_Id));
                return this.ToList(command).FirstOrDefault();

            }

        }

        public override User_Driving_Events Update(User_Driving_Events tentity)
        {
            throw new NotImplementedException();
        }
    }
}