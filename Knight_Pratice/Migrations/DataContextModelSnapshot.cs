﻿// <auto-generated />
using Knight_Pratice.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Knight_Pratice.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Knight_Pratice.Models.Data", b =>
                {
                    b.Property<int>("Data_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Data_Input")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Data_Result")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Data_Id");

                    b.ToTable("Datas");

                    b.HasData(
                        new
                        {
                            Data_Id = 1,
                            Data_Input = "1",
                            Data_Result = "1"
                        },
                        new
                        {
                            Data_Id = 2,
                            Data_Input = "2",
                            Data_Result = "2"
                        },
                        new
                        {
                            Data_Id = 3,
                            Data_Input = "3",
                            Data_Result = "FooFoo"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
