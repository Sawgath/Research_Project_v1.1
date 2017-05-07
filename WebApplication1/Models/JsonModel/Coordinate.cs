using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Coordinate
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double horizontalAccuracy { get; set; }

        public Coordinate(double a, double b, double c)
        {
            latitude = a;
            longitude = b;
            horizontalAccuracy = c;
        }

    }
}