using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithmsApp.Comparers
{
    public class CompareByLastName : IComparer<Employee>
    {
        public int Compare(Employee? x, Employee? y)
        {
            return x.LastName.CompareTo(y.LastName);
        }
    }
}
