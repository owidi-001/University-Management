// See https://aka.ms/new-console-template for more information
using studentM;

class Program
{
    static void showObjects()
    {
        // Proffessors
        Console.WriteLine("Proffessors: ");
        foreach(Proffessor proffessor in Proffessor.proffessors)
        {
            Console.WriteLine(proffessor.ToString());
        }
        Console.WriteLine("\n");

        // Students
        Console.WriteLine("Students: ");
        foreach (Student student in Student.Students)
        {
            Console.WriteLine(student.ToString());
        }
        Console.WriteLine("\n");

        // Subjects
        Console.WriteLine("Subjects: ");
        foreach (Subject subject in Subject.subjects)
        {
            Console.WriteLine(subject.ToString());
        }
        Console.WriteLine("\n");

        // Departments
        Console.WriteLine("Departments: ");
        foreach (Department department in Department.departments)
        {
            Console.WriteLine(department.ToString());
        }
        Console.WriteLine("\n");
    }
    static void Main(string[] args)
    {
        // Initialize information
        //Departments
        Department department1 = new Department("Science", "Lower street2", "01234567", "proff2", "dept1@mail.com", "www.dept1.com");
        Department department2 = new Department("Math", "Lower street1", "01234567", "proff1", "dept2@mail.com", "www.dept2.com");

        // Course Subjects
        Subject subject1 = new Subject("Comp212");
        Subject subject2 = new Subject("Comp200");
        Subject subject3 = new Subject("Comp341");


        // Subject Lists
        List<Subject> test_subjects = new List<Subject>();
        test_subjects.Add(subject1);
        test_subjects.Add(subject2);
        test_subjects.Add(subject3);

        //Admin
        Admin admin = new Admin(1, "proff1", "email@proff1", "01234567", department1, 1000, "10/10/2011", "Admin", test_subjects);

        DepartmentAdmin dAdmin = new DepartmentAdmin(1, "proff1", "email@proff1", "01234567", department1, 1000, "10/10/2011", "Admin", test_subjects);

        //Proffessors
        //Proffessor(int employee_number, string name, string email, string? phone_number, Department department, double salary, string date_joined,string? position,List<Subject>? courses)
        Proffessor proffessor1 = new Proffessor(1, "proff1", "email@proff1", "01234567", department1, 1000, "10/10/2011", "Proffessor", test_subjects);
        Proffessor proffessor2 = new Proffessor(2, "proff2", "email@proff2", "01234567", department1, 1000, "10/10/2011", "DeptAdmin", test_subjects);
        Proffessor proffessor3 = new Proffessor(3, "proff3", "email@proff3", "01234567", department1, 1000, "10/10/2011", "Proffessor", test_subjects);

        //Students
        Student student1 = new Student(101, "student1", "student1@mail.com", "0987654321", department1, "yes", test_subjects);
        Student student2 = new Student(102, "student2", "student1@mail.com", "0287654321", department1, "yes", test_subjects);
        Student student3 = new Student(103, "student3", "student1@mail.com", "0937654321", department1, "yes", test_subjects);
        Student student4 = new Student(104, "student4", "student1@mail.com", "0984654321", department1, "No", test_subjects);
        Student student5 = new Student(105, "student5", "student1@mail.com", "0987554321", department1, "yes", test_subjects);
        Student student6 = new Student(106, "student6", "student1@mail.com", "0987664321", department1, "No", test_subjects);
        Student student7 = new Student(107, "student7", "student1@mail.com", "0987657321", department1, "yes", test_subjects);
        Student student8 = new Student(108, "student8", "student1@mail.com", "0987654821", department1, "No", test_subjects);
        Student student9 = new Student(109, "student9", "student1@mail.com", "0987654391", department1, "yes", test_subjects);
        Student student0 = new Student(100, "student0", "student1@mail.com", "0987654320", department1, "yes", test_subjects);

        while (true)
        {
            // Start menu
            /*Console.WriteLine("1: Register\n2: Login\n0: Exit");*/
            Console.WriteLine("1: Login\n0: Exit");
            int action = Convert.ToInt32(Console.ReadLine());


            if (action == 0)
            {
                break;
            }
            else
            {

                //print objects
                showObjects();

                Console.WriteLine("Log in as:\n1: Admin\n2: Department Admin\n3: Proffessor\n4: Student\n");
                int userType=Convert.ToInt32(Console.ReadLine());

                if(userType == 1)
                {
                    Console.WriteLine("Welcome to admin portal");
                    Admin.simulate(admin);
                }
                else if(userType == 2)
                {
                    Console.WriteLine("Welcome to Department admin portal");
                    DepartmentAdmin.simulate(dAdmin);
                }
                else if (userType == 3)
                {
                    Console.WriteLine("Welcome to proffessor portal");
                    Proffessor.simulate(proffessor1);
                }
                else if (userType == 4)
                {
                    Console.WriteLine("Welcome to student portal");
                    Student.simulate(student1);
                }
            }

            /*if (action == 0)
            {
                break;
            }
            else if (action == 1)
            {
                Console.WriteLine("Register in as\n 1: School Admin\n 2: Department Admin\n 3: Proffessor\n 4: Student\n >>> ");
                int userType = Convert.ToInt32(Console.ReadLine());

                switch (userType)
                {
                    case 1:
                        Console.WriteLine("Admin Register");
                        Admin admin = Admin.Register();
                        if (admin != null)
                        {
                            Admin.simulate(admin);
                        }
                        break;
                    case 2:
                        Console.WriteLine("Dep Admin");
                        DepartmentAdmin departmentAdmin = DepartmentAdmin.Register();
                        if (departmentAdmin != null)
                        {
                            DepartmentAdmin.simulate(departmentAdmin);
                        }
                        break;
                    case 3:
                        Console.WriteLine("Proffessor");
                        Proffessor proffessor = Proffessor.Register();
                        if (proffessor != null)
                        {
                            Proffessor.simulate(proffessor);
                        }
                        break;
                    case 4:
                        Console.WriteLine("Student");
                        Student student = Student.Register();
                        if (student != null)
                        {
                            Student.simulate(student);
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
            else if (action == 2)
            {
                Console.WriteLine("Log in as\n 1: School Admin\n 2: Department Admin\n 3: Proffessor\n 4: Student\n >>> ");
                int userType = Convert.ToInt32(Console.ReadLine());

                switch (userType)
                {
                    case 1:
                        Console.WriteLine("Admin Login");
                        Admin.Login();
                        break;
                    case 2:
                        Console.WriteLine("Dep Admin");
                        DepartmentAdmin.login();
                        break;
                    case 3:
                        Console.WriteLine("Proffessor");
                        Proffessor.Login();
                        break;
                    case 4:
                        Console.WriteLine("Student");
                        Student.Login();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid choice");
            }*/
        }
    
    }
}
