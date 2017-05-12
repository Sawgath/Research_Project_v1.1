using System;
using System.Collections.Generic;
using WebApplication1.Models.DB;

namespace WebApplication1.Algorithims
{
    public class LaneChange
    {
        //double[] inputs = new double[] { 0.01, 0.001, 0.04, 0.09, 0.11, -0.15, 0.06, 0.01, 0.01, 0.001 };
        private IList<double> inputs { get; set; }

        private double eventThresholdPositve = 0.05;
        private double eventThresholdNegative = -0.05;

        private double safetyThresholdPositive = 0.1;
        private double safetyThresholdNegative = -0.1;

        private bool isPositiveEventCreated = false;
        private bool isNegativeEventCreated = false;

        private List<double> eventAccelarations = new List<double>();
        private IList<IList<double>> events { get; set; }

        public LaneChange(IList<User_Driving_Data> data)
        {
            inputs = new List<double>();
            events = new List<IList<double>>();
            foreach (var obj in data)
            {
                inputs.Add(obj.User_Acceleration_X);
            }
        }

        public void CheckLaneChange()
        {
            foreach (double x in inputs)
            {
                //starting with postive values
                if (x > eventThresholdPositve)
                {
                    if (isPositiveEventCreated)
                    {
                        if (x > safetyThresholdPositive)
                        {
                            eventAccelarations.Add(x);
                        }
                    }
                    else if (isNegativeEventCreated)
                    {
                        isNegativeEventCreated = false;
                        eventAccelarations.Add(x);
                        events.Add(eventAccelarations);
                    }
                    else if (!isPositiveEventCreated)
                    {
                        isPositiveEventCreated = true;
                        if (x > safetyThresholdPositive)
                        {
                            eventAccelarations.Add(x);
                        }

                    }
                    else if (!isNegativeEventCreated)
                    {

                    }
                }

                //starting with negative values
                if (x<eventThresholdNegative)
                {
                    if (isNegativeEventCreated)
                    {

                        if (x<safetyThresholdNegative)
                        {
                            eventAccelarations.Add(x);
                        }
                    }
                    else if (isPositiveEventCreated)
                    {
                        isPositiveEventCreated = false;
                        eventAccelarations.Add(x);
                        events.Add(eventAccelarations);
                    }
                    else if (!isNegativeEventCreated)
                    {
                        isNegativeEventCreated = true;
                        if (x<safetyThresholdNegative)
                        {
                            eventAccelarations.Add(x);
                        }
                    }
                    else if (!isPositiveEventCreated)
                    {

                    }
                }
            }           
        }

        public int GetTotalLaneChangeEvents ()
        {
            Console.WriteLine("Total Events: " + events.Count);
            foreach (List<double> xa in events)
            {
                foreach (double xaa in xa)
                {
                    Console.WriteLine(xaa);
                }
            }
            //Console.ReadKey();
            return events.Count;
        }

        public IList<IList<double>> GetLaneChangeEvents ()
        {
            return events;
        }
    }
}