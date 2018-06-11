using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VersioningExample.Models;

namespace VersioningBasedonCustomHeader.Controllers
{
    public class StudentsV2Controller : ApiController
    {
        static List<StudentV2> _students = new List<StudentV2> {

            new StudentV2 { Id=1,Name="Tom1" },
            new StudentV2 { Id=2,Name="Todd1"},
            new StudentV2 { Id=3,Name="Vishal1"},
        };
        public IHttpActionResult Get()
        {
            return Ok(_students);
        }

        public IHttpActionResult Get(int id)
        {
            return Ok(_students.Where(x => x.Id == id));
        }
    }
}
