using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentM
{
    internal class DepartmentAdmin:Proffessor
    {
        static List<DepartmentAdmin> deptAdmins=new List<DepartmentAdmin>();
        public DepartmentAdmin(int employee_number, string name, string email, string? phone_number, Department department, double salary, string date_joined, string position, List<Subject>? courses) : base(employee_number, name, email, phone_number, department, salary, date_joined, position, courses)
        {
            Position = "Department Admin";
            deptAdmins.Add(this);
        }

        static void studentManagement()
        {   
            Console.WriteLine("Enter ID");
            int stuID = Convert.ToInt32(Console.ReadLine());
            Student.updateStudent(stuID);
        }
        static void teachingManagement()
        {
            Console.WriteLine("Enter id: ");
            int profId = Convert.ToInt32(Console.ReadLine());

            Proffessor proffessor = Proffessor.findProffessor(profId);

            Console.WriteLine("Enter details to update: ");

            Console.WriteLine("Name: ");
            string PName = Console.ReadLine();
            Console.WriteLine("Email: ");
            string PEmail = Console.ReadLine();
            Console.WriteLine("Phone: ");
            string profPhone = Console.ReadLine();
            Console.WriteLine("Enter department name: ");
            string deptName = Console.ReadLine();
            Department department = Department.findDepartment(deptName);

            proffessor.Name = PName;
            proffessor.Email = PEmail;
            proffessor.PhoneNumber = profPhone;
            proffessor.Department = department;

            Console.WriteLine("Proffessor updated");
        }
        static void courseManagement()
        {
            Console.WriteLine("1: Open courses\n2: Assignment of professors\n3: Change of classrooms\n4: Enrollment student\n5: Removal students");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                /*Console.WriteLine("Subject Title");
                string title = Console.ReadLine();
                _ = new Subject(title);*/

                Console.WriteLine("Course Title");
                string name = Console.ReadLine();

                List<Subject> subjects = new List<Subject>();

                Console.WriteLine("Add subject to this course\nPress enter when done");
                while (true)
                {
                    Console.WriteLine("Title: ");
                    string title = Console.ReadLine();

                    if (title != "")
                    {
                        subjects.Add(new Subject(title));
                    }
                    else
                    {
                        break;
                    }
                }

                Course course = new Course(name, subjects);

                Console.WriteLine("Course Added");

            }
            else if(choice == 2)

            {
                Console.WriteLine("Proffessor ID: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Proffessor proffessor = Proffessor.findProffessor(id);

                Console.WriteLine("Enter title\nPress Enter when done");
                while (true)
                {
                    Console.WriteLine("Title: ");
                    string title = Console.ReadLine();
                    if (title != "")
                    {
                        proffessor.Courses.Add(new Subject("title"));
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else if(choice == 3)
            {
                Console.WriteLine("Class Name");
                string name = Console.ReadLine();

                Course course = Course.findCourse(name);

                if(course != null)
                {
                    Console.WriteLine("1: Change name\n2: Add subject\n");
                    int action = Convert.ToInt32(Console.ReadLine());
                    if (action == 1)
                    {
                        Console.WriteLine("New Name");
                        string newName = Console.ReadLine();
                        course.Name = newName;
                        Console.WriteLine("Name updated");
                    }else if (action == 2)
                    {
                        Console.WriteLine("Enter title\nPress Enter when done");
                        while (true)
                        {
                            Console.WriteLine("Title: ");
                            string title = Console.ReadLine();
                            if (title != "")
                            {
                                course.Subjects.Add(new Subject("title"));
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Class not found");
                }
            }
            else if(choice == 4)
            {
                Console.WriteLine("Student ID");
                int id = Convert.ToInt32(Console.ReadLine());

                Student student = Student.findStudent(id);
                if(student != null)
                {
                    Student.enrollCourse(student);
                }
            }
            else if (choice == 5)
            {
                Console.WriteLine("TODO");
            }

        }

        static DepartmentAdmin findAdmin(int id)
        {
            DepartmentAdmin searchAdmin = null;
            foreach (DepartmentAdmin admin in deptAdmins)
            {
                if (admin.Id == id)
                {
                    searchAdmin = admin;
                }
            }
            return searchAdmin;
        }
        static void adminMenu()
        {
            string MENU = "1: Student Management\n" +
                "2: Teaching Management\n" +
                "3: Course Management\n" +
                "0: Exit\n" +
                ">>>";
            Console.WriteLine(MENU);
        }
        public static void simulate()
        {
            while (true)
            {
                adminMenu();
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 0)
                {
                    break;
                }
                else
                {
                    switch (choice)
                    {
                        case 1:
                            studentManagement();
                            break;
                        case 2:
                            teachingManagement();
                            break;
                        case 3:
                            courseManagement();
                            break;
                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                }
            }
        }

        // Login
        public static new void login()
        {
            Console.WriteLine("Your ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Your email: ");
            string email = Console.ReadLine();

            DepartmentAdmin admin = findAdmin(id);

            if (admin != null && admin.Email == email)
            {
                Console.WriteLine("Welcome");
                DepartmentAdmin.simulate();
            }
            else
            {
                Console.WriteLine("Invalid credentials");
            }
        }

        // Register
        public static new DepartmentAdmin Register()
        {
            DepartmentAdmin admin = (DepartmentAdmin) Proffessor.Register();
            admin.Position = "Admin";
            return admin;
        }

        

    }
}
