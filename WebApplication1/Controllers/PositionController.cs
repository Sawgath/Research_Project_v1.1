using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PositionController : ApiController
    {
        public List<position1> Get()
        {
            //[{"xData":"23","yData":"43","zData":"64"},{"xData":"233","yData":"443","zData":"634"}]
            List<position1> plist = new List<position1>();
            position1 p1 = new position1();
            p1.xData = "23";
            p1.yData = "43";
            p1.zData = "64";
            
            position1 p2 = new position1();
            p2.xData = "233";
            p2.yData = "443";
            p2.zData = "634";

            plist.Add(p1);
            plist.Add(p2);
            return plist;
        }
        public void Post(List<position1> outplist)
        {
            //[{"xData":"23","yData":"43","zData":"64"},{"xData":"233","yData":"443","zData":"634"}]


            System.Data.SqlClient.SqlConnection sqlConnection1 =
                new System.Data.SqlClient.SqlConnection("Data Source= JAHAN;Initial Catalog= temp01DB ;Integrated Security=SSPI;");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;

            foreach (position1 alist in outplist){
                cmd.CommandText += "INSERT pos1_TB (xData, yData, zData) VALUES ("+alist.xData+" , "+ alist.yData +" , " +alist.zData+") ;";
            }
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();

        }
    }
}
