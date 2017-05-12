﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PositionData1
    {
        public string userID { get; set; }
        public double speedLimit { get; set; }
        public string streetName { get; set; }
        public double speed { get; set; }
        public double course { get; set; }
        public string datetime { get; set; }

        public Gravity gravity { get; set; }

        public UserAcceleration userAcceleration { get; set; }

        public RotationRate rotationRate { get; set; }

        public MagneticField magneticField { get; set; }

        public Coordinate coordinate { get; set; }

        //--------------------
        //public string userID;
        //public double speedLimit;
        //public string streetName;
        //public double speed;
        //public double course;
        //public string datetime;

        //public Gravity gravity;

        //public UserAcceleration userAcceleration;

        //public RotationRate rotationRate;

        //public MagneticField magneticField;

    }
}