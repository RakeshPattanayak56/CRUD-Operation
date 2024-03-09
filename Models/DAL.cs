using System.Data;
using System.Data.Common;

namespace CrudUsingnetCore.Models
{
    public class DAL
    {
        public response GetAllEmployee(SqlConnection connection)
        {
           response response = new response();
           SqlDataadapter da=new SqlDataadapter("select*from tblCrudNetCore",connection);
           DataTable dataTable = new DataTable();
            List<Employee> employeeList = new List<Employee>();
            da.fill(dt);
            if(dt.Rows.Count>0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                    employee.Name= Convert.ToString(dt.Rows[i]["Name"]);
                    employee.Email= Convert.ToString(dt.Rows[i]["Email"]);
                    employee.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
                    employeeList.Add(employee);
                }
            }
            if (employeeList.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.lstEmployee= employeeList;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.lstEmployee = null;
            }
            return response;
        }
        public response GetAllEmployeeById(SqlConnection connection,int id)
        {
            response response = new response();
            SqlDataadapter da = new SqlDataadapter("select*from tblCrudNetCore where ID='"+id+"' and IsActive =1", connection);
            DataTable dataTable = new DataTable();
            Employee employee = new Employee();
            da.fill(dt);
            if (dt.Rows.Count > 0)
            {               
                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                    employee.Name = Convert.ToString(dt.Rows[0]["Name"]);
                    employee.Email = Convert.ToString(dt.Rows[0]["Email"]);
                    employee.IsActive = Convert.ToInt32(dt.Rows[0]["IsActive"]);
                    response.StatusCode = 200;
                    response.StatusMessage = "Data Found";
                    response.Employee = employee;
            }           
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.Employee = null;
            }
            return response;
        }
        public response AddEmployee(SqlConnection connection, Employee employee)
        {
            response response = new response();
            SqlCommand cmd = new SqlCommand("insert into tblCrudNetCore(Name,Email,IsActive,CreatedDate) values('"+ employee.Name + "','"+ employee.Email + "','"+ employee.IsActive + "',Getdate())", connection);
            connection.Open();
            int i=cmd.ExecuteNonQuery();
            connection.Close();
            if (i>0)
            {              
                response.StatusCode = 200;
                response.StatusMessage = "Employee Added";               
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Something went wrong";               
            }
            return response;
        }
        public response UpdateEmployee(SqlConnection connection, Employee employee)
        {
            response response = new response();
            SqlCommand cmd = new SqlCommand("Update tblCrudNetCore set Name='" + employee.Name + "',Email='" + employee.Email + "' where ID='"+employee.Id+"'" , connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Employee Updated";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Employee Not Updated";
            }
            return response;
        }
        public response DeleteEmployee(SqlConnection connection, int id)
        {
            response response = new response();
            SqlCommand cmd = new SqlCommand("delete from tblCrudNetCore where ID='"+id+"'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Employee Deleted";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Employee not deleted";
            }
            return response;
        }
    }
}
