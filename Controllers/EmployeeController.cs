using CrudUsingnetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
namespace CrudUsingnetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private  readonly IConfiguration _configuration;

        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllEmployees")]
        public response GetAllEmployee()
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            response response= new response();
            DAL dal = new DAL();
            response = dal.GetAllEmployee(connection);
            return response;
        }
        [HttpGet]
        [Route("GetAllEmployeesById/{id}")]
        public response GetAllEmployeesById(int id)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            response response = new response();
            DAL dal = new DAL();
            response = dal.GetAllEmployeeById(connection,id);
            return response;
        }
        [HttpPost]
        [Route("AddEmployee")]
        public response AddEmployee(Employee employee)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            response response = new response();
            DAL dal= new DAL();
            response = dal.AddEmployee(connection, employee); 
            return response;
        }
        [HttpPut]
        [Route("UpdateEmployee")]
        public response UpdateEmployee(Employee employee)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            response response = new response();
            DAL dal = new DAL();
            response = dal.UpdateEmployee(connection, employee);
            return response;
        }
        Testing Tesing//
        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public response DeleteEmployee(int id)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            response response = new response();
            DAL dAL = new DAL();
            response = dAL.DeleteEmployee(connection,id);
            return response;
        }
    }
}
