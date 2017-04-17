using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;

namespace WebApplication1.Controllers
{
    public class Person
    {
        public int ID { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
    }
    public class PersonController : ApiController
    {

        public IEnumerable<Person> Get()
        {

            return new List<Person> {

            new Person { ID=10, First="YOasdas", Last="ha" },
            new Person { ID = 11, First = "asdasda", Last = "h2" },
            new Person { ID = 12, First = "hasdasdO", Last = "h4" }

        };
        }
        [HttpPost]
        public void Post([FromBody]Person value)
        {


        }
        [HttpPost]
        public void Post()
        {
           

        }


    }
}
