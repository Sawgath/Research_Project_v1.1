using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Enums;
using WebApplication1.Models;
using WebApplication1.Models.DB;

namespace WebApplication1.Algorithims
{
    public class Speed
    {

     
        

        public IList<User_Driving_Events> GetSpeedData(IList<User_Driving_Data> aDriving_DataList)
        {
            //double CurrentSpeed = Driving_Data1.Speed;
            //double Speedlimit = Driving_Data1.Speed_Limit;


            List<User_Driving_Events> eventList = new List<User_Driving_Events>();

            List<SpeedResultTimer> unsafeTimer = new List<SpeedResultTimer>();
            string sessionIdTemp = "";
            DateTime startTime=DateTime.Now;
            DateTime? startTimer= null;
            DateTime? finishTimer= null;
            int flag = 0;
            foreach (User_Driving_Data aDriving_Data in aDriving_DataList)
            {
                if (aDriving_Data.Speed_Limit >= aDriving_Data.Speed)
                {
                    //flag = 0;
                    if (flag == 0)
                    {


                    }
                    else if (flag == 1)
                    {
                        flag = 0;

                    }
                    else if (flag == 2)
                    {


                        /////Unused ////////////////////////////////
                        //SpeedResultTimer aSpeedResultTimer = new SpeedResultTimer();
                        //aSpeedResultTimer.startTime = startTimer;
                        //aSpeedResultTimer.finishTime = finishTimer;
                        //aSpeedResultTimer.exceedTime = finishTimer.Value.Subtract(startTimer.Value);
                        //unsafeTimer.Add(aSpeedResultTimer);
                        ////////////////////////////////////////////
                        //int count = finishTimer.Value.Subtract(startTimer.Value).Seconds;
                        //if (count >= 5)
                        //{
                            flag = 0;
                            sessionIdTemp = aDriving_Data.Session_Id;
                            User_Driving_Events aEvent = new User_Driving_Events();
                            aEvent.Event_Type_Id = (int)EventType.Speeding_Event;
                            aEvent.Event_Time = startTime;
                            aEvent.Session_Id = sessionIdTemp;
                            eventList.Add(aEvent);
                        //}

                    }


                }
                else
                {
                    //unsafe speed;
                    if (flag == 0)
                    {
                        startTime = aDriving_Data.TimeStamp;
                        startTimer = DateTime.Now;
                        flag = 1;
                    }
                    else if (flag == 1)
                    {
                        finishTimer = DateTime.Now;
                        flag = 2;
                    }
                    
                }
            }

            if (flag == 1)
            {
                User_Driving_Events aEvent = new User_Driving_Events();
                aEvent.Event_Type_Id = (int)EventType.Speeding_Event;
                aEvent.Event_Time = startTime;
                aEvent.Session_Id = sessionIdTemp;
                eventList.Add(aEvent);

            }

            return eventList;


        }



        //public void GetSpeed(List<User_Driving_Data> aDriving_DataList)
        //{
        //    //double CurrentSpeed = Driving_Data1.Speed;
        //    //double Speedlimit = Driving_Data1.Speed_Limit;

        //    List<SpeedData> safeDriveTimeList = new List<SpeedData>();
        //    List<SpeedData> unsafeDriveTimeList = new List<SpeedData>();

        //    foreach (User_Driving_Data aDriving_Data in aDriving_DataList)
        //    {

        //        if (aDriving_Data.Speed_Limit >= aDriving_Data.Speed)
        //        {
        //            //safe speed;
        //            SpeedData aData = new SpeedData();
        //            aData.Speed = aDriving_Data.Speed;
        //            //aData.Time = aDriving_Data.TimeStamp;

        //            safeDriveTimeList.Add(aData);
        //        }
        //        else
        //        {
        //            //unsafe speed;
        //            SpeedData aData = new SpeedData();
        //            aData.Speed = aDriving_Data.Speed;
        //            //aData.Time = aDriving_Data.TimeStamp;
        //            unsafeDriveTimeList.Add(aData);

        //        }
        //    }

        //    SpeedResult aResult = new SpeedResult();
        //    //aResult.TotalSafeTime=CheckTimer(safeDriveTimeList);
        //    aResult.SafeSpeedAvg = CheckSpeed(safeDriveTimeList);

        //    // aResult.TotalUnsafeTime = CheckTimer(unsafeDriveTimeList);
        //    aResult.UnsafeSpeedAvg = CheckSpeed(unsafeDriveTimeList);

        //    if (unsafeDriveTimeList.Count() > safeDriveTimeList.Count())
        //    {
        //        //safe speed;

        //    }
        //    else
        //    {
        //        //unsafe speed;

        //    }


        //}

        //public string CheckTimer(List<SpeedData> DriveTimeList)
        //{
            
        //    string TotalTime = "";
        //    SpeedData LastData = DriveTimeList.Last();
        //    SpeedData FirstData = DriveTimeList.First();
        //    TimeSpan span = Convert.ToDateTime(LastData.Time).Subtract(Convert.ToDateTime(FirstData.Time));

        //    TotalTime = span.ToString();
        //    return TotalTime;

        //}

        //public double CheckSpeed(List<SpeedData> DriveTimeList)
        //{
        //    double TotalSpeed = 0;
        //    double count = DriveTimeList.Count();
        //    foreach (SpeedData aData in DriveTimeList)
        //    {

        //        TotalSpeed = TotalSpeed + aData.Speed;
        //    }


        //    return (TotalSpeed / count);
        //}


    }
}