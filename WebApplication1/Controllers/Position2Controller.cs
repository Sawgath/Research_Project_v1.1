using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using WebApplication1.Helpers;

namespace WebApplication1.Controllers
{
    public class Position2Controller : ApiController
    {

        public PositionData1 Get()
        {
            //[{"xData":"23","yData":"43","zData":"64"},{"xData":"233","yData":"443","zData":"634"}]
            //Sweq
            List <PositionData1> alist = new List<PositionData1>();
            PositionData1 p1 = new PositionData1();
            p1.userID = "1";
            p1.streetName = "yoyo";
            p1.speedLimit = 90.00 ;
            p1.datetime = "12/12/12";
            p1.speed = 67;
            p1.course = 170;
            p1.gravity = new Gravity(2.4 ,1.2 ,0.001);
            p1.rotationRate = new RotationRate(00.23,12.23,0.23);
            p1.magneticField = new MagneticField(4.23, 2.4, 1.5);
            p1.userAcceleration = new UserAcceleration(1.2,1.4,4.4);
            p1.coordinate = new Coordinate(2.3,23,0.44);


            PositionData1 p2 = new PositionData1();
            p2.userID = "1";
            p2.streetName = "y3o";
            p2.speedLimit = 30.00;
            p2.datetime = DateTime.Now.ToString();
            p2.speed = 90;
            p2.course = 130;
            p2.gravity = new Gravity(21.3, 3.2, 0.031);
            p2.rotationRate = new RotationRate(023.23, 12.2323, 32.23);
            p2.magneticField = new MagneticField(23.23,23.4, 32.5);
            p2.userAcceleration = new UserAcceleration(32.23, 21.23, 34.23);
            p2.coordinate = new Coordinate(2.3, 23, 0.44);

            alist.Add(p1);

            alist.Add(p2);

            return p2;





        }

        [HttpPost]
        public void post(Driving_Data alist)
        {

            Map_User_Driving_Data aMap = new Map_User_Driving_Data();
            aMap.Map_data(alist);




        }


        //[HttpPost]
        //public void post(string jsonString)
        //{
        //   // PositionData1 deserializedProduct = JsonConvert.DeserializeObject<PositionData1>(jsonString);
        //}

    }
}
