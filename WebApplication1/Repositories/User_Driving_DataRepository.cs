using System;
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
                command.CommandText = "INSERT INTO [dbo].[User_Driving_Data]([User_Id],[Session_Id],[Frequency],[Street_Name],[Speed_Limit],[Longitude],[Latitude],[Horizontal_Accuracy],[Speed],[TimeStamp],[User_Acceleration_X],[User_Acceleration_Y],[User_Acceleration_Z],[Gravity_X],[Gravity_Y],[Gravity_Z],[Rotation_Rate_X],[Rotation_Rate_Y],[Rotation_Rate_Z],[Magnetic_Flied_X],[Magnetic_Field_Y],[Magnetic_Field_Z])" +
                                    " VALUES(@User_Id,@Session_Id,@Frequency,@Street_Name,@Speed_Limit,@Longitude,@Latitude,@Horizontal_Accuracy,@Speed,@TimeStamp,@User_Acceleration_X,@User_Acceleration_Y,@User_Acceleration_Z,@Gravity_X,@Gravity_Y,@Gravity_Z,@Rotation_Rate_X,@Rotation_Rate_Y,@Rotation_Rate_Z,@Magnetic_Flied_X,@Magnetic_Field_Y,@Magnetic_Field_Z)";


               // command.CommandText = "INSERT INTO [dbo].[User_Driving_Data]([User_Id],[Session_Id],[Street_Name],[Speed_Limit],[Longitude],[Latitude],[Horizontal_Accuracy],[Speed],[Gravity_X],[Gravity_Y],[Gravity_Z],[Rotation_Rate_X],[Rotation_Rate_Y],[Rotation_Rate_Z],[Magnetic_Flied_X],[Magnetic_Field_Y],[Magnetic_Field_Z])" +
               //                      " VALUES(@User_Id,@Session_Id,@Street_Name,@Speed_Limit,@Longitude,@Latitude,@Horizontal_Accuracy,@Speed,@Gravity_X,@Gravity_Y,@Gravity_Z,@Rotation_Rate_X,@Rotation_Rate_Y,@Rotation_Rate_Z,@Magnetic_Flied_X,@Magnetic_Field_Y,@Magnetic_Field_Z)";

                command.Parameters.Add(command.CreateParameter("User_Id", tentity.User_Id));
                command.Parameters.Add(command.CreateParameter("Session_Id", tentity.Session_Id));
                //command.Parameters.Add(command.CreateParameter("Data_Id", tentity.Data_Id));
                command.Parameters.Add(command.CreateParameter("Frequency", tentity.Frequency));
                command.Parameters.Add(command.CreateParameter("Street_Name", tentity.Street_Name));
                command.Parameters.Add(command.CreateParameter("Speed_Limit", tentity.Speed_Limit));
                command.Parameters.Add(command.CreateParameter("Longitude", tentity.Longitude));
                command.Parameters.Add(command.CreateParameter("Latitude", tentity.Latitude));
                command.Parameters.Add(command.CreateParameter("Horizontal_Accuracy", tentity.Horizontal_Accuracy));
                command.Parameters.Add(command.CreateParameter("Speed", tentity.Speed));
                command.Parameters.Add(command.CreateParameter("TimeStamp", tentity.TimeStamp));
                command.Parameters.Add(command.CreateParameter("User_Acceleration_X", tentity.User_Acceleration_X));
                command.Parameters.Add(command.CreateParameter("User_Acceleration_Y", tentity.User_Acceleration_Y));
                command.Parameters.Add(command.CreateParameter("User_Acceleration_Z", tentity.User_Acceleration_Z));
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

        public bool checkSession(string sessionid)
        {
            using(var command = _context.CreateCommand())
            {
                command.CommandText = "SELECT distinct [Session_Id] FROM [dbo].[User_Driving_Data] WHERE [Session_Id]=@sessionid";
                command.Parameters.Add(command.CreateParameter("sessionid", sessionid));

                int i = this.ToList(command).Count();

                if (i == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

        }

        public IList<User_Driving_Data> GetUserDrivingDataWithIdAndSessionId(int userId, string sessionId)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [dbo].[User_Driving_Data] WHERE User_Id=@userid and Session_Id=@sessionid";
                command.Parameters.Add(command.CreateParameter("userid", userId));
                command.Parameters.Add(command.CreateParameter("sessionid", sessionId));
                
                return this.ToList(command).ToList();
            }

        }

        public override User_Driving_Data Update(User_Driving_Data tentity)
        {
            throw new NotImplementedException();
        }
    }
}