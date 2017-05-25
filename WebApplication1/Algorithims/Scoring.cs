using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models.DB;
using WebApplication1.Enums;
using WebApplication1.Models.JsonModel;

namespace WebApplication1.Algorithims
{
    public class Scoring
    {
        private int LaneChangeCount = 0;
        private int AggressiveTurningCount = 0;
        private int SpeedingAndAccelerationCount = 0;
        private int SuddenBrakingCount = 0;
        private int SuddenAccelerationCount = 0;
        private int SpeedingCount = 0;
        private string score = null;

        public ScoringModel Score_Driving_Of_User(IList<User_Driving_Events> eventList)
        {
            foreach (var evnt in eventList)
            {
                if (evnt.Event_Type_Id == (int)(EventType.Agressive_Lane_Change))
                {
                    LaneChangeCount++;
                }
                else if (evnt.Event_Type_Id == (int)(EventType.Agressive_Turning))
                {
                    AggressiveTurningCount++;
                }
                else if (evnt.Event_Type_Id == (int)(EventType.Sudden_Braking))
                {
                    SuddenBrakingCount++;
                }
                else if (evnt.Event_Type_Id == (int)(EventType.Sudden_Acceleration))
                {
                    SuddenAccelerationCount++;
                }
                else if (evnt.Event_Type_Id == (int)(EventType.Speeding_Event))
                {
                    SpeedingCount++;
                }
            }
            SpeedingAndAccelerationCount = SuddenBrakingCount + SuddenAccelerationCount + SpeedingCount;
            if (LaneChangeCount > 0)
            {
                score = "High Risk";
            }
            else if (AggressiveTurningCount > 0)
            {
                score = "Medium Risk";
            }
            else if (SpeedingAndAccelerationCount > 0)
            {
                score = "Moderate Risk";
            }
            else
            {
                score = "No Risk";
            }
            var scoringModel = new ScoringModel();
            scoringModel.Agressive_Lane_Change_Count = LaneChangeCount;
            scoringModel.Agressive_Turning_Count = AggressiveTurningCount;
            scoringModel.Sudden_Acceleration_Count = SuddenAccelerationCount;
            scoringModel.Sudden_Braking_Count = SuddenBrakingCount;
            scoringModel.Speeding_Event_Count = SpeedingCount;
            scoringModel.Session_Score = score;
            return scoringModel;
        }
    }
}
