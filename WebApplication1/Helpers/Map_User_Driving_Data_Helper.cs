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
            aDrivingData.Session_Id = 0;
            //aDrivingData.Data_Id = 1;
            aDrivingData.Street_Name = aData.streetName;
            aDrivingData.Speed_Limit = aData.speedLimit;
            aDrivingData.Longitude = aData.coordinate.longitude;
            aDrivingData.Latitude = aData.coordinate.latitude;
            aDrivingData.Horizontal_Accuracy = aData.coordinate.horizontalAccuracy;
            aDrivingData.Speed = aData.speed;
            aDrivingData.Gravity_X = aData.gravity.x;
            aDrivingData.Gravity_Y = aData.gravity.y;
            aDrivingData.Gravity_Z = aData.gravity.z;
            aDrivingData.Rotation_Rate_X = aData.rotationRate.x;
            aDrivingData.Rotation_Rate_Y = aData.rotationRate.y;
            aDrivingData.Rotation_Rate_Z = aData.rotationRate.z;
            aDrivingData.Magnetic_Flied_X = aData.magneticField.x;
            aDrivingData.Magnetic_Field_Y = aData.magneticField.y;
            aDrivingData.Magnetic_Field_Z = aData.magneticField.z;


            var factory = new DbConnectionFactory("testDatabase");
            var context = new DbContext(factory);
            User_Driving_DataRepository arepo= new User_Driving_DataRepository(context);

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