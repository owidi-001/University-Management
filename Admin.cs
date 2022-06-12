using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentM
{
    internal class Admin:Proffessor
    {
        public static List<Admin> admins=new List<Admin>();
       
        public Admin(int employee_number, string name, string email, string? phone_number, Department department, double salary, string date_joined, string position, List<Subject>? courses) : base(employee_number, name, email, phone_number, department, salary, date_joined, position, courses)
        {
            this.Position = "Admin";
            admins.Add(this);
        }

        static void subjectManagement()
        {
            Console.WriteLine("Enter title: ");
            string title = Console.ReadLine();
            _ = new Subject(title);
            
        }
        static void studentManagement()
        {
            Console.WriteLine("1: Add Student\n2: Update Student\n3: Delete Student\n");
            int choice = Convert.ToInt32(Console.ReadLine());

            if(choice == 1)
            {
                Student.Register();
            }else if (choice == 2)
            {
                Console.WriteLine("Enter ID");
                int stuID = Convert.ToInt32(Console.ReadLine());
                Student.updateStudent(stuID);
            }
            else if (choice == 3)
            {
                Console.WriteLine("Enter ID");
                int stuID = Convert.ToInt32(Console.ReadLine());
                Student.deleteStudent(stuID);
            }
        }
        static void teachingManagement()
        {
            Console.WriteLine("1: Add Proffessor\n2: Update Proffessor\n3: Delete Proffessor\n");
            int choice = Convert.ToInt32(Console.ReadLine());

            // Add Proffessor
            if (choice == 1)
            {
                //Call base add
                Proffessor.Register();
                
            }
            //Edit proffessor
            else if (choice == 2)
            {
                Console.WriteLine("Enter id: ");
                int profId = Convert.ToInt32(Console.ReadLine());

                Proffessor.updateInfo(profId);

                Console.WriteLine("Proffessor updated");
            }else if (choice == 3)
            {
                Console.WriteLine("Enter id: ");
                int profId = Convert.ToInt32(Console.ReadLine());

                Proffessor.deleteProf(profId);
            }
            


            // Department department, double salary, string date_joined,string position,List<Course> courses) : base(employee_number, name, email, phone_number, department, salary, date_joined
            Console.WriteLine("Enter proffessor details");
            Console.WriteLine("Employee Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Email:");
            string email= Console.ReadLine();
            Console.WriteLine("Phone Number");
            string phone= Console.ReadLine();
            //string phone= Console.ReadLine();


        }
        static void departmentManagement()
        {
            Console.WriteLine("Department Managemnet");
            Console.WriteLine("1: Add new\n" +
                "2: Update Existing\n");

            int action = Convert.ToInt32(Console.ReadLine());

            if (action == 1)
            {
                Console.WriteLine("Fill in department details");
                Console.WriteLine("Name: ");
                string name=Console.ReadLine();
                Console.WriteLine("Address: ");
                string address=Console.ReadLine();
                Console.WriteLine("Phone : ");
                string phone_number=Console.ReadLine();
                Console.WriteLine("Assistant: ");
                string assistant=Console.ReadLine();
                Console.WriteLine("Email: ");
                string email= Console.ReadLine();
                Console.WriteLine("Website: ");
                string website= Console.ReadLine();

                new Department(name, address, phone_number, assistant, email, website);
                Console.WriteLine("Department Created!\n");
            }
            else if (action == 2)
            {
                Console.WriteLine("Enter department name: ");
                Console.WriteLine("Name: ");
                string name = Console.ReadLine();

                Department department = Department.findDepartment(name);
                if(department != null)
                {
                    Console.WriteLine("Fill in New Details\n Leave blank to preserve\n");
                    Console.WriteLine("Name: ");

                    string deptName = Console.ReadLine();
                    Console.WriteLine("Address: ");
                    string address = Console.ReadLine();
                    Console.WriteLine("Phone : ");
                    string phone_number = Console.ReadLine();
                    Console.WriteLine("Assistant: ");
                    string assistant = Console.ReadLine();
                    Console.WriteLine("Email: ");
                    string email = Console.ReadLine();
                    Console.WriteLine("Website: ");
                    string website = Console.ReadLine();

                    if(deptName != "")
                    {
                        department.Name = deptName;
                    }
                    if(address != "")
                    {
                        department.Address = address;
                    }
                    if(phone_number != "")
                    {
                        department.PhoneNumber = phone_number;
                    }
                    if(assistant != "")
                    {
                        department.Assistant = assistant;
                    }
                    if(email != "")
                    {
                        department.Email = email;
                    }
                    if(website != "")
                    {
                        department.Website = website;
                    }
                    
                    Console.WriteLine("Department Updated !\n");
                }
                else
                {
                    Console.WriteLine("Department not found!");
                }
                
            }
            else
            {
                Console.WriteLine("Invalid choice");
            }

        }
        static void adminMenu()
        {
            string MENU = "1: Department Management\n" +
                "2: Teaching Management\n" +
                "3: Student Management\n" +
                "4: Subject Management\n" +
                "0: Exit\n" +
                ">>>";
            Console.WriteLine(MENU);
        }

        public static Admin findAdmin(int id)
        {
            Admin searchAdmin = null;
            foreach(Admin admin in admins)
            {
                if (admin.Id == id)
                {
                    searchAdmin = admin;
                }
            }
            return searchAdmin;
        }
        public static void simulate(Admin admin)
        {
            while (true)
            {
                adminMenu();
                int choice=Convert.ToInt32(Console.ReadLine());

                if(choice == 0)
                {
                    break;
                }
                else
                {
                    switch (choice)
                    {
                        case 1:
                            departmentManagement();
                            break;
                        case 2:
                            teachingManagement();
                            break;
                        case 3:
                            studentManagement();
                            break;
                        case 4:
                            subjectManagement();
                            break;
                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                }
            }
        }
        
        // Admin login
        public static new void Login()
        {
            Console.WriteLine("Your ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Your email: ");
            string email = Console.ReadLine();

            Admin admin = findAdmin(id);

            if(admin != null && admin.Email==email)
            {
                Console.WriteLine("Welcome");
                Admin.simulate(admin);
            }
            else
            {
                Console.WriteLine("Invalid credentials");
            }
        }

        // Register
        public static new Admin Register()
        {
            Admin admin = (Admin) Proffessor.Register();
            admin.Position = "Admin";
            return admin;
        }
    }
}
