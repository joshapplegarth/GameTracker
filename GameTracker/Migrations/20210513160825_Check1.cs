using Microsoft.EntityFrameworkCore.Migrations;

namespace GameTracker.Migrations
{
    public partial class Check1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Firstname", "IsAdmin", "Lastname", "Password" },
                values: new object[,]
                {
                    { 1, "j.applegarth@Example.com", "Joshua", true, "Applegarth", "qazQAZ1!" },
                    { 2, "c.mathews@Example.com", "Chris", false, "Mathews", "wsxWSX2@" },
                    { 3, "w.walker@Example.com", "Wayne", false, "Walker", "edcEDC3#" },
                    { 4, "s.aguirre@Example.com", "Sergio", false, "Aguirre", "rfvRFV4$" },
                    { 5, "m.thompson@Example.com", "Micah", false, "Thompson", "tgbTGB5%" }
                });
        }
    }
}
