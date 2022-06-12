using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentM
{
    internal class Assistant : Faculty
    {
        Subject assignment;
        public Assistant(int employee_number, string name, string email, string? phone_number, Department department, double salary, string date_joined, Subject assignment) : base(employee_number, name, email, phone_number, department, salary, date_joined)
        {
            this.assignment = assignment;   
        }
    }
}
