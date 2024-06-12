using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPB101.Migrations
{
    public partial class createdBooktable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { 1, "yazici1", new DateTime(2024, 6, 12, 21, 58, 2, 825, DateTimeKind.Local).AddTicks(9844), "Kitab1" },
                    { 2, "yazici2", new DateTime(2024, 6, 12, 21, 58, 2, 825, DateTimeKind.Local).AddTicks(9847), "Kitab2" },
                    { 3, "yazici3", new DateTime(2024, 6, 12, 21, 58, 2, 825, DateTimeKind.Local).AddTicks(9848), "Kitab3" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 12, 21, 58, 2, 825, DateTimeKind.Local).AddTicks(9650));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 12, 21, 58, 2, 825, DateTimeKind.Local).AddTicks(9691));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 12, 21, 58, 2, 825, DateTimeKind.Local).AddTicks(9693));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 12, 18, 36, 56, 572, DateTimeKind.Local).AddTicks(9823));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 12, 18, 36, 56, 572, DateTimeKind.Local).AddTicks(9825));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 12, 18, 36, 56, 572, DateTimeKind.Local).AddTicks(9826));
        }
    }
}
