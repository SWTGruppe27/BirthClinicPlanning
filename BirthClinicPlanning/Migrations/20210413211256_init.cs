using System;
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlannedStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlannedEndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Births", x => x.BirthId);
                });

            migrationBuilder.CreateTable(
                name: "Clinicians",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthRoomId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinicians", x => x.EmployeeId);
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
                name: "Room",
                columns: table => new
                {
                    RoomNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomNumber);
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
                name: "Children",
                columns: table => new
                {
                    ChildId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CprNumber = table.Column<int>(type: "int", nullable: false),
                    BirthId = table.Column<int>(type: "int", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.ChildId);
                    table.ForeignKey(
                        name: "FK_Children_Births_BirthId",
                        column: x => x.BirthId,
                        principalTable: "Births",
                        principalColumn: "BirthId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    WorksId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirthId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.WorksId);
                    table.ForeignKey(
                        name: "FK_Works_Births_BirthId",
                        column: x => x.BirthId,
                        principalTable: "Births",
                        principalColumn: "BirthId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Works_Clinicians_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Clinicians",
                        principalColumn: "EmployeeId",
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
                name: "BirthRooms",
                columns: table => new
                {
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    BirthId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirthRooms", x => x.RoomNumber);
                    table.ForeignKey(
                        name: "FK_BirthRooms_Room_RoomNumber",
                        column: x => x.RoomNumber,
                        principalTable: "Room",
                        principalColumn: "RoomNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    ReservationStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReservationEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RelativesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservations_Relatives_RelativesId",
                        column: x => x.RelativesId,
                        principalTable: "Relatives",
                        principalColumn: "RelativesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "RoomNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestRooms",
                columns: table => new
                {
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestRooms", x => x.RoomNumber);
                    table.ForeignKey(
                        name: "FK_RestRooms_Room_RoomNumber",
                        column: x => x.RoomNumber,
                        principalTable: "Room",
                        principalColumn: "RoomNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RelativesChild",
                columns: table => new
                {
                    RelativesChildId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelativesId = table.Column<int>(type: "int", nullable: false),
                    ChildId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelativesChild", x => x.RelativesChildId);
                    table.ForeignKey(
                        name: "FK_RelativesChild_Children_RelativesId",
                        column: x => x.RelativesId,
                        principalTable: "Children",
                        principalColumn: "ChildId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelativesChild_Relatives_RelativesId",
                        column: x => x.RelativesId,
                        principalTable: "Relatives",
                        principalColumn: "RelativesId",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "Clinicians",
                columns: new[] { "EmployeeId", "BirthRoomId", "FullName", "Position", "Title" },
                values: new object[,]
                {
                    { 54, 0, "Maja Mikkelsen", "Midwife", "Clinician" },
                    { 43, 0, "No Name", "Nurse", "Clinician" },
                    { 42, 0, "Norbit Albertrise", "Nurse", "Clinician" },
                    { 41, 0, "Neville Longbottom", "Nurse", "Clinician" },
                    { 40, 0, "Naja Madsen", "Nurse", "Clinician" },
                    { 39, 0, "Nelly Winston", "Nurse", "Clinician" },
                    { 38, 0, "Nanna Louise Johansen", "Nurse", "Clinician" },
                    { 37, 0, "Nikita Mortensen Bækgaard", "Nurse", "Clinician" },
                    { 36, 0, "Nadai Jensen", "Nurse", "Clinician" },
                    { 35, 0, "Nora Andersen", "Nurse", "Clinician" },
                    { 44, 0, "Nairobi Kenya", "Nurse", "Clinician" },
                    { 34, 0, "Nik Petersen", "Nurse", "Clinician" },
                    { 32, 0, "Niller Nielsen", "Nurse", "Clinician" },
                    { 31, 0, "Nicki Sørensen", "Nurse", "Clinician" },
                    { 30, 0, "Natalia Alianovna Romanova", "Nurse", "Clinician" },
                    { 29, 0, "Natasha Romanoff", "Nurse", "Clinician" },
                    { 28, 0, "Niklas Landin", "Nurse", "Clinician" },
                    { 27, 0, "Nikolaj Nikolajsen", "Nurse", "Clinician" },
                    { 26, 0, "Niels Nielsen", "Nurse", "Clinician" },
                    { 55, 0, "Maria Loft Nielsen", "Midwife", "Clinician" },
                    { 24, 0, "Diana Jensen", "Doctor", "Clinician" },
                    { 33, 0, "Noah Overbyen", "Nurse", "Clinician" },
                    { 45, 0, "Norge Nordmand", "Nurse", "Clinician" },
                    { 1, 0, "Sofie Jensen", "Sosu", "Clinician" },
                    { 2, 0, "Søren Larsen", "Sosu", "Clinician" },
                    { 23, 0, "David Davidson", "Doctor", "Clinician" },
                    { 22, 0, "Dirk Passer", "Doctor", "Clinician" },
                    { 21, 0, "Danny Boy", "Doctor", "Clinician" },
                    { 20, 0, "Sten Steensen", "Sosu", "Clinician" },
                    { 19, 0, "Sidsel Lund Sørensen", "Sosu", "Clinician" },
                    { 18, 0, "Sascha Madsen", "Sosu", "Clinician" },
                    { 17, 0, "Sara Christensen", "Sosu", "Clinician" },
                    { 16, 0, "Sabrina Møller Andersen", "Sosu", "Clinician" },
                    { 15, 0, "Simone Kjær", "Sosu", "Clinician" },
                    { 14, 0, "Sol-Solvej Solskin", "Sosu", "Clinician" },
                    { 13, 0, "Sophie Loft", "Sosu", "Clinician" },
                    { 12, 0, "Siff Andersen", "Sosu", "Clinician" },
                    { 11, 0, "Silke Rasmusen", "Sosu", "Clinician" },
                    { 10, 0, "Sandra Toft", "Sosu", "Clinician" },
                    { 9, 0, "Stine Olsen", "Sosu", "Clinician" },
                    { 8, 0, "Susan Kristensen", "Sosu", "Clinician" },
                    { 7, 0, "Selma Jakobsen", "Sosu", "Clinician" }
                });

            migrationBuilder.InsertData(
                table: "Clinicians",
                columns: new[] { "EmployeeId", "BirthRoomId", "FullName", "Position", "Title" },
                values: new object[,]
                {
                    { 6, 0, "Simon Schou Jensen", "Sosu", "Clinician" },
                    { 5, 0, "Simon Bjermand Kjær", "Sosu", "Clinician" },
                    { 4, 0, "Susanne Himmelblå", "Sosu", "Clinician" },
                    { 3, 0, "Sarah Hansen", "Sosu", "Clinician" },
                    { 53, 0, "Marcus Nielsen", "Midwife", "Clinician" },
                    { 52, 0, "Martin Frederiksen", "Midwife", "Clinician" },
                    { 25, 0, "Daniel Danielsen", "Doctor", "Clinician" },
                    { 50, 0, "Malene Sørensen", "Midwife", "Clinician" },
                    { 49, 0, "Marie Toft", "Midwife", "Clinician" },
                    { 48, 0, "Mads Madsen", "Midwife", "Clinician" },
                    { 51, 0, "Morten Mortensen", "Midwife", "Clinician" },
                    { 47, 0, "Mille Madsen", "Midwife", "Clinician" },
                    { 46, 0, "Malfoy Draco", "Midwife", "Clinician" }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "RoomNumber", "RoomType" },
                values: new object[,]
                {
                    { 21, "Restroom" },
                    { 20, "Restroom" },
                    { 19, "Restroom" },
                    { 18, "Restroom" },
                    { 17, "Restroom" },
                    { 16, "Restroom" },
                    { 15, "Restroom" },
                    { 14, "Restroom" },
                    { 13, "Restroom" },
                    { 10, "Restroom" },
                    { 11, "Restroom" },
                    { 22, "Restroom" },
                    { 9, "Restroom" },
                    { 8, "Restroom" },
                    { 7, "Restroom" },
                    { 6, "Restroom" },
                    { 5, "Restroom" },
                    { 4, "Restroom" },
                    { 3, "Restroom" },
                    { 2, "Restroom" },
                    { 12, "Restroom" },
                    { 23, "Restroom" },
                    { 26, "Restroom" },
                    { 25, "Restroom" },
                    { 42, "BirthRoom" },
                    { 41, "BirthRoom" },
                    { 40, "BirthRoom" },
                    { 39, "BirthRoom" },
                    { 38, "BirthRoom" }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "RoomNumber", "RoomType" },
                values: new object[,]
                {
                    { 24, "Restroom" },
                    { 36, "BirthRoom" },
                    { 35, "BirthRoom" },
                    { 37, "BirthRoom" },
                    { 33, "BirthRoom" },
                    { 32, "BirthRoom" },
                    { 31, "BirthRoom" },
                    { 30, "BirthRoom" },
                    { 29, "BirthRoom" },
                    { 28, "BirthRoom" },
                    { 27, "Restroom" },
                    { 34, "BirthRoom" },
                    { 1, "Restroom" }
                });

            migrationBuilder.InsertData(
                table: "Secretaries",
                columns: new[] { "EmployeeId", "FullName", "Title" },
                values: new object[,]
                {
                    { 59, "Søren Krag", "Secretary" },
                    { 58, "Sune Orlater", "Secretary" },
                    { 57, "Signe Mikkelsen", "Secretary" },
                    { 56, "Simba Kongesøn", "Secretary" }
                });

            migrationBuilder.InsertData(
                table: "Midwifes",
                column: "EmployeeId",
                values: new object[]
                {
                    52,
                    46,
                    47,
                    48,
                    49,
                    50,
                    51,
                    53,
                    54,
                    55
                });

            migrationBuilder.InsertData(
                table: "Nurses",
                column: "EmployeeId",
                values: new object[]
                {
                    26,
                    27,
                    28,
                    30,
                    31,
                    29,
                    33,
                    45,
                    44,
                    43,
                    42,
                    32,
                    40,
                    41,
                    38,
                    37,
                    36,
                    35,
                    34,
                    39
                });

            migrationBuilder.InsertData(
                table: "RestRooms",
                columns: new[] { "RoomNumber", "Type" },
                values: new object[,]
                {
                    { 38, null },
                    { 42, null },
                    { 41, null },
                    { 40, null },
                    { 39, null },
                    { 37, null },
                    { 1, "MaternityRoom" },
                    { 35, null },
                    { 16, "MaternityRoom" },
                    { 15, "MaternityRoom" },
                    { 14, "MaternityRoom" },
                    { 13, "MaternityRoom" }
                });

            migrationBuilder.InsertData(
                table: "RestRooms",
                columns: new[] { "RoomNumber", "Type" },
                values: new object[,]
                {
                    { 12, "MaternityRoom" },
                    { 11, "MaternityRoom" },
                    { 10, "MaternityRoom" },
                    { 9, "MaternityRoom" },
                    { 8, "MaternityRoom" },
                    { 36, null },
                    { 6, "MaternityRoom" },
                    { 5, "MaternityRoom" },
                    { 4, "MaternityRoom" },
                    { 3, "MaternityRoom" },
                    { 2, "MaternityRoom" },
                    { 17, "MaternityRoom" },
                    { 18, "MaternityRoom" },
                    { 7, "MaternityRoom" },
                    { 20, "MaternityRoom" },
                    { 19, "MaternityRoom" },
                    { 34, null },
                    { 33, null },
                    { 31, null },
                    { 30, null },
                    { 29, null },
                    { 28, null },
                    { 32, null },
                    { 26, "RestRoom4Hours" },
                    { 25, "RestRoom4Hours" },
                    { 24, "RestRoom4Hours" },
                    { 23, "RestRoom4Hours" },
                    { 22, "MaternityRoom" },
                    { 27, "RestRoom4Hours" },
                    { 21, "MaternityRoom" }
                });

            migrationBuilder.InsertData(
                table: "Sosu",
                column: "EmployeeId",
                values: new object[]
                {
                    15,
                    16,
                    17,
                    18,
                    21,
                    20,
                    22,
                    14,
                    23,
                    19,
                    13,
                    5
                });

            migrationBuilder.InsertData(
                table: "Sosu",
                column: "EmployeeId",
                values: new object[]
                {
                    11,
                    10,
                    9,
                    8,
                    7,
                    6,
                    4,
                    3,
                    2,
                    1,
                    24,
                    12,
                    25
                });

            migrationBuilder.InsertData(
                table: "MaternityRooms",
                column: "RoomNumber",
                values: new object[]
                {
                    1,
                    24,
                    25,
                    26,
                    27,
                    28,
                    29,
                    30,
                    31,
                    32,
                    33,
                    34,
                    35,
                    36,
                    37,
                    38,
                    39,
                    40,
                    23,
                    22,
                    21,
                    20,
                    2,
                    3,
                    4,
                    5,
                    6,
                    7,
                    8,
                    9,
                    41,
                    10,
                    12,
                    13,
                    14,
                    15,
                    16,
                    17,
                    18,
                    19,
                    11,
                    42
                });

            migrationBuilder.CreateIndex(
                name: "IX_Children_BirthId",
                table: "Children",
                column: "BirthId");

            migrationBuilder.CreateIndex(
                name: "IX_RelativesChild_RelativesId",
                table: "RelativesChild",
                column: "RelativesId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RelativesId",
                table: "Reservations",
                column: "RelativesId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomId",
                table: "Reservations",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_BirthId",
                table: "Works",
                column: "BirthId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_EmployeeId",
                table: "Works",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BirthRooms");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Families");

            migrationBuilder.DropTable(
                name: "Fathers");

            migrationBuilder.DropTable(
                name: "MaternityRooms");

            migrationBuilder.DropTable(
                name: "Midwifes");

            migrationBuilder.DropTable(
                name: "Mothers");

            migrationBuilder.DropTable(
                name: "Nurses");

            migrationBuilder.DropTable(
                name: "RelativesChild");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "RestRoom4Hours");

            migrationBuilder.DropTable(
                name: "Secretaries");

            migrationBuilder.DropTable(
                name: "Sosu");

            migrationBuilder.DropTable(
                name: "Works");

            migrationBuilder.DropTable(
                name: "Children");

            migrationBuilder.DropTable(
                name: "Relatives");

            migrationBuilder.DropTable(
                name: "RestRooms");

            migrationBuilder.DropTable(
                name: "Clinicians");

            migrationBuilder.DropTable(
                name: "Births");

            migrationBuilder.DropTable(
                name: "Room");
        }
    }
}
