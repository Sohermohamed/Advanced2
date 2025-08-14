using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced2
{
    class Employee
    {
        public Employee(int id, string name, double salary, int deptId)
        {
            Id = id;
            Name = name;
            Salary = salary;
            DeptId = deptId;
           
        }

        public int Id { get; set; }
        public String Name { get; set; }

        public double Salary { get; set; }

        public int DeptId { get; set; }

        public override string ToString()
        {
            return $"empID: {Id} , empname: { Name } , empsalary: {Salary} ";
            ;
            ;
        }

    }
}
