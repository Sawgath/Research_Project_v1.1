using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class MagneticField
    {
        public double x { get; set; }

        public double y { get; set; }

        public double z { get; set; }



        public MagneticField(double a, double b, double c)
        {
            x = a;
            y = b;
            z = c;
        }
    }
}