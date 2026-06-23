using MySql.Data.MySqlClient;
using StudentCourseDemo;
using System;
using System.Data;
namespace StudentCourseDemo
{
    public class EnrollmentController
{
    
    private string connectionString = "Server=localhost;Database=StudentCourse;Uid=root;Pwd=Poorni.10;";

        // 1. ADD STUDENT
        public void AddStudent(Students student)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(student.StudentName))
                    throw new Exception("Student Name cannot be empty.");

                if (string.IsNullOrWhiteSpace(student.Email))
                    throw new Exception("Email cannot be empty.");

                if (!student.Email.Contains("@") || !student.Email.Contains("."))
                    throw new Exception("Invalid Email Format. Example: student@gmail.com");

                if (string.IsNullOrWhiteSpace(student.Department))
                    throw new Exception("Department cannot be empty.");

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "insert into Students values(@Id, @Name, @Email, @Dept)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    
                    cmd.Parameters.AddWithValue("@Id", student.StudentId);
                    cmd.Parameters.AddWithValue("@Name", student.StudentName);
                    cmd.Parameters.AddWithValue("@Email", student.Email);
                    cmd.Parameters.AddWithValue("@Dept", student.Department);

                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Student Added Successfully");
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                    Console.WriteLine("Student ID already exists.");
                else
                    Console.WriteLine("Database Error : " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        // 2. VIEW STUDENTS
        public void ViewStudents()
    {
        try
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "select * from Students";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader data = cmd.ExecuteReader();

                Console.WriteLine("ID\tStudentName\tEmail\tDepartment");
                Console.WriteLine("=============================================");
                while (data.Read())
                {
                    Console.WriteLine(data["StudentId"] + "\t" + data["StudentName"] + "\t" + data["Email"] + "\t" + data["Department"]);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

        // 3. ADD COURSE
        public void AddCourse(Courses course)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(course.CourseName))
                    throw new Exception("Course Name cannot be empty.");

                if (course.Duration <= 0)
                    throw new Exception("Duration must be greater than 0.");

                if (course.Fee <= 0)
                    throw new Exception("Course Fee must be greater than 0.");

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "insert into Courses values(@Id, @Name, @Duration, @Fee)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Id", course.CourseId);
                    cmd.Parameters.AddWithValue("@Name", course.CourseName);
                    cmd.Parameters.AddWithValue("@Duration", course.Duration);
                    cmd.Parameters.AddWithValue("@Fee", course.Fee);

                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Course Added Successfully");
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                    Console.WriteLine("Course ID already exists.");
                else
                    Console.WriteLine("Database Error : " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        // 4. VIEW COURSES
        public void ViewCourses()
    {
        try
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "select * from Courses";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("ID\tCourseName\tDuration\tFee");
                Console.WriteLine("=============================================");
                while (reader.Read())
                {
                    Console.WriteLine(reader["CourseId"] + "\t" + reader["CourseName"] + "\t" + reader["Duration"] + "\t" + reader["Fee"]);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

        // 5. ENROLL STUDENT IN COURSE
        public void EnrollStudent(Enrollment enroll)
        {
            try
            {
                if (enroll.StudentId <= 0)
                    throw new Exception("Please enter a valid Student ID.");

                if (enroll.CourseId <= 0)
                    throw new Exception("Please enter a valid Course ID.");

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "insert into Enrollments(StudentId, CourseId, EnrollmentDate) values(@SId, @CId, @EDate)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@SId", enroll.StudentId);
                    cmd.Parameters.AddWithValue("@CId", enroll.CourseId);
                    cmd.Parameters.AddWithValue("@EDate", enroll.EnrollmentDate);

                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Student Enrolled Successfully");
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1452)
                    Console.WriteLine("Student ID or Course ID does not exist.");
                else
                    Console.WriteLine("Database Error : " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // 6. VIEW ALL ENROLLMENTS (JOIN QUERY)
        public void ViewAllEnrollments()
    {
        try
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "select e.EnrollmentId, s.StudentName, c.CourseName, e.EnrollmentDate from Enrollments e join Students s on e.StudentId = s.StudentId join Courses c on e.CourseId = c.CourseId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("EnrollID\tStudentName\tCourseName\tDate");
                Console.WriteLine("=============================================");
                while (reader.Read())
                {
                    Console.WriteLine(reader["EnrollmentId"] + "\t" + reader["StudentName"] + "\t" + reader["CourseName"] + "\t" + reader["EnrollmentDate"]);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    // 7. SEARCH STUDENT ENROLLMENTS
    public void SearchStudentEnrollments(int studentId)
    {
        try
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "select s.StudentName, c.CourseName, e.EnrollmentDate from Enrollments e join Students s on e.StudentId = s.StudentId join Courses c on e.CourseId = c.CourseId where s.StudentId = @SId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SId", studentId);
                MySqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("StudentName\tCourseName\tDate");
                Console.WriteLine("=============================================");
                while (reader.Read())
                {
                    Console.WriteLine(reader["StudentName"] + "\t" + reader["CourseName"] + "\t" + reader["EnrollmentDate"]);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    // 8. DELETE ENROLLMENT
    public void DeleteEnrollment(int enrollmentId)
    {
        try
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "delete from Enrollments where EnrollmentId = @EId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EId", enrollmentId);

                cmd.ExecuteNonQuery();
                Console.WriteLine("Enrollment Deleted Successfully");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
}   
