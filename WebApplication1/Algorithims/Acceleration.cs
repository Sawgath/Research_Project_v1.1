using System;
using System.Collections.Generic;
using WebApplication1.Models.DB;


public class Acceleration
{
    private IList<double> inputs { get; set; }

    private double eventThresholdPositve = 0.2;
    private double eventThresholdNegative = -0.2;

    //private double safetyThresholdPositive = 0.1;
    //private double safetyThresholdNegative = -0.1;

//    private bool isPositiveEventCreated = false;
  //  private bool isNegativeEventCreated = false;

    private List<double> eventAccelarations = new List<double>();
    private List<double> eventbreak = new List<double>();
    private int events;

    public Acceleration(IList<User_Driving_Data> data)
    {
        inputs = new List<double>();
        
        foreach (var obj in data)
        {
            inputs.Add(obj.User_Acceleration_Y);
        }
    }

    public void Checkacc()
    {
        foreach (double y in inputs)
        {
            //starting with postive values
            if (y > eventThresholdPositve)
            {
                eventAccelarations.Add(y);
                events++;       
            }
            else if (y < eventThresholdNegative)
            {
                eventbreak.Add(y);
                events++;
            }
            else
            {

            }
        }
    }
    public int GetTotalacc()
    {
        //Console.ReadKey();
        return events;
    }

    public IList <double> GetaccEvents()
    {
        return eventAccelarations;
    }
}




