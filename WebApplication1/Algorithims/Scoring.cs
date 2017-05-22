using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models.DB;
using WebApplication1.Enum;

namespace WebApplication1.Algorithims
{
    public class Scoring
    {
        public string Score_Driving_Of_User(IList<User_Driving_Events> eventList)
        {
            var LaneChange = 0;
            var AggressiveTurning = 0;
            var SpeedingAndAccelerationEvents = 0;
       
            foreach (var evnt in eventList)
            {
                if (evnt.Event_Type_Id == Convert.ToInt32(EventType.Agressive_Lane_Change))
                {
                    LaneChange++;
                }
                else
                if (evnt.Event_Type_Id == Convert.ToInt32(EventType.Agressive_Turning))
                {
                    AggressiveTurning++;
                }
                else
                if (evnt.Event_Type_Id == Convert.ToInt32(EventType.Sudden_Acceleration) || 
                    evnt.Event_Type_Id == Convert.ToInt32(EventType.Sudden_Braking) || 
                    evnt.Event_Type_Id == Convert.ToInt32(EventType.Speeding_Event))
                {

                    SpeedingAndAccelerationEvents++;
                }
            }
            if(LaneChange>0)
            {
                return "High Risk";
            }
            else
            if(AggressiveTurning>0)
            {
                return "Medium Risk";
            }else
            if(SpeedingAndAccelerationEvents>0)
            {
                return "Moderate Risk";
            }
            else
            {
                return "No Risk";
            }
            }
        }
    }
