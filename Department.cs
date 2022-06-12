using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentM
{
    internal class Department
    {
        public static List<Department> departments=new List<Department>();
        // department attributes
        private string name;
        private string address;
        private string phone_number;
        private string assistant;
        private string email;
        private string website;

        // constructor
        public Department(string name, string address, string phone_number, string assistant, string email, string website)
        {
            this.name = name;
            this.address = address;
            this.phone_number = phone_number;
            this.assistant = assistant;
            this.email = email;
            this.website = website;
            departments.Add(this);
        }

        public string Name {
            get { return name; } 
            set { name = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string PhoneNumber
        {
            get { return phone_number; }
            set
            {
                phone_number = value;
            }
        }
        public string Assistant
        {
            get { return assistant; }
            set
            {
                assistant = value;
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
            }
        }
        public string Website
        {
            get { return website; }
            set => website = value;
        }
        // Department methods
        public static Department findDepartment(string name)
        {
            Department searchDepartment = null;
            foreach(Department department in departments)
            {
                if (department.name == name)
                {
                    searchDepartment = department;
                }
            }
            return searchDepartment;
        }

        public override string ToString()
        {
            return Name;
        }


    }
}
