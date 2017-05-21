using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models.DB;

namespace WebApplication1.Algorithims
{
    public class AgreesiveTurning
    {
        public double TurningAngle(User_Driving_Data Driving_Data1, User_Driving_Data Driving_Data2)
        {   
            double long1=Driving_Data1.Longitude;
            double long2 = Driving_Data2.Longitude;
            double dLon = (long2-long1);
            double y = Math.Sin(dLon) * Math.Cos(Driving_Data2.Latitude);
            double x = Math.Cos(Driving_Data1.Latitude) * Math.Sin(Driving_Data2.Latitude) - Math.Sin(Driving_Data1.Latitude)
                       * Math.Cos(Driving_Data2.Latitude) * Math.Cos(dLon);
            double brng = Math.Atan2(y, x);
            brng = RadianToDegree(brng);
            brng = (brng + 360) % 360;
            brng = 360 - brng;
            return brng;
        }

        public bool Agreesive_Left_Turining(User_Driving_Data Driving_Data)
        {
            if(Driving_Data.User_Acceleration_X > 0.2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Agreesive_Right_Turining(User_Driving_Data Driving_Data)
        {
            if (Driving_Data.User_Acceleration_X < -0.2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static double RadianToDegree(double radian)
        {
            return (180 / Math.PI) * radian;
        }
    }
}