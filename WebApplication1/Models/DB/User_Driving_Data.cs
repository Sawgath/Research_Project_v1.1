using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.DB
{
    public class User_Driving_Data
    {
      public int User_Id{get; set;}
      public string Session_Id{get; set;} 
      public int Data_Id{get; set;}
      public string Street_Name{get; set;}
      public double Speed_Limit{get; set;}
      public double Longitude {get; set;}
      public double Latitude {get; set;}
      public double Horizontal_Accuracy {get; set;}
      public double Speed {get; set;}
      public DateTime TimeStamp {get; set;}
      public double User_Acceleration_X { get; set; }
      public double User_Acceleration_Y { get; set; }
      public double User_Acceleration_Z { get; set; }
      public double Gravity_X {get; set;}
      public double Gravity_Y {get; set;}
      public double Gravity_Z {get; set;}
      public double Rotation_Rate_X {get; set;}
      public double Rotation_Rate_Y {get; set;}
      public double Rotation_Rate_Z {get; set;}
      public double Magnetic_Flied_X {get; set;}
      public double Magnetic_Field_Y {get; set;}
      public double Magnetic_Field_Z {get; set;}
        
    }
}