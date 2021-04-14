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
                    BirthId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.WorksId);
                    table.ForeignKey(
                        name: "FK_Works_Births_BirthId",
                        column: x => x.BirthId,
                        principalTable: "Births",
                        principalColumn: "BirthId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Works_Clinicians_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Clinicians",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
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
                    RoomNumber = table.Column<int>(type: "int", nullable: false)
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
                    RelativesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservations_Relatives_RelativesId",
                        column: x => x.RelativesId,
                        principalTable: "Relatives",
                        principalColumn: "RelativesId",
                        onDelete: ReferentialAction.Restrict);
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
                    { 25, 0, "Daniel Danielsen", "Doctor", "Clinician" },
                    { 48, 0, "Mads Madsen", "Midwife", "Clinician" },
                    { 49, 0, "Marie Toft", "Midwife", "Clinician" },
                    { 50, 0, "Malene Sørensen", "Midwife", "Clinician" },
                    { 51, 0, "Morten Mortensen", "Midwife", "Clinician" },
                    { 52, 0, "Martin Frederiksen", "Midwife", "Clinician" },
                    { 53, 0, "Marcus Nielsen", "Midwife", "Clinician" },
                    { 54, 0, "Maja Mikkelsen", "Midwife", "Clinician" },
                    { 55, 0, "Maria Loft Nielsen", "Midwife", "Clinician" },
                    { 42, 0, "Norbit Albertrise", "Nurse", "Clinician" },
                    { 41, 0, "Neville Longbottom", "Nurse", "Clinician" },
                    { 40, 0, "Naja Madsen", "Nurse", "Clinician" },
                    { 47, 0, "Mille Madsen", "Midwife", "Clinician" },
                    { 39, 0, "Nelly Winston", "Nurse", "Clinician" },
                    { 37, 0, "Nikita Mortensen Bækgaard", "Nurse", "Clinician" },
                    { 36, 0, "Nadai Jensen", "Nurse", "Clinician" },
                    { 35, 0, "Nora Andersen", "Nurse", "Clinician" },
                    { 34, 0, "Nik Petersen", "Nurse", "Clinician" },
                    { 33, 0, "Noah Overbyen", "Nurse", "Clinician" },
                    { 32, 0, "Niller Nielsen", "Nurse", "Clinician" },
                    { 31, 0, "Nicki Sørensen", "Nurse", "Clinician" },
                    { 30, 0, "Natalia Alianovna Romanova", "Nurse", "Clinician" },
                    { 24, 0, "Diana Jensen", "Doctor", "Clinician" },
                    { 29, 0, "Natasha Romanoff", "Nurse", "Clinician" },
                    { 28, 0, "Niklas Landin", "Nurse", "Clinician" },
                    { 38, 0, "Nanna Louise Johansen", "Nurse", "Clinician" },
                    { 27, 0, "Nikolaj Nikolajsen", "Nurse", "Clinician" },
                    { 46, 0, "Malfoy Draco", "Midwife", "Clinician" },
                    { 44, 0, "Nairobi Kenya", "Nurse", "Clinician" },
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
                    { 43, 0, "No Name", "Nurse", "Clinician" },
                    { 12, 0, "Siff Andersen", "Sosu", "Clinician" }
                });

            migrationBuilder.InsertData(
                table: "Clinicians",
                columns: new[] { "EmployeeId", "BirthRoomId", "FullName", "Position", "Title" },
                values: new object[,]
                {
                    { 10, 0, "Sandra Toft", "Sosu", "Clinician" },
                    { 9, 0, "Stine Olsen", "Sosu", "Clinician" },
                    { 8, 0, "Susan Kristensen", "Sosu", "Clinician" },
                    { 7, 0, "Selma Jakobsen", "Sosu", "Clinician" },
                    { 6, 0, "Simon Schou Jensen", "Sosu", "Clinician" },
                    { 5, 0, "Simon Bjermand Kjær", "Sosu", "Clinician" },
                    { 4, 0, "Susanne Himmelblå", "Sosu", "Clinician" },
                    { 3, 0, "Sarah Hansen", "Sosu", "Clinician" },
                    { 2, 0, "Søren Larsen", "Sosu", "Clinician" },
                    { 1, 0, "Sofie Jensen", "Sosu", "Clinician" },
                    { 45, 0, "Norge Nordmand", "Nurse", "Clinician" },
                    { 11, 0, "Silke Rasmusen", "Sosu", "Clinician" },
                    { 26, 0, "Niels Nielsen", "Nurse", "Clinician" }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "RoomNumber", "RoomType" },
                values: new object[,]
                {
                    { 41, "BirthRoom" },
                    { 22, "Restroom" },
                    { 19, "Restroom" },
                    { 18, "Restroom" },
                    { 17, "Restroom" },
                    { 16, "Restroom" },
                    { 15, "Restroom" },
                    { 14, "Restroom" },
                    { 13, "Restroom" },
                    { 12, "Restroom" },
                    { 20, "Restroom" },
                    { 11, "Restroom" },
                    { 9, "Restroom" },
                    { 8, "Restroom" },
                    { 7, "Restroom" },
                    { 6, "Restroom" },
                    { 5, "Restroom" },
                    { 4, "Restroom" },
                    { 3, "Restroom" },
                    { 2, "Restroom" },
                    { 10, "Restroom" },
                    { 21, "Restroom" },
                    { 1, "Restroom" },
                    { 34, "BirthRoom" },
                    { 40, "BirthRoom" },
                    { 39, "BirthRoom" },
                    { 38, "BirthRoom" },
                    { 37, "BirthRoom" },
                    { 36, "BirthRoom" }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "RoomNumber", "RoomType" },
                values: new object[,]
                {
                    { 35, "BirthRoom" },
                    { 23, "Restroom" },
                    { 33, "BirthRoom" },
                    { 32, "BirthRoom" },
                    { 31, "BirthRoom" },
                    { 30, "BirthRoom" },
                    { 29, "BirthRoom" },
                    { 28, "BirthRoom" },
                    { 27, "Restroom" },
                    { 26, "Restroom" },
                    { 25, "Restroom" },
                    { 24, "Restroom" },
                    { 42, "BirthRoom" }
                });

            migrationBuilder.InsertData(
                table: "Secretaries",
                columns: new[] { "EmployeeId", "FullName", "Title" },
                values: new object[,]
                {
                    { 57, "Signe Mikkelsen", "Secretary" },
                    { 59, "Søren Krag", "Secretary" },
                    { 56, "Simba Kongesøn", "Secretary" },
                    { 58, "Sune Orlater", "Secretary" }
                });

            migrationBuilder.InsertData(
                table: "BirthRooms",
                column: "RoomNumber",
                values: new object[]
                {
                    39,
                    33,
                    31,
                    30,
                    29,
                    34,
                    28,
                    35,
                    42,
                    32,
                    41,
                    37,
                    40,
                    38,
                    36
                });

            migrationBuilder.InsertData(
                table: "Midwifes",
                column: "EmployeeId",
                values: new object[]
                {
                    52,
                    47,
                    51,
                    54,
                    55,
                    50,
                    49,
                    48,
                    53,
                    46
                });

            migrationBuilder.InsertData(
                table: "Nurses",
                column: "EmployeeId",
                values: new object[]
                {
                    28,
                    40,
                    39,
                    43,
                    38,
                    26,
                    34,
                    27,
                    37,
                    41,
                    42,
                    29,
                    30,
                    45,
                    31,
                    36,
                    32
                });

            migrationBuilder.InsertData(
                table: "Nurses",
                column: "EmployeeId",
                values: new object[]
                {
                    35,
                    33,
                    44
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "RelativesId", "ReservationEndDate", "ReservationStartDate", "RoomId" },
                values: new object[,]
                {
                    { 37, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 37 },
                    { 36, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 36 },
                    { 32, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 32 },
                    { 28, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 28 },
                    { 34, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 34 },
                    { 29, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 29 },
                    { 33, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 33 },
                    { 39, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 39 },
                    { 35, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 35 },
                    { 31, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 31 },
                    { 22, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 22 },
                    { 26, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 26 },
                    { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 7, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 8, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 9, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 10, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 11, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 12, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 13, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 27, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 27 },
                    { 14, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 16, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 16 },
                    { 17, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 17 },
                    { 18, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 18 },
                    { 19, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 19 },
                    { 20, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20 },
                    { 21, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 21 },
                    { 42, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 42 },
                    { 38, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 38 },
                    { 23, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 23 },
                    { 41, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 41 },
                    { 24, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24 },
                    { 25, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "RelativesId", "ReservationEndDate", "ReservationStartDate", "RoomId" },
                values: new object[,]
                {
                    { 40, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 40 },
                    { 15, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 30, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30 }
                });

            migrationBuilder.InsertData(
                table: "RestRooms",
                columns: new[] { "RoomNumber", "Type" },
                values: new object[,]
                {
                    { 1, "MaternityRoom" },
                    { 27, "RestRoom4Hours" },
                    { 3, "MaternityRoom" },
                    { 4, "MaternityRoom" },
                    { 5, "MaternityRoom" },
                    { 6, "MaternityRoom" },
                    { 7, "MaternityRoom" },
                    { 8, "MaternityRoom" },
                    { 9, "MaternityRoom" },
                    { 10, "MaternityRoom" },
                    { 11, "MaternityRoom" },
                    { 12, "MaternityRoom" },
                    { 13, "MaternityRoom" },
                    { 14, "MaternityRoom" },
                    { 2, "MaternityRoom" },
                    { 16, "MaternityRoom" },
                    { 17, "MaternityRoom" },
                    { 18, "MaternityRoom" },
                    { 19, "MaternityRoom" },
                    { 20, "MaternityRoom" },
                    { 21, "MaternityRoom" },
                    { 22, "MaternityRoom" },
                    { 23, "RestRoom4Hours" },
                    { 24, "RestRoom4Hours" },
                    { 25, "RestRoom4Hours" },
                    { 26, "RestRoom4Hours" },
                    { 15, "MaternityRoom" }
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
                    23,
                    20,
                    21,
                    22,
                    14,
                    19,
                    13,
                    7
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
                    6,
                    5,
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
                    25,
                    24,
                    23,
                    22,
                    21,
                    20,
                    19,
                    18,
                    17,
                    16,
                    15,
                    26,
                    14,
                    12,
                    11,
                    10,
                    9,
                    8,
                    7,
                    6,
                    5,
                    4,
                    3,
                    2,
                    13,
                    27
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
