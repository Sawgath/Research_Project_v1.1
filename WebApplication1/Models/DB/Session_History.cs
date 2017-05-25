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
        public int Speeding_Event_Count { get; set; }
        public int Sudden_Acceleration_Count { get; set; }
        public int Sudden_Braking_Count { get; set; }
        public int Agressive_Lane_Change_Count { get; set; }
        public int Agressive_Turning_Count { get; set; }
        public string Session_Score { get; set; }

    }
}