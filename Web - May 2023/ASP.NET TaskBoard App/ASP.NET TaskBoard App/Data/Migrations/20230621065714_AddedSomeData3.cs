using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NET_TaskBoard_App.Data.Migrations
{
    public partial class AddedSomeData3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Boards",
                column: "Id",
                value: 1);

            migrationBuilder.InsertData(
                table: "Boards",
                column: "Id",
                value: 2);

            migrationBuilder.InsertData(
                table: "Boards",
                column: "Id",
                value: 3);

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[] { "985fa1a0-509d-4390-bef0-6e6ef5439b18", 2, new DateTime(2023, 6, 21, 9, 57, 14, 740, DateTimeKind.Local).AddTicks(7600), "Take your fucking son you go to the fucking clinic in Gabrovo city", "811beaed-fe62-4575-866a-b7df7c873ab0", "Go to Gabrovo" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[] { "caf7977c-8347-4d03-806a-b1c70f4d02aa", 1, new DateTime(2023, 6, 21, 9, 57, 14, 740, DateTimeKind.Local).AddTicks(7562), "Make some good skara", "811beaed-fe62-4575-866a-b7df7c873ab0", "Cook lunch" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[] { "ec47191c-101d-4f5f-8845-8f6c1a3b9179", 2, new DateTime(2023, 6, 21, 9, 57, 14, 740, DateTimeKind.Local).AddTicks(7596), "Just kiding, you don't have to make dinner", "f0e85c1e-32e3-4ce0-bd33-1a4f64351456", "Cook dinner" });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");
        }
    }
}
