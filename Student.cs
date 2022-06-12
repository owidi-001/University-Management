using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentM
{
    internal class Student : Person
    {
        static List<Student> students=new List<Student>();


        // beneficiary scholarship details, courses and grades for each semester, student search (school number, phone number, email, name, department of study)
        int student_number;
        string beneficiary;
        List<Subject> courses=new List<Subject>();
        List<Grade> grades=new List<Grade>();

        public Student(int student_number, string? name, string? email, string? phone_number, Department department, string? beneficiary, List<Subject> courses)
            :base(student_number,name,email,phone_number,department)
        {
            this.beneficiary = beneficiary;
            this.courses = courses;
            students.Add(this);
        }        

        
        // Student methods
        public static void updateStudent(int id)
        {
            // get student
            Student student = Student.findStudent(id);


            if (student != null)
            {
                Console.WriteLine("Student Number:");
                student.student_number = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Name:");
                student.Name = Console.ReadLine();

                Console.WriteLine("Email Address:");
                student.Email = Console.ReadLine();

                Console.WriteLine("Phone Number:");
                student.PhoneNumber = Console.ReadLine();

                Console.WriteLine("Beneficiary:");
                student.beneficiary = Console.ReadLine();

                Console.WriteLine("Student info updated\n");

            }
        }
        
        public static List<Student> Students
        {
            get { return students; }
        }

        void displaySubjects()
        {
            if(courses.Count > 0)
            {
                foreach (Subject subject in courses)
                {
                    Console.WriteLine(subject.Title);
                }
            }
            else
            {
                Console.WriteLine("You do not have any course so far");
            }
        }
        public static void enrollCourse(Student student)
        {

            Console.WriteLine("Enter title\nPress Enter when done");
            while (true)
            {
                Console.WriteLine("Title: ");
                string title = Console.ReadLine();
                if (title != "")
                {
                    student.courses.Add(new Subject("title"));
                }
                else
                {
                    break;
                }
            }
        }
        void removeSubject()
        {
            Console.WriteLine("Subject Title: ");
            string title = Console.ReadLine();
            
            foreach (Subject subject in courses)
            {
                if (subject.Title == title)
                {
                    courses.Remove(subject);
                }
            }
            
        }
        void checkGrades()
        {
            if (courses.Count > 0)
            {
                Console.WriteLine("Name:".PadRight(10) + "Score");
                foreach (Subject subject in courses)
                {
                    foreach( Grade grade in grades)
                    {
                        if (subject == grade.Subject && grade.Student==this)
                        {
                            Console.WriteLine(subject.Title.PadRight(10) + grade.Score);
                        }
                    }
                    
                }
            }
            else
            {
                Console.WriteLine("You do not have any course so far");
            }
        }
        void manageCourses(Student student)
        {
            // Course menu
            string MENU = "1: Show courses \n" +
                "2: Apply Course \n" +
                "3: Remove course \n" +
                "4: Check grade \n" +
                "0: Exit\n" +
                ">>> ";
            Console.WriteLine(MENU);
            int choice=Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1: 
                    displaySubjects();
                    break;

                case 2:
                    enrollCourse(student);
                    break;
                case 3:
                    removeSubject();
                    break;
                case 4:
                    checkGrades();
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Invalid input\n Choose 1-3");
                    break;
            }
        }

        // Search student
        public static Student findStudent(int id)
        {
            Student myStudent = null;
            foreach (Student student in Student.Students)
            {
                if (student.Id == id)
                {
                    myStudent = student;
                }
            }
            return myStudent;
        }

        // Register student
        public static Student Register()
        {
            /*Person person=Person.personForm();*/            

            Console.WriteLine("Fill in your details");
            Console.WriteLine("Student Number: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Phone: ");
            string phone_number = Console.ReadLine();

            Console.WriteLine("Enter department name: ");
            string deptName = Console.ReadLine();
            Department department = Department.findDepartment(deptName);

            Console.WriteLine("Beneficiary: ");
            string benefiaciary = Console.ReadLine();

            List<Subject> courses=new List<Subject>();

            Student student = new Student(id, name, email, phone_number, department, benefiaciary, courses);

            return student;
        }
        // Update Student
        /*public static void updateStudent(int id)
        {
            Student student = findStudent(id);

            if(student != null)
            {
                Person person = Person.personForm();

                Console.WriteLine("Beneficiary: ");
                string benefiaciary = Console.ReadLine();
                List<Subject> courses = new List<Subject>();

                student = (Student)person;

                student.beneficiary = benefiaciary;
                student.courses = courses;
                Console.WriteLine("Student updated");
            }
            else
            {
                Console.WriteLine("Student not found");
            }
        }*/
        // Delete student
        public static void deleteStudent(int id)
        {
            Student student = findStudent(id);

            if(student != null)
            {
                students.Remove(student);
            }
            else
            {
                Console.WriteLine("Student not found");
            }
        }

        // student menu
        static void studentMenu()
        {
            string MENU = "1: Update Info\n" +
                "2: Manage Course\n" +
                "3: Check Grade\n" +
                "0: Exit\n" +
                ">>>";
            Console.WriteLine(MENU);
        }
        public static void simulate(Student student)
        {
            while (true)
            {
                studentMenu();
                int choice = Convert.ToInt32(Console.ReadLine());

                if(choice == 1)
                {
                    updateStudent(student.Id);
                }
                else if(choice == 2)
                {
                    student.manageCourses(student);
                }
                else if(choice == 3)
                {
                    Console.WriteLine("Your grades");
                    student.checkGrades();
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

            Student student = findStudent(id);

            if (student != null && student.Email == email)
            {
                Console.WriteLine("Welcome");
                Student.simulate(student);
            }
            else
            {
                Console.WriteLine("Invalid credentials");
            }
        }

        // To string
        public override string ToString()
        {
            string studentInfo =base.ToString();
            studentInfo += "Beneficiary: " + beneficiary;
            return studentInfo;
        }

    }
}
