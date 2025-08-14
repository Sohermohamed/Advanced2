using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced2
{
    class Department
    {
        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public  string Name { get; set; }

        public override string ToString()
        {
            return $"DeptID: {Id} , deptname: {Name} ";
        }


    }
}
