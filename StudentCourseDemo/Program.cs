using StudentCourseDemo;
using System;

namespace StudentCourseDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EnrollmentController ec = new EnrollmentController();
            bool running = true;

            while (running)
            {
                try
                {
                    Console.WriteLine("\n========== Course Enrollment System ==========");
                    Console.WriteLine("1. Add Student");
                    Console.WriteLine("2. View Students");
                    Console.WriteLine("3. Add Course");
                    Console.WriteLine("4. View Courses");
                    Console.WriteLine("5. Enroll Student in Course");
                    Console.WriteLine("6. View All Enrollments");
                    Console.WriteLine("7. Search Student Enrollments");
                    Console.WriteLine("8. Delete Enrollment");
                    Console.WriteLine("9. Exit");
                    Console.Write("Enter option (1-9): ");

                    string choice = Console.ReadLine();
                    Console.WriteLine(); // Separation space layout

                    switch (choice)
                    {
                        case "1":
                            Console.Write("Enter Student ID: ");
                            int sId = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter Student Name: ");
                            string sName = Console.ReadLine();
                            Console.Write("Enter Email: ");
                            string email = Console.ReadLine();
                            Console.Write("Enter Department: ");
                            string dept = Console.ReadLine();

                            // Creating Object mapping values directly
                            Students student = new Students
                            {
                                StudentId = sId,
                                StudentName = sName,
                                Email = email,
                                Department = dept
                            };
                            ec.AddStudent(student);
                            break;

                        case "2":
                            ec.ViewStudents();
                            break;

                        case "3":
                            Console.Write("Enter Course ID: ");
                            int cId = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter Course Name: ");
                            string cName = Console.ReadLine();
                            Console.Write("Enter Duration (Hours): ");
                            int duration = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter Fee: ");
                            decimal fee = Convert.ToDecimal(Console.ReadLine());

                            Courses course = new Courses
                            {
                                CourseId = cId,
                                CourseName = cName,
                                Duration = duration,
                                Fee = fee
                            };
                            ec.AddCourse(course);
                            break;

                        case "4":
                            ec.ViewCourses();
                            break;

                        case "5":
                            Console.Write("Enter Student ID for Enrollment: ");
                            int enrollSId = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter Course ID for Enrollment: ");
                            int enrollCId = Convert.ToInt32(Console.ReadLine());

                            Enrollment enrollment = new Enrollment
                            {
                                StudentId = enrollSId,
                                CourseId = enrollCId,
                                EnrollmentDate = DateTime.Now
                            };
                            ec.EnrollStudent(enrollment);
                            break;

                        case "6":
                            ec.ViewAllEnrollments();
                            break;

                        case "7":
                            Console.Write("Enter Student ID to Search Enrollments: ");
                            int searchSId = Convert.ToInt32(Console.ReadLine());
                            ec.SearchStudentEnrollments(searchSId);
                            break;

                        case "8":
                            Console.Write("Enter Enrollment ID to Delete: ");
                            int delEId = Convert.ToInt32(Console.ReadLine());
                            ec.DeleteEnrollment(delEId);
                            break;

                        case "9":
                            Console.WriteLine("Exiting application. Thank you!");
                            running = false;
                            break;

                        default:
                            Console.WriteLine("Invalid option! Pick any choices from 1 to 9.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Input Error: You should not pass text elements into the numbers character string parameter matrix format field layer!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("System Error occurred: " + ex.Message);
                }
            }
        }
    }
}
