using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models.DB;
using WebApplication1.Enums;

namespace WebApplication1.Algorithims
{   
    public class AgreesiveTurning
    {
        public IList<User_Driving_Events> CheckAgressiveTurning_And_LaneChange(IList<User_Driving_Data> Datalist)
        {
            var frequency = Datalist.FirstOrDefault().Frequency;
            var listSize = Datalist.Count();
            var RemainderOfList = listSize % frequency;
            var DatachuckSize = listSize - RemainderOfList;
            IList<User_Driving_Data> DataChunkList = new List<User_Driving_Data>();
            IList<User_Driving_Events> AggressiveTurning_EventsList = new List<User_Driving_Events>();
            IList<User_Driving_Events> LaneChange_EventsList = new List<User_Driving_Events>();
            IList<User_Driving_Events> Events = new List<User_Driving_Events>();
            double AgressiveTurningEventCount=0;
            //double LaneChangeEventCount = 0;
            //LaneChange lanechange = new LaneChange();
            for (int i=0; i<DatachuckSize; i=i+frequency)
            {
                for(int j=i; j<i+frequency; j++)
                {
                    DataChunkList.Add(Datalist.ElementAt(j));
                }
                var FirstEntry = DataChunkList.First();
                var LastEntry = DataChunkList.Last();
                var Heading = TurningAngle(FirstEntry, LastEntry);
                if(Heading > 30)
                {
                    //Create aggresive turning event
                    AgressiveTurningEventCount++;
                    User_Driving_Events events = new User_Driving_Events();
                    events.Session_Id = FirstEntry.Session_Id;
                    events.Event_Type_Id = Convert.ToInt32(EventType.Agressive_Turning);
                    events.Event_Time = FirstEntry.TimeStamp;
                    Events.Add(events);
                }
                else 
                if (Heading > 0 & Heading < 20 )
                {
                    var laneChangeAlgo = new LaneChange();
                    var laneChangeEvents = laneChangeAlgo.CheckLaneChange(DataChunkList);
                    foreach (var e in laneChangeEvents)
                    {
                        Events.Add(e);
                    }
                }
                FirstEntry = null;
                LastEntry = null;
                DataChunkList.Clear();
            }
            if (RemainderOfList != 0)
            {
                for (var i = DatachuckSize; i < listSize+1; i++)
                {
                    DataChunkList.Add(Datalist.ElementAt(i));
                }
                var FirstEntry = DataChunkList.First();
                var LastEntry = DataChunkList.Last();
                var Heading = TurningAngle(FirstEntry, LastEntry);
                if (Heading >= 30)
                {
                    //Create aggresive turning event
                    AgressiveTurningEventCount++;
                    AgressiveTurningEventCount++;
                    User_Driving_Events events = new User_Driving_Events();
                    events.Session_Id = FirstEntry.Session_Id;
                    events.Event_Type_Id = Convert.ToInt32(EventType.Agressive_Turning);
                    events.Event_Time = FirstEntry.TimeStamp;
                    Events.Add(events);
                }
                else
                if (Heading > 0 & Heading < 20)
                {
                    var laneChangeAlgo = new LaneChange();
                    var laneChangeEvents = laneChangeAlgo.CheckLaneChange(DataChunkList);
                    foreach (var e in laneChangeEvents)
                    {
                        Events.Add(e);
                    }
                }
                FirstEntry = null;
                LastEntry = null;
                DataChunkList.Clear();
            }

            return Events;
        }
        
        private double TurningAngle(User_Driving_Data Driving_Data1, User_Driving_Data Driving_Data2)
        {   
            double long1=Driving_Data1.Longitude;
            double long2 = Driving_Data2.Longitude;
            double dLon = (long2-long1);
            if (dLon != 0)
            {
                double y = Math.Sin(dLon) * Math.Cos(Driving_Data2.Latitude);
                double x = Math.Cos(Driving_Data1.Latitude) * Math.Sin(Driving_Data2.Latitude) - Math.Sin(Driving_Data1.Latitude)
                           * Math.Cos(Driving_Data2.Latitude) * Math.Cos(dLon);
                double brng = Math.Atan2(y, x);
                brng = RadianToDegree(brng);
                brng = (brng + 360) % 360;
                brng = 360 - brng;
                return brng;
            }
            else
            {
                int brng = 0;
                return brng;
            }
            
        }

        private static double RadianToDegree(double radian)
        {
            return (180 / Math.PI) * radian;
        }
    }
}