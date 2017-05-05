using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    }
}