using Microsoft.EntityFrameworkCore.Migrations;

namespace BirthClinicPlanning.Migrations
{
    public partial class addedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "RestRooms");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Clinicians");

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Doctors_Clinicians_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Clinicians",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaternityRooms",
                columns: table => new
                {
                    RoomNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaternityRooms", x => x.RoomNumber);
                    table.ForeignKey(
                        name: "FK_MaternityRooms_RestRooms_RoomNumber",
                        column: x => x.RoomNumber,
                        principalTable: "RestRooms",
                        principalColumn: "RoomNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Midwifes",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Midwifes", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Midwifes_Clinicians_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Clinicians",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Nurses",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nurses", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Nurses_Clinicians_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Clinicians",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RestRoom4Hours",
                columns: table => new
                {
                    RoomNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestRoom4Hours", x => x.RoomNumber);
                    table.ForeignKey(
                        name: "FK_RestRoom4Hours_RestRooms_RoomNumber",
                        column: x => x.RoomNumber,
                        principalTable: "RestRooms",
                        principalColumn: "RoomNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sosu",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sosu", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Sosu_Clinicians_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Clinicians",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "MaternityRooms");

            migrationBuilder.DropTable(
                name: "Midwifes");

            migrationBuilder.DropTable(
                name: "Nurses");

            migrationBuilder.DropTable(
                name: "RestRoom4Hours");

            migrationBuilder.DropTable(
                name: "Sosu");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "RestRooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Clinicians",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
