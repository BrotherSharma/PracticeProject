using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.Models;
using Npgsql;
using System.Data;


namespace MVC.Repositories
{
    public class StudentRepositories : CommanRepositories, IStudentRepositories
    {
        public void  Delete(int id)
        {
               using var command = new NpgsqlCommand("DELETE FROM t_student_crud WHERE c_student_id =@id", conn);
               command.CommandType = CommandType.Text;
               command.Parameters.AddWithValue("@id", id);

               conn.Open();
               command.ExecuteNonQuery();

               conn.Close();
        }

        public tblstudent GetOne(int id)
        {
             try
    {
        conn.Open();
        using var command = new NpgsqlCommand("SELECT * FROM t_student_crud WHERE c_student_id = @Id", conn);
        command.Parameters.AddWithValue("@Id", id);

        using var reader = command.ExecuteReader();

        if (reader.Read())
        {
            return new tblstudent
            {
                id = Convert.ToInt32(reader["c_student_id"]),
                studentname = reader["c_student_name"].ToString(),
                gender = reader["c_gender"].ToString(),
                address = reader["c_address"].ToString(),
                language = reader["c_language"].ToString(),
                course_id = Convert.ToInt32(reader["c_course_id"]),
                phonenumber = Convert.ToInt64(reader["c_phone_number"]),
                dbo = Convert.ToDateTime(reader["c_dateofbirth"]),
                image = reader["c_image"].ToString(),
                document = reader["c_document"].ToString()
            };
        }
        else
        {
            // Return null or handle case where student with the given ID is not found
            return null;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        // Handle exception (log, display error message, etc.)
        return null;
    }
    finally
    {
        conn.Close();
    }
        }

        public List<tblstudent> GetAll()
{
    List<tblstudent> students = new List<tblstudent>();

    try
    {
        conn.Open();
        using var command = new NpgsqlCommand("SELECT * FROM t_student_crud", conn);

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            tblstudent student = new tblstudent
            {
                id = Convert.ToInt32(reader["c_student_id"]),
                studentname = reader["c_student_name"].ToString(),
                gender = reader["c_gender"].ToString(),
                address = reader["c_address"].ToString(),
                language = reader["c_language"].ToString(),
                course_id = Convert.ToInt32(reader["c_course_id"]),
                phonenumber = Convert.ToInt64(reader["c_phone_number"]),
                dbo = Convert.ToDateTime(reader["c_dateofbirth"]),
                image = reader["c_image"].ToString(),
                document = reader["c_document"].ToString()
            };

            students.Add(student);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        // Handle exception (log, display error message, etc.)
    }
    finally
    {
        conn.Close();
    }

    return students;


        }

        public void Insert(tblstudent student)
        {
           conn.Open();
            using var command = new NpgsqlCommand("INSERT INTO t_student_crud(c_student_name, c_gender, c_address, c_language, c_course_id, c_phone_number, c_dateofbirth, c_image, c_document) VALUES (@studentname, @gender, @address, @language, @course_id, @phonenumber, @dbo, @image, @document)", conn);
            command.CommandType = CommandType.Text;

            // Set parameter values with explicit NpgsqlDbType
            command.Parameters.AddWithValue("@studentname", student.studentname);
            command.Parameters.AddWithValue("@gender", student.gender);
            command.Parameters.AddWithValue("@address", student.address);
            command.Parameters.AddWithValue("@language", student.language);
            // command.Parameters.AddWithValue("@course_id", student.course_id);
            command.Parameters.AddWithValue("@course_id", student.course_id);


            command.Parameters.AddWithValue("@phonenumber", student.phonenumber);
            command.Parameters.AddWithValue("@dbo", student.dbo);
            command.Parameters.AddWithValue("@image", student.image);
            command.Parameters.AddWithValue("@document", student.document);

            command.ExecuteNonQuery();
            conn.Close();
        }

        public void Update(tblstudent student)
        {
             conn.Open();
        using var command = new NpgsqlCommand("UPDATE t_student_crud SET c_student_name=@Name, c_gender=@Gender, c_address=@Address, c_language=@Languages, c_course_id=@Course, c_phone_number=@PhoneNumber, c_dateofbirth=@Dob, c_image=@PhotoPath, c_document=@DocumentPath WHERE c_student_id=@id ", conn);
        command.CommandType = CommandType.Text;
        command.Parameters.AddWithValue("@id", student.id); 
        command.Parameters.AddWithValue("@Name", student.studentname);
        command.Parameters.AddWithValue("@Gender", student.gender);
        command.Parameters.AddWithValue("@Address", student.address);
        command.Parameters.AddWithValue("@Languages", student.language);
        command.Parameters.AddWithValue("@Course", student.course_id);
        command.Parameters.AddWithValue("@PhoneNumber", student.phonenumber);
        command.Parameters.AddWithValue("@Dob", student.dbo);
        command.Parameters.AddWithValue("@PhotoPath",student.image);
        command.Parameters.AddWithValue("@DocumentPath",student.document);

         command.ExecuteNonQuery();
        conn.Close();


        }

         public List<tblCourse> GetCourseNames()
    {
        List<tblCourse> courses = new List<tblCourse>();
        try
        {
            conn.Open();
            using (var command = new NpgsqlCommand("SELECT c_course_id,c_course_name FROM t_course", conn))
            using (var dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                    var crs = new tblCourse
                    {
                        CourseID = Convert.ToInt32(dr["c_course_id"]),
                        CourseName = dr["c_course_name"].ToString()
                    };
                    courses.Add(crs);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching courses: {ex.Message}");
        }
        finally
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        return courses;
    }


    }
}