using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Knight_Pratice.Models;
using Microsoft.EntityFrameworkCore;

namespace Knight_Pratice.Context
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
            
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=10.11.210.43;User=sa;Password=Ohmygodslp12;Database=Knight_DataDB");
        }

        public virtual  DbSet<Data> Datas { get; set; }
    }
}
