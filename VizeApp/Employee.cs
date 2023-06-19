using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VizeApp
{
    public class Employee : IComparable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public int CompareTo(object? obj)
        {
            Employee unboxed = (Employee)obj;
            return Name.CompareTo(unboxed.Name);
        }

        public override string ToString()
        {
            return $"Id: {Id,-20} Name: {Name,-40} Salary: {Salary}";
        }
    }
}
