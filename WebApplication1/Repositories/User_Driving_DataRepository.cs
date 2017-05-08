﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Extensions;
using WebApplication1.Models.DB;

namespace WebApplication1.Repositories
{
    public class User_Driving_DataRepository : Repository<User_Driving_Data>
    {
       

        public User_Driving_DataRepository(DbContext context) : base(context)
        {
        }

        public override User_Driving_Data Delete(User_Driving_Data tentity)
        {
            throw new NotImplementedException();
        }

        public override User_Driving_Data Insert(User_Driving_Data tentity)
        {
            using (var command = _context.CreateCommand())
            {
                //command.CommandText = "INSERT INTO [dbo].[User_Driving_Data]([User_Id],[Session_Id],[Street_Name],[Speed_Limit],[Longitude],[Latitude],[Horizontal_Accuracy],[Speed],[TimeStamp],[Gravity_X],[Gravity_Y],[Gravity_Z],[Rotation_Rate_X],[Rotation_Rate_Y],[Rotation_Rate_Z],[Magnetic_Flied_X],[Magnetic_Field_Y],[Magnetic_Field_Z])" +
                  //                   " VALUES(@User_Id,@Session_Id,@Street_Name,@Speed_Limit,@Longitude,@Latitude,@Horizontal_Accuracy,@Speed,@TimeStamp,@Gravity_X,@Gravity_Y,@Gravity_Z,@Rotation_Rate_X,@Rotation_Rate_Y,@Rotation_Rate_Z,@Magnetic_Flied_X,@Magnetic_Field_Y,@Magnetic_Field_Z)";


                command.CommandText = "INSERT INTO [dbo].[User_Driving_Data]([User_Id],[Session_Id],[Street_Name],[Speed_Limit],[Longitude],[Latitude],[Horizontal_Accuracy],[Speed],[Gravity_X],[Gravity_Y],[Gravity_Z],[Rotation_Rate_X],[Rotation_Rate_Y],[Rotation_Rate_Z],[Magnetic_Flied_X],[Magnetic_Field_Y],[Magnetic_Field_Z])" +
                                     " VALUES(@User_Id,@Session_Id,@Street_Name,@Speed_Limit,@Longitude,@Latitude,@Horizontal_Accuracy,@Speed,@Gravity_X,@Gravity_Y,@Gravity_Z,@Rotation_Rate_X,@Rotation_Rate_Y,@Rotation_Rate_Z,@Magnetic_Flied_X,@Magnetic_Field_Y,@Magnetic_Field_Z)";

                command.Parameters.Add(command.CreateParameter("User_Id", tentity.User_Id));
                command.Parameters.Add(command.CreateParameter("Session_Id", tentity.Session_Id));
                //command.Parameters.Add(command.CreateParameter("Data_Id", tentity.Data_Id));
                command.Parameters.Add(command.CreateParameter("Street_Name", tentity.Street_Name));
                command.Parameters.Add(command.CreateParameter("Speed_Limit", tentity.Speed_Limit));
                command.Parameters.Add(command.CreateParameter("Longitude", tentity.Longitude));
                command.Parameters.Add(command.CreateParameter("Latitude", tentity.Latitude));
                command.Parameters.Add(command.CreateParameter("Horizontal_Accuracy", tentity.Horizontal_Accuracy));
                command.Parameters.Add(command.CreateParameter("Speed", tentity.Speed));
                //command.Parameters.Add(command.CreateParameter("TimeStamp", tentity.TimeStamp));
                command.Parameters.Add(command.CreateParameter("Gravity_X", tentity.Gravity_X));
                command.Parameters.Add(command.CreateParameter("Gravity_Y", tentity.Gravity_Y));
                command.Parameters.Add(command.CreateParameter("Gravity_Z", tentity.Gravity_Z));
                command.Parameters.Add(command.CreateParameter("Rotation_Rate_X", tentity.Rotation_Rate_X));
                command.Parameters.Add(command.CreateParameter("Rotation_Rate_Y", tentity.Rotation_Rate_Y));
                command.Parameters.Add(command.CreateParameter("Rotation_Rate_Z", tentity.Rotation_Rate_Z));
                command.Parameters.Add(command.CreateParameter("Magnetic_Flied_X", tentity.Magnetic_Flied_X));
                command.Parameters.Add(command.CreateParameter("Magnetic_Field_Y", tentity.Magnetic_Field_Y));
                command.Parameters.Add(command.CreateParameter("Magnetic_Field_Z", tentity.Magnetic_Field_Z));

                return this.ToList(command).FirstOrDefault();

            }
          
        }

        public override User_Driving_Data Update(User_Driving_Data tentity)
        {
            throw new NotImplementedException();
        }
    }
}