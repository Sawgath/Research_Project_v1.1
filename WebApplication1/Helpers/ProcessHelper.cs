using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Algorithims;
using WebApplication1.Models.DB;
using WebApplication1.Models.JsonModel;
using WebApplication1.Repositories;

namespace WebApplication1.Helpers
{
    public class ProcessHelper
    {
        private IList<User_Driving_Data> dataList = new List<User_Driving_Data>();
        private IList<User_Driving_Events> eventsList = new List<User_Driving_Events>();
        private void GetUserData(ProcessData processData)
        {
            var factory = new DbConnectionFactory("testDatabase");
            var context = new DbContext(factory);
            User_Driving_DataRepository repo = new User_Driving_DataRepository(context);
            dataList = repo.GetUserDrivingDataWithIdAndSessionId(processData.userID, processData.Session_Id);
        }

        public void RunAlgorithms(ProcessData processData)
        {
            try
            {
                GetUserData(processData);
                var accelerationAlgo = new Acceleration();
                var accelerationEvents = accelerationAlgo.Checkacc(dataList);
                InsertDrivingEvents(accelerationEvents);
                var speedAlgo = new Speed();
                var speedEvents = speedAlgo.GetSpeedData(dataList);
                //speedevents returned here
                var aggressiveTurningAlgo = new AgreesiveTurning();
                var turnAndLaneChangeEvents = aggressiveTurningAlgo.CheckAgressiveTurning_And_LaneChange(dataList);       //lane change algo is run within aggressive turning
                InsertDrivingEvents(turnAndLaneChangeEvents);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to Retrieve data");
            }
        }

        public IList<Session_History> RunHistory(HistoryData histoyData)
        {
            try
            {
                var factory = new DbConnectionFactory("testDatabase");
                var context = new DbContext(factory);
                var repo = new Session_HistoryRepository(context);
                var list = repo.getHistory(histoyData.userID);
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to Retrieve data");
            }
        }

        public void StopProcess(ProcessData processData)
        {
            try
            {
                var factory = new DbConnectionFactory("testDatabase");
                var context = new DbContext(factory);
                var repo = new Session_HistoryRepository(context);
                var sessionHistory = new Session_History();
                sessionHistory.Session_Id = processData.Session_Id;
                sessionHistory.User_Id = processData.userID;
                sessionHistory.End_time = DateTime.Now;
                repo.Update(sessionHistory);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to Retrieve data");
            }
        }

        private void InsertDrivingEvents(IList<User_Driving_Events> events)
        {
            var factory = new DbConnectionFactory("testDatabase");
            var context = new DbContext(factory);
            var repo = new User_Driving_EventsRepository(context);
            //repo.Insert();

        }
    }
}