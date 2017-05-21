using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models.DB;

namespace WebApplication1.Algorithims
{   
    public class AgreesiveTurning
    {
        public void checkAgressiveTurning_And_LaneChange(IList<User_Driving_Data> Datalist, int frequency)
        {
            var listSize = Datalist.Count();
            var RemainderOfList = listSize % frequency;
            var DatachuckSize = listSize - RemainderOfList;
            IList<User_Driving_Data> DataChuckList = new List<User_Driving_Data>();
            double AgressiveTurningEventCount=0;
            double LaneChangeEventCount = 0;
            //LaneChange lanechange = new LaneChange();
            for (int i=0; i<DatachuckSize; i=i+frequency)
            {
                for(int j=i; j<i+frequency; j++)
                {
                    DataChuckList.Add(Datalist.ElementAt(j));
                }
                var FirstEntry = DataChuckList.First();
                var LastEntry = DataChuckList.Last();
                var Heading = TurningAngle(FirstEntry, LastEntry);
                if(Heading >= 30)
                {
                    //Create aggresive turning event
                    AgressiveTurningEventCount++;
                }
                else 
                if (Heading > 0 & Heading < 20 )
                {
                    // lanechange.CheckLaneChange(DataChuckList);
                    LaneChangeEventCount++;
                }
                DataChuckList.Clear();
            }
            if (RemainderOfList != 0)
            {
                for (var i = DatachuckSize * frequency; i < listSize; i++)
                {
                    DataChuckList.Add(Datalist.ElementAt(i));
                }
                var FirstEntry = DataChuckList.First();
                var LastEntry = DataChuckList.Last();
                var Heading = TurningAngle(FirstEntry, LastEntry);
                if (Heading >= 30)
                {
                    //Create aggresive turning event

                }
                else
                if (Heading > 0 & Heading < 20)
                {
                    // lanechange.CheckLaneChange(DataChuckList);

                }
                DataChuckList.Clear();
            }
        }


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

        public static double RadianToDegree(double radian)
        {
            return (180 / Math.PI) * radian;
        }
    }
}