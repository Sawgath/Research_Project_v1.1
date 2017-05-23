using System;
using System.Collections.Generic;
using WebApplication1.Enums;
using WebApplication1.Models.DB;

namespace WebApplication1.Algorithims
{
    public class LaneChange
    {
        //double[] inputs = new double[] { 0.01, 0.001, 0.04, 0.09, 0.11, -0.15, 0.06, 0.01, 0.01, 0.001 };

        private double eventThresholdPositve = 0.05;
        private double eventThresholdNegative = -0.05;

        private double safetyThresholdPositive = 0.1;
        private double safetyThresholdNegative = -0.1;

        private bool isPositiveEventCreated = false;
        private bool isNegativeEventCreated = false;

        private List<double> eventAccelarations = new List<double>();
        private IList<User_Driving_Events> eventsList = new List<User_Driving_Events>();

        public IList<User_Driving_Events> CheckLaneChange(IList<User_Driving_Data> data)
        {
            foreach (var x in data)
            {
                //starting with postive values
                if (x.User_Acceleration_X > eventThresholdPositve)
                {
                    if (isPositiveEventCreated)
                    {
                        if (x.User_Acceleration_X > safetyThresholdPositive)
                        {
                            eventAccelarations.Add(x.User_Acceleration_X);
                        }
                    }
                    else if (isNegativeEventCreated)
                    {
                        isNegativeEventCreated = false;
                        eventAccelarations.Add(x.User_Acceleration_X);
                        //events.Add(eventAccelarations);
                        User_Driving_Events LaneChangeEvent = new User_Driving_Events();
                        LaneChangeEvent.User_Id = x.User_Id;
                        LaneChangeEvent.Event_Type_Id = Convert.ToInt32(EventType.Agressive_Lane_Change);
                        LaneChangeEvent.Event_Time = x.TimeStamp;
                        eventsList.Add(LaneChangeEvent);
                    }
                    else if (!isPositiveEventCreated)
                    {
                        isPositiveEventCreated = true;
                        if (x.User_Acceleration_X > safetyThresholdPositive)
                        {
                            eventAccelarations.Add(x.User_Acceleration_X);
                        }

                    }
                    else if (!isNegativeEventCreated)
                    {

                    }
                }

                //starting with negative values
                if (x.User_Acceleration_X < eventThresholdNegative)
                {
                    if (isNegativeEventCreated)
                    {

                        if (x.User_Acceleration_X < safetyThresholdNegative)
                        {
                            eventAccelarations.Add(x.User_Acceleration_X);
                        }
                    }
                    else if (isPositiveEventCreated)
                    {
                        isPositiveEventCreated = false;
                        eventAccelarations.Add(x.User_Acceleration_X);
                        User_Driving_Events LaneChangeEvent = new User_Driving_Events();
                        LaneChangeEvent.User_Id = x.User_Id;
                        LaneChangeEvent.Event_Type_Id = Convert.ToInt32(EventType.Agressive_Lane_Change);
                        LaneChangeEvent.Event_Time = x.TimeStamp;
                        eventsList.Add(LaneChangeEvent);
                    }
                    else if (!isNegativeEventCreated)
                    {
                        isNegativeEventCreated = true;
                        if (x.User_Acceleration_X < safetyThresholdNegative)
                        {
                            eventAccelarations.Add(x.User_Acceleration_X);
                        }
                    }
                    else if (!isPositiveEventCreated)
                    {

                    }
                }
            }
            return eventsList;       
        }

        //public int GetTotalLaneChangeEvents ()
        //{
        //    Console.WriteLine("Total Events: " + events.Count);
        //    foreach (List<double> xa in events)
        //    {
        //        foreach (double xaa in xa)
        //        {
        //            Console.WriteLine(xaa);
        //        }
        //    }
        //    //Console.ReadKey();
        //    return events.Count;
        //}

        //public IList<IList<double>> GetLaneChangeEvents ()
        //{
        //    CheckLaneChange();
        //    return events;
        //}
    }
}