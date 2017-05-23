using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.DB
{
    public class Session_History
    {
        public int User_Id { get; set; }
        public string Session_Id { get; set; }
        public DateTime Start_time { get; set; }
        public DateTime End_time { get; set; }
    }
}