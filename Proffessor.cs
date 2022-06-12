using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentM
{
    internal class Proffessor:Faculty
    {
        public static List<Proffessor> proffessors = new List<Proffessor>();
        // employee number, phone number, e-mail, name, department, monthly salary, course, position, joining date
        private string? position;
        private List<Subject>? courses;

        public Proffessor(int employee_number, string name, string email, string? phone_number, Department department, double salary, string date_joined,string? position,List<Subject>? courses) : base(employee_number, name, email, phone_number, department, salary, date_joined)
        {
            this.position = position;
            this.courses = courses;
            proffessors.Add(this);
        }

        public string Position
        {
            get { return position; }
            set { position = value; }   
        }
        public List<Subject> Courses
        {
            get { return courses; }
            set { courses = value; }
        }

        // Update info
        public static void updateInfo(int id)
        {
            foreach(Proffessor proffessor in proffessors)
            {
                if (proffessor.Id == id)
                {
                    Console.WriteLine("Employee Number:");
                    proffessor.Id = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Name:");
                    proffessor.Name = Console.ReadLine();

                    Console.WriteLine("Email Address:");
                    proffessor.Email = Console.ReadLine();

                    Console.WriteLine("Phone Number:");
                    proffessor.PhoneNumber = Console.ReadLine();

                    Console.WriteLine("Salary:");
                    proffessor.Salary = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Date Joined:");
                    proffessor.DateJoined = Console.ReadLine();

                    Console.WriteLine("Position:");
                    proffessor.Position = Console.ReadLine();

                    Console.WriteLine("Proffessor updated\n");
                    break;
                }
            }
        }

        // Check courses
        
        public void checkCourse(string courseName)
        {
            if(Course.Courses.Count > 0)
            {
                Course course = Course.findCourse(courseName);
                if (course != null)
                {
                    foreach (Subject subject in course.Subjects)
                    {
                        Console.WriteLine(subject.Title);
                    }
                }
            }
            else
            {
                Console.WriteLine("You do not have any course so far");
            }
        }

        // View students
        public void viewStudent(int id)
        {
            Student student = Student.findStudent(id);
            if (student != null)
            {
                Console.WriteLine(student.ToString());
            }
            else
            {
                Console.WriteLine("Student with ID " + id + " is not found.");
            }
        }

        // Feed in grades

        public void enterGrades(int id,string name)
        {
            Student student = Student.findStudent(id);
            Course course = Course.findCourse(name);

            foreach(Subject subject in course.Subjects)
            {
                Console.WriteLine("Enter grade for " + subject.Title);
                int score = Convert.ToInt32(Console.ReadLine());
                new Grade(subject,student,score);
            }


        }

        // Manage lecture
        void ManageSubjects()
        {
            string MENU = "1: Check course subjects \n" +
                "2: Check student information \n" +
                "3: Fill in grades by subject and student\n" +
                "0: exit\n" +
                ">>> ";
            Console.WriteLine(MENU);

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Course name: ");
                    string courseName = Console.ReadLine();
                    checkCourse(courseName);
                    break;

                case 2:
                Console.WriteLine("Student ID: ");
                int studentID = Convert.ToInt32(Console.ReadLine());
                viewStudent(studentID);
                break;
                case 3:
                    Console.WriteLine("Student ID: ");
                    int stuId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Course Title: ");
                    string nameOfCourse = Console.ReadLine();
                    enterGrades(stuId, nameOfCourse);
                    break;
                    default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

            // , filling in grades by subject and student
        }

        //get Proffessor
        public static Proffessor findProffessor(int id)
        {
            Proffessor searchProffessor = null;

            foreach(Proffessor proffessor in proffessors)
            {
                if (proffessor.Id == id)
                {
                    searchProffessor = proffessor;
                }
            }
            return searchProffessor;
        }

        // Register
        public static Proffessor Register()
        {
            /*Person person = Person.personForm();*/
            Console.WriteLine("Fill in your details");
            Console.WriteLine("ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Phone: ");
            string phone_number = Console.ReadLine();

            Console.WriteLine("Salary: ");
            double salary = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Date Joined: ");
            string date_joined = Console.ReadLine();

            Console.WriteLine("Enter department name: ");
            string deptName = Console.ReadLine();
            Department department = Department.findDepartment(deptName);

            Console.WriteLine("Position: ");
            string position = Console.ReadLine();
            List<Subject> courses = new List<Subject>();

            /*Proffessor proffessor = (Proffessor)person;*/
            Proffessor proffessor = new Proffessor(id,name,email,phone_number,department,salary,date_joined,position,courses); ;

           
            return proffessor;
        }
        
        //Delete
        public static void deleteProf(int id)
        {
            Proffessor proffessor=findProffessor(id);
            if (proffessor != null)
            {
                proffessors.Remove(proffessor);
                Console.WriteLine("Proffessor deleted");
            }
            else
            {
                Console.WriteLine("Proffessor not found");
            }
        }

        static void proffessorMenu()
        {
            string MENU = "1: Update Info\n" +
                "2: Manage Subjects\n" +
                "0: Exit\n" +
                ">>>";
            Console.WriteLine(MENU);
        }
        public static void simulate(Proffessor proffessor)
        {
            while (true)
            {
                proffessorMenu();
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    Proffessor.updateInfo(proffessor.Id);
                }
                else if (choice == 2)
                {
                    proffessor.ManageSubjects();
                }
                else if (choice == 0)
                {
                    break;
                }

            }
        }

        public static void Login()
        {
            Console.WriteLine("Your ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Your email: ");
            string email = Console.ReadLine();

            Proffessor proffessor = findProffessor(id);

            if (proffessor != null && proffessor.Email == email)
            {
                Console.WriteLine("Welcome");
                Proffessor.simulate(proffessor);
            }
            else
            {
                Console.WriteLine("Invalid credentials");
            }
        }

        public override string ToString()
        {
            string proffInfo = base.ToString();
            proffInfo += "Position: " + position;
            return proffInfo;
        }
    }
}
