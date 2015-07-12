using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnrollmentSystem.core.Abstracts;
using EnrollmentSystem.core.Models;

namespace EnrollmentSystem.core.Controllers
{
    class StudentController:IStudentController
    {
        string sqlconnectionstring = "";

        public StudentController()
        {
            sqlconnectionstring = System.Configuration.ConfigurationManager.AppSettings["SQLConnection"];
            
        }


        #region IController<Student> Members

        public Student GetByID(int id)
        {
            Student student = null;

            try
            {
                using (SqlConnection con = new SqlConnection(this.sqlconnectionstring))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Student WHERE id=@id",con);
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader()) 
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            student = new Student();

                            student.ID = id;
                            student.Name = reader["Name"].ToString();
                            student.IsActive = Boolean.Parse(reader["IsActive"].ToString());
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return student;
        }

        public IEnumerable<Student> GetAll()
        {
            List<Student> students = new List<Student>();

            try
            {
                using (SqlConnection con = new SqlConnection(this.sqlconnectionstring))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Student", con);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            Student student = null;
                            student = new Student();

                            student.ID = Int32.Parse(reader["ID"].ToString());
                            student.Name = reader["Name"].ToString();
                            student.IsActive = Boolean.Parse(reader["IsActive"].ToString());

                            students.Add(student);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return students;
        }

        public bool Add(Student entity)
        {
            bool IsSuccess = false;

            try
            {
                using (SqlConnection con = new SqlConnection(this.sqlconnectionstring))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Student(Name,IsActive) VALUES(@Name,@IsActive)", con);
                    cmd.Parameters.AddWithValue("@Name", entity.Name);
                    cmd.Parameters.AddWithValue("@IsActive", entity.IsActive);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        IsSuccess = true;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return IsSuccess;
        }

        public bool Update(Student entity)
        {
            bool IsSuccess = false;

            try
            {
                using (SqlConnection con = new SqlConnection(this.sqlconnectionstring))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Student SET Name=@Name, IsActive=@IsActive WHERE ID=@ID", con);
                    cmd.Parameters.AddWithValue("@ID", entity.ID);
                    cmd.Parameters.AddWithValue("@Name", entity.Name);
                    cmd.Parameters.AddWithValue("@IsActive", entity.IsActive);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        IsSuccess = true;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return IsSuccess;
        }

        public bool Delete(int id)
        {
            bool IsSuccess = false;

            try
            {
                using (SqlConnection con = new SqlConnection(this.sqlconnectionstring))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE Student WHERE ID=@ID", con);
                    cmd.Parameters.AddWithValue("@ID", id);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        IsSuccess = true;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return IsSuccess;
        }

        #endregion
    }
}
