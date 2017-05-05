using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models.DB;

namespace WebApplication1.Repositories
{
    public class Event_TypesRepository : Repository<Event_Type>
    {
        public Event_TypesRepository(DbContext context) : base(context)
        {
        }

        public override Event_Type Delete(Event_Type tentity)
        {
            throw new NotImplementedException();
        }

        public override Event_Type Insert(Event_Type tentity)
        {
            throw new NotImplementedException();
        }

        public override Event_Type Update(Event_Type tentity)
        {
            throw new NotImplementedException();
        }
    }
}