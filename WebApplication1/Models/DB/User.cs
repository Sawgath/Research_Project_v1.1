using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.DB
{
    public class User
    {

        public int User_Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public int Active { get; set; }
        public string ActiveStartTime { get; set; }

        public string CreatedTime { get; set; }
    }
}