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
            User_Driving_DataRepository arepo= new User_Driving_DataRepository(context);
            UserRepository aUrepo = new UserRepository(context);

            
            //////////////////////////////////////////////////Username
            //If you want use username instead of userid -------(change json model userid-> username)
            //
            //
            //
            //int untid = aUrepo.GetUserID(Username).User_Id;
            //aDrivingData.User_Id = untid;
            ////////////////////////////////////////////////

            arepo.Insert(aDrivingData);
        }
        public IList<User> getAllUserData()
        {
            var factory = new DbConnectionFactory("testDatabase");
            var context = new DbContext(factory);
            var arepo = new UserRepository(context);
            return arepo.GetAll();
        }
        public bool CheckLoginData(User tentity)
        {
            throw new NotImplementedException();
        }
    }
}