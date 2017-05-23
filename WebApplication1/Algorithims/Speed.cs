using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.Models.DB;

namespace WebApplication1.Algorithims
{
    public class Speed
    {

        private List<User_Driving_Events> eventAll = new List<User_Driving_Events>();
        private int events;
        public void GetSpeed(List<User_Driving_Data> aDriving_DataList)
        {
            //double CurrentSpeed = Driving_Data1.Speed;
            //double Speedlimit = Driving_Data1.Speed_Limit;
            
            List<SpeedData> safeDriveTimeList = new List<SpeedData>();
            List<SpeedData> unsafeDriveTimeList = new List<SpeedData>();

            foreach (User_Driving_Data aDriving_Data in aDriving_DataList)
            {
                
                if (aDriving_Data.Speed_Limit >= aDriving_Data.Speed)
                {
                    //safe speed;
                    SpeedData aData = new SpeedData();
                    aData.Speed = aDriving_Data.Speed;
                    //aData.Time = aDriving_Data.TimeStamp;

                    safeDriveTimeList.Add(aData);
                }
                else
                {
                    //unsafe speed;
                    SpeedData aData = new SpeedData();
                    aData.Speed = aDriving_Data.Speed;
                    //aData.Time = aDriving_Data.TimeStamp;
                    unsafeDriveTimeList.Add(aData);

                }
            }

            SpeedResult aResult = new SpeedResult();
            //aResult.TotalSafeTime=CheckTimer(safeDriveTimeList);
            aResult.SafeSpeedAvg = CheckSpeed(safeDriveTimeList);

           // aResult.TotalUnsafeTime = CheckTimer(unsafeDriveTimeList);
            aResult.UnsafeSpeedAvg = CheckSpeed(unsafeDriveTimeList);

            if (unsafeDriveTimeList.Count() > safeDriveTimeList.Count())
            {
                //safe speed;
                
            }
            else
            {
                //unsafe speed;

            }


        }

        public void GetSpeedData(List<User_Driving_Data> aDriving_DataList)
        {
            //double CurrentSpeed = Driving_Data1.Speed;
            //double Speedlimit = Driving_Data1.Speed_Limit;

            List<SpeedData> safeDriveTimeList = new List<SpeedData>();
            List<SpeedData> unsafeDriveTimeList = new List<SpeedData>();
            //List<SpeedResultTimer> unsafeTimer = new List<SpeedResultTimer>();
            DateTime? startTime= null;
            DateTime? finishTime= null;
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
                        //SpeedResultTimer aSpeedResultTimer = new SpeedResultTimer();
                        ///aSpeedResultTimer.startTime = startTime;
                        //aSpeedResultTimer.finishTime = finishTime;
                        //aSpeedResultTimer.exceedTime = finishTime.Value.Subtract(startTime.Value);
                        //unsafeTimer.Add(aSpeedResultTimer);

                    }


                }
                else
                {
                    //unsafe speed;
                    if (flag == 0)
                    {
                        startTime = DateTime.Now;
                        flag = 1;
                    }
                    else if (flag == 1)
                    {
                        finishTime = DateTime.Now;
                    }
                    
                }
            }

            SpeedResult aResult = new SpeedResult();
            //aResult.TotalSafeTime=CheckTimer(safeDriveTimeList);
            aResult.SafeSpeedAvg = CheckSpeed(safeDriveTimeList);
            // aResult.TotalUnsafeTime = CheckTimer(unsafeDriveTimeList);
            aResult.UnsafeSpeedAvg = CheckSpeed(unsafeDriveTimeList);


        }


        public string CheckTimer(List<SpeedData> DriveTimeList)
        {
            
            string TotalTime = "";
            SpeedData LastData = DriveTimeList.Last();
            SpeedData FirstData = DriveTimeList.First();
            TimeSpan span = Convert.ToDateTime(LastData.Time).Subtract(Convert.ToDateTime(FirstData.Time));

            TotalTime = span.ToString();
            return TotalTime;

        }

        public double CheckSpeed(List<SpeedData> DriveTimeList)
        {
            double TotalSpeed = 0;
            double count = DriveTimeList.Count();
            foreach (SpeedData aData in DriveTimeList)
            {

                TotalSpeed = TotalSpeed + aData.Speed;
            }


            return (TotalSpeed / count);
        }


    }
}