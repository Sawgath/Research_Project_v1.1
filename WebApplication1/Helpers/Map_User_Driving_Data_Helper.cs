using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.Models.DB;
using WebApplication1.Repositories;

namespace WebApplication1.Helpers
{
    public class Map_User_Driving_Data_Helper
    {
        public void Map_data(Driving_Data aData)
        {
            

            User_Driving_Data aDrivingData = new User_Driving_Data();

            aDrivingData.User_Id = aData.userID;
            aDrivingData.Session_Id = aData.Session_Id;
            //aDrivingData.Data_Id = 1;
            aDrivingData.Frequency = aData.frequency;
            aDrivingData.Street_Name = aData.streetName;
            aDrivingData.Speed_Limit = aData.speedLimit;
            aDrivingData.Longitude = aData.coordinate.longitude;
            aDrivingData.Latitude = aData.coordinate.latitude;
            aDrivingData.TimeStamp = aData.datetime;
            aDrivingData.Horizontal_Accuracy = aData.coordinate.horizontalAccuracy;
            aDrivingData.Speed = aData.speed;
            aDrivingData.Gravity_X = aData.gravity.x;
            aDrivingData.Gravity_Y = aData.gravity.y;
            aDrivingData.Gravity_Z = aData.gravity.z;
            aDrivingData.User_Acceleration_X = aData.userAcceleration.x;
            aDrivingData.User_Acceleration_Y = aData.userAcceleration.y;
            aDrivingData.User_Acceleration_Z = aData.userAcceleration.z;
            aDrivingData.Rotation_Rate_X = aData.rotationRate.x;
            aDrivingData.Rotation_Rate_Y = aData.rotationRate.y;
            aDrivingData.Rotation_Rate_Z = aData.rotationRate.z;
            aDrivingData.Magnetic_Flied_X = aData.magneticField.x;
            aDrivingData.Magnetic_Field_Y = aData.magneticField.y;
            aDrivingData.Magnetic_Field_Z = aData.magneticField.z;
            var factory = new DbConnectionFactory("testDatabase");
            var context = new DbContext(factory);

            //Session_HistoryRepository sessionHistoryRepo;
            bool flag;
            using (var sessionHistoryRepo = new Session_HistoryRepository(context))
            {
                flag = sessionHistoryRepo.checkSession(aDrivingData.Session_Id);
            }
            if (flag)
            {
                var factory1 = new DbConnectionFactory("testDatabase");
                var context1 = new DbContext(factory1);
                using (var sessionHistoryRepo2 = new Session_HistoryRepository(context1))
                {
                    var sessionHistory = new Session_History();
                    sessionHistory.Session_Id = aDrivingData.Session_Id;
                sessionHistory.User_Id = aDrivingData.User_Id;
                sessionHistory.Start_time = DateTime.Now;
                sessionHistoryRepo2.Insert(sessionHistory);

                }

            }
            var factory2 = new DbConnectionFactory("testDatabase");
            var context2 = new DbContext(factory2);
            using (User_Driving_DataRepository arepo = new User_Driving_DataRepository(context2))
            {
                arepo.Insert(aDrivingData);
            }

            //////////////////////////////////////////////////Username
            //If you want use username instead of userid -------(change json model userid-> username)
            //
            //
            //
            //int untid = aUrepo.GetUserID(Username).User_Id;
            //aDrivingData.User_Id = untid;
            ////////////////////////////////////////////////

        }
        
        public bool CheckLoginData(User tentity)
        {
            throw new NotImplementedException();
        }
    }
}