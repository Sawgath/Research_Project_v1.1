using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class RotationRate
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }

        public RotationRate(double a, double b, double c)
        {
            x = a;
            y = b;
            z = c;
        }
    }
}