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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Data>().HasData(
                new Data{Data_Id = 1,Data_Input = "1",Data_Result = "1"},
                new Data{Data_Id = 2,Data_Input = "2",Data_Result = "2"},
                new Data{Data_Id = 3,Data_Input = "3",Data_Result = "FooFoo" }
                
                );
        }

        public virtual  DbSet<Data> Datas { get; set; }
    }
}
