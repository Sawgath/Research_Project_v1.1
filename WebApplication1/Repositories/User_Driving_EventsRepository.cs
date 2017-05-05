using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            throw new NotImplementedException();
        }

        public override User_Driving_Events Update(User_Driving_Events tentity)
        {
            throw new NotImplementedException();
        }
    }
}