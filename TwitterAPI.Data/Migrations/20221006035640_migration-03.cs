using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwitterAPI.Data.Migrations
{
    public partial class migration03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hashtag",
                table: "Tweets");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Tweets");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Tweets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Hashtag",
                table: "TweetHashtagsAggregatedStatistics",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "TweetHashtags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hashtag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TweetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TweetHashtags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TweetHashtags_Tweets_TweetId",
                        column: x => x.TweetId,
                        principalTable: "Tweets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Tweets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Text" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 6, 3, 56, 40, 423, DateTimeKind.Unspecified).AddTicks(2360), new TimeSpan(0, 0, 0, 0, 0)), "Tweet 1" });

            migrationBuilder.UpdateData(
                table: "Tweets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Text" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 6, 3, 56, 40, 423, DateTimeKind.Unspecified).AddTicks(2363), new TimeSpan(0, 0, 0, 0, 0)), "Tweet 2" });

            migrationBuilder.UpdateData(
                table: "Tweets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "Text" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 6, 3, 56, 40, 423, DateTimeKind.Unspecified).AddTicks(2364), new TimeSpan(0, 0, 0, 0, 0)), "Tweet 3" });

            migrationBuilder.CreateIndex(
                name: "IX_TweetHashtags_TweetId",
                table: "TweetHashtags",
                column: "TweetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TweetHashtags");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Tweets");

            migrationBuilder.AddColumn<string>(
                name: "Hashtag",
                table: "Tweets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Tweets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Hashtag",
                table: "TweetHashtagsAggregatedStatistics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Tweets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Hashtag", "Title" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 2, 16, 47, 44, 330, DateTimeKind.Unspecified).AddTicks(7168), new TimeSpan(0, 0, 0, 0, 0)), "#hello", "Tweet 1" });

            migrationBuilder.UpdateData(
                table: "Tweets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Hashtag", "Title" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 2, 16, 47, 44, 330, DateTimeKind.Unspecified).AddTicks(7170), new TimeSpan(0, 0, 0, 0, 0)), "#world", "Tweet 2" });

            migrationBuilder.UpdateData(
                table: "Tweets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "Hashtag", "Title" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 10, 2, 16, 47, 44, 330, DateTimeKind.Unspecified).AddTicks(7170), new TimeSpan(0, 0, 0, 0, 0)), "#news", "Tweet 3" });
        }
    }
}
