using System.Data.SqlClient;

namespace ApplicationFirst.Models
{
    public class StudentDAL
    {
        // Iconfiguration that we have added in appsettings.json that we want to read
        private readonly IConfiguration _configuration;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public StudentDAL(IConfiguration configuration)
        {
            // read the connection string
            _configuration = configuration;
            con = new SqlConnection(_configuration.GetConnectionString("DefaultConnections"));
        }
        public int AddStudent(Student student)
        {
            int result = 0;
            try
            {

                student.isActive = 1;
                con.Open();
                cmd = new SqlCommand("Insert into Student values(@Sname,@Age,@Marks,@isActive)", con);
                cmd.Parameters.AddWithValue("@Sname", student.Sname);
                cmd.Parameters.AddWithValue("@Age", student.Age);
                cmd.Parameters.AddWithValue("@Marks", student.Marks);
                cmd.Parameters.AddWithValue("@isActive", student.isActive);
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

        // Update Emp
        public int UpdateEmployee(Student student)
        {
            int result = 0;
            try
            {
                student.isActive = 1;
                con.Open();
                cmd = new SqlCommand("update  Student set sname=@Sname,age=@Age,Marks=@Marks,isActive=@isActive where id=@Id", con);
                cmd.Parameters.AddWithValue("@Sname", student.Sname);
                cmd.Parameters.AddWithValue("@Age", student.Age);
                cmd.Parameters.AddWithValue("@Marks", student.Marks);
                cmd.Parameters.AddWithValue("@isActive", student.isActive);
                cmd.Parameters.AddWithValue("@Id", student.Id);
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
        public int DeleteStudent(int id)
        {
            int result = 0;
            try
            {
                //student.isActive = 0;
                con.Open();
                cmd = new SqlCommand("update  Student set isActive=@isActive where id=@Id", con);
                cmd.Parameters.AddWithValue("@isActive", 0);
                cmd.Parameters.AddWithValue("@Id", id);
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
        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            try
            {
                con.Open();
                cmd = new SqlCommand("select * from  Student where isActive=1", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Student student = new Student();
                    student.Id = Convert.ToInt32(dr["Id"]);
                    student.Sname = dr["Sname"].ToString();
                    student.Age = Convert.ToInt32(dr["Age"]);
                    student.Marks = Convert.ToInt32(dr["Marks"]);
                    student.isActive = Convert.ToInt32(dr["isActive"]);
                    students.Add(student);
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
            return students;
        }
        // Show Emp by Id
        public Student GetStudentById(int id)
        {
            Student student = new Student();
            try
            {
                con.Open();
                cmd = new SqlCommand("select * from  Student where isActive=1 and id=@Id", con);
                cmd.Parameters.AddWithValue("@Id", id);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                   student.Id = Convert.ToInt32(dr["Id"]);
                    student.Sname = dr["Sname"].ToString();
                    student.Age = Convert.ToInt32(dr["Age"]);
                    student.Marks = Convert.ToInt32(dr["Marks"]);
                    student.isActive = Convert.ToInt32(dr["isActive"]);
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
            return student;
        }
    }
}


  