using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.DB
{
    public class User_Driving_Events
    {
       public int User_Id { get; set; }
       public int Event_Type_Id { get; set; }
       public DateTime Event_Time { get; set; }

    }
}