using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class SpeedResultTimer
    {

        public DateTime? startTime { get; set; }


        public DateTime? finishTime { get; set; }

        public TimeSpan exceedTime { get; set; }


    }
}