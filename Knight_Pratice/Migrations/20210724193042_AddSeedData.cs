using Microsoft.EntityFrameworkCore.Migrations;

namespace Knight_Pratice.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Datas",
                columns: new[] { "Data_Id", "Data_Input", "Data_Result" },
                values: new object[] { 1, "1", "1" });

            migrationBuilder.InsertData(
                table: "Datas",
                columns: new[] { "Data_Id", "Data_Input", "Data_Result" },
                values: new object[] { 2, "2", "2" });

            migrationBuilder.InsertData(
                table: "Datas",
                columns: new[] { "Data_Id", "Data_Input", "Data_Result" },
                values: new object[] { 3, "3", "FooFoo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Datas",
                keyColumn: "Data_Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Datas",
                keyColumn: "Data_Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Datas",
                keyColumn: "Data_Id",
                keyValue: 3);
        }
    }
}
