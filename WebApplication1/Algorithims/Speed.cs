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
                        //flag = 0;
                    }
                    else if (flag == 1)
                    {
                        flag = 0;

                    }
                    else if (flag == 2)
                    {
                        int count = finishTimer.Value.Subtract(startTimer.Value).Seconds;
                        if (count >= 2)
                        {
                            flag = 0;
                            sessionIdTemp = aDriving_Data.Session_Id;
                            User_Driving_Events aEvent = new User_Driving_Events();
                            aEvent.Event_Type_Id = (int)EventType.Speeding_Event;
                            aEvent.Event_Time = startTime;
                            aEvent.Session_Id = sessionIdTemp;
                            eventList.Add(aEvent);
                        }
                    }
                }
                else
                {
                    //unsafe speed;
                    if (flag == 0)
                    {
                        sessionIdTemp = aDriving_Data.Session_Id;
                        startTime=aDriving_Data.TimeStamp;
                        startTimer = aDriving_Data.TimeStamp;
                        finishTimer = aDriving_Data.TimeStamp;
                        flag = 1;
                    }
                    else if (flag == 1)
                    {
                        sessionIdTemp = aDriving_Data.Session_Id;
                        finishTimer = aDriving_Data.TimeStamp;
                        flag = 2;
                    }
                    else if (flag == 2)
                    {
                        sessionIdTemp = aDriving_Data.Session_Id;
                        finishTimer = aDriving_Data.TimeStamp;
                        flag = 2;
                    }
                }
            }

            if (flag == 2)
            {
                User_Driving_Events aEvent = new User_Driving_Events();
                aEvent.Event_Type_Id = (int)EventType.Speeding_Event;
                aEvent.Event_Time = startTime;
                aEvent.Session_Id = sessionIdTemp;
                eventList.Add(aEvent);
            }

            return eventList;

        }
    }
}