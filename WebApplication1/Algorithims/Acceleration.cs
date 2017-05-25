using System;
using System.Collections.Generic;
using WebApplication1.Models.DB;
using WebApplication1.Enums;


public class Acceleration
{
    private IList<double> inputs { get; set; }

    private double eventThresholdPositve = 0.2;
    private double eventThresholdNegative = -0.2;
    private List<User_Driving_Events> eventAll = new List<User_Driving_Events>();

    public IList<User_Driving_Events> Checkacc(IList<User_Driving_Data> DrivingData)
    {
        foreach (User_Driving_Data dData in DrivingData)
        {
            
            if (dData.User_Acceleration_Y > eventThresholdPositve)
            {
                User_Driving_Events evnt = new User_Driving_Events();
                evnt.Event_Type_Id = (int)EventType.Sudden_Acceleration;
                evnt.Event_Time = dData.TimeStamp;
                evnt.Session_Id = dData.Session_Id;
                eventAll.Add(evnt);
                      
            }
            else if (dData.User_Acceleration_Y < eventThresholdNegative)
            {
                User_Driving_Events evnt = new User_Driving_Events();
                evnt.Event_Type_Id = Convert.ToInt32(EventType.Sudden_Braking);
                evnt.Event_Time = dData.TimeStamp;
                evnt.Session_Id = dData.Session_Id;
                eventAll.Add(evnt);
            }
        }
        return eventAll;
    }
   
}




