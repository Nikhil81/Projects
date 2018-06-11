using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VersioningExample.Models;

namespace VersioningExample.Controllers
{
    [RoutePrefix("api/students/v1")]
    public class StudentV1Controller : ApiController
    {
        static List<StudentV1> _students = new List<StudentV1> {

            new StudentV1 { Id=1,Name="Tom" },
            new StudentV1 { Id=2,Name="Todd"},
            new StudentV1 { Id=3,Name="Vishal"},
        };

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(_students);
        }

        [Route("{id:int:min(1):max(3)}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(_students.Where(x => x.Id == id));
        }
    }
}
