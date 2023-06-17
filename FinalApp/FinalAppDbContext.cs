using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApp
{
    public class FinalAppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public string path = @"C:\Users\Emir Karataş\Desktop\MYAZ204206\FinalApp\Products.db";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source={path}");
    }
}
