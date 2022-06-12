using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentM
{
    internal class Person
    {
        private int id;
        private string name;
        private string email;
        private string phone_number;
        private Department? department;

        //Users
        Student[] students=new Student[0];
        Proffessor[] proffessors=new Proffessor[0];
        Staff[] staffs=new Staff[0];

        // Constructor
        public Person(int id, string name, string email, string? phone_number, Department? department)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.phone_number = phone_number;
            this.department = department;
        }

        //properties
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
            }
        }
        public string PhoneNumber
        {
            get { return phone_number; }
            set
            {
                phone_number = value;
            }
        }
        public Department Department
        {
            get { return department; }
            set
            {
                department = value;
            }
        }

        // class methods
        public void login ()
        {

        }

        // person form
        /*public static Person personForm()
        {
            Console.WriteLine("ID: ");
            int id=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Email: ");
            string email=Console.ReadLine();
            Console.WriteLine("Phone: ");
            string phone_number=Console.ReadLine();
            Console.WriteLine("Enter department name: ");
            string deptName = Console.ReadLine();
            Department department = Department.findDepartment(deptName);

            return new Person(id, name, email, phone_number, department);
        }*/

        public override string ToString()
        {
            string studentInfo = "ID: " + Id + "Name: " + Name + " Email: " + Email + "Phone: " + PhoneNumber + "Department: " + Department;
            return studentInfo;
        }
    }
}
