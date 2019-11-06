using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiAnimate.Modelos;

namespace WebApiAnimate
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }
  
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-J6UEMIPR\\MSSQLSERVER2012;Initial Catalog=AnimateCrecer;Integrated Security=True");      
        }
        public DbSet<Producto> Productos { get; set; }


    }
}
