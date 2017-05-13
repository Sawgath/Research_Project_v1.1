using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class SpeedResult
    {
        public double SafeSpeedAvg { get; set; }
        public double UnsafeSpeedAvg { get; set; }
        public string TotalSafeTime { get; set; }
        public string TotalUnsafeTime { get; set; }
    }
}