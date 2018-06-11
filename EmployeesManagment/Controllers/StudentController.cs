using EmployeesManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeesManagment.Controllers
{

    [RoutePrefix("api/students")]
    public class StudentController : ApiController
    {

        static List<Student> _students = new List<Student> {

            new Student { ID =1, Name="Tom"},
            new Student { ID =2, Name ="Todd"}
        };

        [Route("", Name = "GetStudent")]
        public IHttpActionResult Get()
        {
            return Ok(_students);
        }

        [Route("{id:int:min(1):max(2)}")]
        public IHttpActionResult Get(int id)
        {
            var student = _students.FirstOrDefault(x => x.ID == id);
            return Ok(student);
        }

        [Route("{name:alpha}")]
        public IHttpActionResult Get(string name)
        {
            var _result = _students.FirstOrDefault(x => string.Compare(x.Name, name, StringComparison.CurrentCultureIgnoreCase) == 0);
            return Ok(_result);
        }

        [Route("{id:range(1,4)}/courses")]
        public IHttpActionResult GetStudentCourse(int id)
        {
            switch (id)
            {
                case 1:
                    return Ok(new List<string> { "C#", "API", "XAML" });
                case 2:
                    return Ok(new List<string> { "Java", "sliverlight", "spring" });
                case 3:
                    return Ok(new List<string> { "MVC", "API", "XAMRIENE" });
                case 4:
                    return Ok(new List<string> { "C#", "SQL SERVER", "XAML" });

                default:
                    return NotFound();
            }
        }


        [Route("~/api/teachers")]
        public IHttpActionResult GetTeachers()
        {
            List<Teachers> _teachers = new List<Teachers>
            {
                new Teachers { Id=1, Name = "Trace"},
                new Teachers { Id=2,Name= "Karen"},
                new Teachers { Id=3,Name= "Kiran"},
            };
            return Ok(_teachers);
        }

        [Route("")]
        public IHttpActionResult Post(Student student)
        {
            _students.Add(student);
            return Created<List<Student>>(new Uri(Url.Link("GetStudent", new { id = student.ID })).ToString(), _students);
        }
    }
}
