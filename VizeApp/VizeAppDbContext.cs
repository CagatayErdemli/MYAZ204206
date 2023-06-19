using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VizeApp
{
    public class VizeAppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public string path = @"C:\Users\Emir Karataş\Desktop\MYAZ204206\VizeApp\Database.db";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source={path}");
    }
}
