using CompanyEmployees.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CompanyEmployees.Controllers
{
    public class EmployeeController : ApiController
    {

        DatabaseContext db = new DatabaseContext();

        //api/user
        public IEnumerable<Employee> GetEmployees()
        {
            return db.Employees.ToList();
        }
        //api/user/2
        public Employee GetEmployee(int id)
        {
            return db.Employees.Find(id);
        }
        //api/user
        [HttpPost]
        public HttpResponseMessage AddEmployee(Employee model)
        {
            try
            {
                db.Employees.Add(model);
                db.SaveChanges();
                HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.Created);
                return responseMessage;
            }
            catch(Exception ex)
            {
                HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return responseMessage;
            }
        }
    }
}
