using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentM
{
    internal class Faculty : Person
    {
        int employee_number;
        double salary;
        string date_joined;
        public Faculty(int employee_number, string name, string email, string? phone_number, Department department, double salary, string date_joined) : base(employee_number, name, email, phone_number, department)
        {
            this.salary = salary;
            this.date_joined = date_joined;
        }

        public int EmployeeNumber
        {
            get { return employee_number; }
            set { employee_number = value; }
        }
        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        public string DateJoined
        {
            get { return date_joined; }
            set
            {
                date_joined = value;
            }
        }

      
        
    }
}
