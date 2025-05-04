using System.Data.SqlClient;

namespace ApplicationFirst.Models
{
    public class EmployeeDAL
    {
        // Iconfiguration that we have added in appsettings.json that we want to read
        private readonly IConfiguration _configuration;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public EmployeeDAL(IConfiguration configuration)
        {
            // read the connection string
            _configuration = configuration;
            con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

        // Add Emp
        public int AddEmployee(Employee employee)
        {
            int result = 0;
            try
            {
                employee.isActive = 1;
                con.Open();
                cmd = new SqlCommand("Insert into Employee values(@empname,@age,@salary,@isActive)", con);
                cmd.Parameters.AddWithValue("@empname", employee.empname);
                cmd.Parameters.AddWithValue("@age", employee.age);
                cmd.Parameters.AddWithValue("@salary", employee.salary);
                cmd.Parameters.AddWithValue("@isActive", employee.isActive);
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
                throw;
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        // Update Emp
        public int UpdateEmployee(Employee employee)
        {
            int result = 0;
            try
            {
                employee.isActive = 1;
                con.Open();
                cmd = new SqlCommand("update Employee set empname=@empame,age=@age,salary=@salary,isActive=@isActive where empid=@empid", con);
                cmd.Parameters.AddWithValue("@empame", employee.empname);
                cmd.Parameters.AddWithValue("@age", employee.age);
                cmd.Parameters.AddWithValue("@salary", employee.salary);
                cmd.Parameters.AddWithValue("@isActive", employee.isActive);
                cmd.Parameters.AddWithValue("@empid", employee.empid);
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return result;
        }
        // Delete Emp
        public int DeleteEmployee(int id)
        {
            int result = 0;
            try
            {
               // employee.isActive = 0;
                con.Open();
                cmd = new SqlCommand("update Employee set isActive=@isActive where empid=@empid", con);
                cmd.Parameters.AddWithValue("@isActive", 0);
                cmd.Parameters.AddWithValue("@empId", id);
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return result;
        }
        // Show All
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                con.Open();
                cmd = new SqlCommand("select * from Employee where isActive=1", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Employee employee = new Employee();
                    employee.empid = Convert.ToInt32(dr["empid"]);
                    employee.empname = dr["empname"].ToString();
                    employee.age = Convert.ToInt32(dr["age"]);
                    employee.salary = Convert.ToInt32(dr["salary"]);
                    employee.isActive = Convert.ToInt32(dr["isActive"]);
                    employees.Add(employee);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return employees;
        }
        // Show Emp by Id
        public Employee GetEmployeeById(int id)
        {
            Employee employee = new Employee();
            try
            {
                con.Open();
                cmd = new SqlCommand("select * from Employee where isActive=1 and empid=@empid", con);
                cmd.Parameters.AddWithValue("@empid", id);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    employee.empid = Convert.ToInt32(dr["empid"]);
                    employee.empname = dr["empname"].ToString();
                    employee.age = Convert.ToInt32(dr["age"]);
                    employee.salary = Convert.ToInt32(dr["salary"]);
                    employee.isActive = Convert.ToInt32(dr["isActive"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return employee;
        }



    }
}
