using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NET_TaskBoard_App.Data.Migrations
{
    public partial class AddedDataMore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Boards_BoardId",
                table: "Tasks");

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: "985fa1a0-509d-4390-bef0-6e6ef5439b18");

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: "caf7977c-8347-4d03-806a-b1c70f4d02aa");

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: "ec47191c-101d-4f5f-8845-8f6c1a3b9179");

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[] { "01a2dc0f-b83c-4082-80fd-822981473842", 2, new DateTime(2023, 6, 21, 10, 16, 46, 252, DateTimeKind.Local).AddTicks(2706), "Take your fucking son you go to the fucking clinic in Gabrovo city", "811beaed-fe62-4575-866a-b7df7c873ab0", "Go to Gabrovo" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[] { "210db21d-7f3f-488a-b56f-1aed0bcc1aa9", 2, new DateTime(2023, 6, 21, 10, 16, 46, 252, DateTimeKind.Local).AddTicks(2702), "Just kiding, you don't have to make dinner", "f0e85c1e-32e3-4ce0-bd33-1a4f64351456", "Cook dinner" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[] { "52e0fc39-8cf4-4be8-828a-0b5b3014975e", 1, new DateTime(2023, 6, 21, 10, 16, 46, 252, DateTimeKind.Local).AddTicks(2670), "Make some good skara", "811beaed-fe62-4575-866a-b7df7c873ab0", "Cook lunch" });

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Boards_BoardId",
                table: "Tasks",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Boards_BoardId",
                table: "Tasks");

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: "01a2dc0f-b83c-4082-80fd-822981473842");

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: "210db21d-7f3f-488a-b56f-1aed0bcc1aa9");

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: "52e0fc39-8cf4-4be8-828a-0b5b3014975e");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Boards_BoardId",
                table: "Tasks",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
