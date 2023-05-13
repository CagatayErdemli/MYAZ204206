using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithmsApp
{
    public class SortingAppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public string path = @"E:\yazilim\cs\MYAZ204206\SortingAlgorithmsApp\Employee.db";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source={path}");
    }
}
