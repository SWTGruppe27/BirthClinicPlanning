using Microsoft.EntityFrameworkCore.Migrations;

namespace BirthClinicPlanning.Migrations
{
    public partial class add_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Births",
                column: "BirthId",
                value: 1);

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "RelativesId", "FullName", "Relation", "RestRoomId" },
                values: new object[] { 2, "Pia Jensen", null, 2 });

            migrationBuilder.InsertData(
                table: "BirthRooms",
                columns: new[] { "RoomNumber", "BirthId", "EmployeeId", "RoomType" },
                values: new object[] { 1, 1, 0, "BirthRoom" });

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "CprNumber", "BirthId" },
                values: new object[] { 111111, 1 });

            migrationBuilder.InsertData(
                table: "Mothers",
                columns: new[] { "RelativesId", "CPRNumber" },
                values: new object[] { 2, "000000000" });

            migrationBuilder.InsertData(
                table: "RestRooms",
                columns: new[] { "RoomNumber", "RoomType", "Type" },
                values: new object[] { 2, "Restroom", "RestRoom4Hours" });

            migrationBuilder.InsertData(
                table: "Clinicians",
                columns: new[] { "EmployeeId", "BirthRoomId", "FullName", "Position", "Title" },
                values: new object[] { 1, 1, "Line Hansen", null, null });

            migrationBuilder.InsertData(
                table: "RestRoom4Hours",
                column: "RoomNumber",
                value: 2);

            migrationBuilder.InsertData(
                table: "Midwifes",
                column: "EmployeeId",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Children",
                keyColumn: "CprNumber",
                keyValue: 111111);

            migrationBuilder.DeleteData(
                table: "Midwifes",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Mothers",
                keyColumn: "RelativesId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RestRoom4Hours",
                keyColumn: "RoomNumber",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RestRooms",
                keyColumn: "RoomNumber",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BirthRooms",
                keyColumn: "RoomNumber",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Relatives",
                keyColumn: "RelativesId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Births",
                keyColumn: "BirthId",
                keyValue: 1);
        }
    }
}
