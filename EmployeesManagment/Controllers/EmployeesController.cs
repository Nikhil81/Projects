using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace EmployeesManagment.Controllers
{
    //[System.Web.Http.Authorize]
    public class EmployeesController : ApiController
    {
        EmployeeDBEntities _emp = new EmployeeDBEntities();
        public IHttpActionResult Get()
        {
            return Ok(_emp.Employees.ToList());
        }
    }
}
