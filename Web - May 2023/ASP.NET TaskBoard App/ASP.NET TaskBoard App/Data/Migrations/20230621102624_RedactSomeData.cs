using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NET_TaskBoard_App.Data.Migrations
{
    public partial class RedactSomeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Boards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Finished");

            migrationBuilder.UpdateData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "In Progress");

            migrationBuilder.UpdateData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Mama is cooking it");

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { "5e4d191f-a902-4bad-81d4-2429a23b60ac", 2, new DateTime(2023, 6, 21, 13, 26, 23, 930, DateTimeKind.Local).AddTicks(5075), "Take your fucking son you go to the fucking clinic in Gabrovo city", "95f02134-b722-4e6c-8b86-feea5f5bf300", "Go to Gabrovo" },
                    { "62c21046-5f6f-4fa2-9133-6a0ee0297e7d", 2, new DateTime(2023, 6, 21, 13, 26, 23, 930, DateTimeKind.Local).AddTicks(5071), "Just kiding, you don't have to make dinner", "95f02134-b722-4e6c-8b86-feea5f5bf300", "Cook dinner" },
                    { "8120f10f-e32b-45fe-ae0e-3f4ad09a41cb", 1, new DateTime(2023, 6, 21, 13, 26, 23, 930, DateTimeKind.Local).AddTicks(5026), "Make some good skara", "95f02134-b722-4e6c-8b86-feea5f5bf300", "Cook lunch" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: "5e4d191f-a902-4bad-81d4-2429a23b60ac");

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: "62c21046-5f6f-4fa2-9133-6a0ee0297e7d");

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: "8120f10f-e32b-45fe-ae0e-3f4ad09a41cb");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Boards");

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
        }
    }
}
