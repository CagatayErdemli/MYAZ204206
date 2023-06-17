using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApp
{
    public class Product : IComparable
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }

        public int CompareTo(object? obj)
        {
            Product unboxed = (Product)obj;
            return Price.CompareTo(unboxed.Price);
        }

        public override string ToString()
        {
            return $"Id: {Id,-20} Name: {ProductName,-40} Price: {Price}";
        }
    }
}
