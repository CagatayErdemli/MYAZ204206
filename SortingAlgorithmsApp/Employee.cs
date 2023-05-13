using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithmsApp
{
    public class Employee : IComparable
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }

        public int CompareTo(object? obj)
        {
            Employee unboxed = (Employee)obj;
            return Id.CompareTo(unboxed.Id);
        }

        public override string ToString()
        {
            return $"{Id} - {FirstName} - {LastName} - {Salary}";
        }
    }
}
