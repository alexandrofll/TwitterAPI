using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwitterAPI.Data.Migrations
{
    public partial class migration01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tweets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Hashtag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tweets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tweets",
                columns: new[] { "Id", "Date", "Hashtag", "Title" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 9, 28, 14, 28, 30, 271, DateTimeKind.Unspecified).AddTicks(492), new TimeSpan(0, 0, 0, 0, 0)), "#hello", "Tweet 1" });

            migrationBuilder.InsertData(
                table: "Tweets",
                columns: new[] { "Id", "Date", "Hashtag", "Title" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 9, 28, 14, 28, 30, 271, DateTimeKind.Unspecified).AddTicks(494), new TimeSpan(0, 0, 0, 0, 0)), "#world", "Tweet 2" });

            migrationBuilder.InsertData(
                table: "Tweets",
                columns: new[] { "Id", "Date", "Hashtag", "Title" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 9, 28, 14, 28, 30, 271, DateTimeKind.Unspecified).AddTicks(495), new TimeSpan(0, 0, 0, 0, 0)), "#news", "Tweet 3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tweets");
        }
    }
}
