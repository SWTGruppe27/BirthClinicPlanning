using Microsoft.EntityFrameworkCore.Migrations;

namespace BirthClinicPlanning.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Births",
                columns: table => new
                {
                    BirthId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Births", x => x.BirthId);
                });

            migrationBuilder.CreateTable(
                name: "Relatives",
                columns: table => new
                {
                    RelativesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestRoomId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Relation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatives", x => x.RelativesId);
                });

            migrationBuilder.CreateTable(
                name: "Secretaries",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secretaries", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "BirthRooms",
                columns: table => new
                {
                    RoomNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirthId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirthRooms", x => x.RoomNumber);
                    table.ForeignKey(
                        name: "FK_BirthRooms_Births_BirthId",
                        column: x => x.BirthId,
                        principalTable: "Births",
                        principalColumn: "BirthId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    CprNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirthId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.CprNumber);
                    table.ForeignKey(
                        name: "FK_Children_Births_BirthId",
                        column: x => x.BirthId,
                        principalTable: "Births",
                        principalColumn: "BirthId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Families",
                columns: table => new
                {
                    RelativesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => x.RelativesId);
                    table.ForeignKey(
                        name: "FK_Families_Relatives_RelativesId",
                        column: x => x.RelativesId,
                        principalTable: "Relatives",
                        principalColumn: "RelativesId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fathers",
                columns: table => new
                {
                    RelativesId = table.Column<int>(type: "int", nullable: false),
                    CPRNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fathers", x => x.RelativesId);
                    table.ForeignKey(
                        name: "FK_Fathers_Relatives_RelativesId",
                        column: x => x.RelativesId,
                        principalTable: "Relatives",
                        principalColumn: "RelativesId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mothers",
                columns: table => new
                {
                    RelativesId = table.Column<int>(type: "int", nullable: false),
                    CPRNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mothers", x => x.RelativesId);
                    table.ForeignKey(
                        name: "FK_Mothers_Relatives_RelativesId",
                        column: x => x.RelativesId,
                        principalTable: "Relatives",
                        principalColumn: "RelativesId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RestRooms",
                columns: table => new
                {
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestRooms", x => x.RoomNumber);
                    table.ForeignKey(
                        name: "FK_RestRooms_Relatives_RoomNumber",
                        column: x => x.RoomNumber,
                        principalTable: "Relatives",
                        principalColumn: "RelativesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clinicians",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthRoomId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinicians", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Clinicians_BirthRooms_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "BirthRooms",
                        principalColumn: "RoomNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelativesChild",
                columns: table => new
                {
                    RelativesChildId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelativesId = table.Column<int>(type: "int", nullable: false),
                    CprNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelativesChild", x => x.RelativesChildId);
                    table.ForeignKey(
                        name: "FK_RelativesChild_Children_RelativesId",
                        column: x => x.RelativesId,
                        principalTable: "Children",
                        principalColumn: "CprNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelativesChild_Relatives_RelativesId",
                        column: x => x.RelativesId,
                        principalTable: "Relatives",
                        principalColumn: "RelativesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BirthRooms_BirthId",
                table: "BirthRooms",
                column: "BirthId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Children_BirthId",
                table: "Children",
                column: "BirthId");

            migrationBuilder.CreateIndex(
                name: "IX_RelativesChild_RelativesId",
                table: "RelativesChild",
                column: "RelativesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clinicians");

            migrationBuilder.DropTable(
                name: "Families");

            migrationBuilder.DropTable(
                name: "Fathers");

            migrationBuilder.DropTable(
                name: "Mothers");

            migrationBuilder.DropTable(
                name: "RelativesChild");

            migrationBuilder.DropTable(
                name: "RestRooms");

            migrationBuilder.DropTable(
                name: "Secretaries");

            migrationBuilder.DropTable(
                name: "BirthRooms");

            migrationBuilder.DropTable(
                name: "Children");

            migrationBuilder.DropTable(
                name: "Relatives");

            migrationBuilder.DropTable(
                name: "Births");
        }
    }
}
