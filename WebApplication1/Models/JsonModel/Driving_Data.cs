using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Driving_Data
    {
        public int userID { get; set; }
        public int frequency { get; set; }
        public double speedLimit { get; set; }
        public string streetName { get; set; }
        public double speed { get; set; }
        public string Session_Id { get; set; }
        public double course { get; set; }
        public DateTime datetime { get; set; }
        public Gravity gravity { get; set; }
        public UserAcceleration userAcceleration { get; set; }
        public RotationRate rotationRate { get; set; }
        public MagneticField magneticField { get; set; }
        public Coordinate coordinate { get; set; }
    }
}