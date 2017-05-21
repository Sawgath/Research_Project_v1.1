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
            GetUserData(processData);
            var accelerationAlgo = new Acceleration(dataList);
            var speedAlgo = new Speed();
            var aggressiveTurningAlgo = new AgreesiveTurning();
            var laneChangeAlgo = new LaneChange(dataList);
            accelerationAlgo.Checkacc();
            //speed algo function
            //AggressiveTurning algo function
            laneChangeAlgo.GetLaneChangeEvents();
            //dataList.
        }

        private void InsertDrivingEvents()
        {
            var factory = new DbConnectionFactory("testDatabase");
            var context = new DbContext(factory);
            var repo = new User_Driving_EventsRepository(context);
            //repo.Insert();

        }
    }
}