using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwitterAPI.Data.Migrations
{
    public partial class migration02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TweetAggregatedStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AggregationGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberOfTweets = table.Column<int>(type: "int", nullable: false),
                    UpToDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TweetAggregatedStatistics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TweetHashtagsAggregatedStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hashtag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HashtagCount = table.Column<int>(type: "int", nullable: false),
                    TweetAggregatedStatisticId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TweetHashtagsAggregatedStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TweetHashtagsAggregatedStatistics_TweetAggregatedStatistics_TweetAggregatedStatisticId",
                        column: x => x.TweetAggregatedStatisticId,
                        principalTable: "TweetAggregatedStatistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Tweets",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTimeOffset(new DateTime(2022, 10, 2, 16, 47, 44, 330, DateTimeKind.Unspecified).AddTicks(7168), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Tweets",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTimeOffset(new DateTime(2022, 10, 2, 16, 47, 44, 330, DateTimeKind.Unspecified).AddTicks(7170), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Tweets",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTimeOffset(new DateTime(2022, 10, 2, 16, 47, 44, 330, DateTimeKind.Unspecified).AddTicks(7170), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_TweetHashtagsAggregatedStatistics_TweetAggregatedStatisticId",
                table: "TweetHashtagsAggregatedStatistics",
                column: "TweetAggregatedStatisticId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TweetHashtagsAggregatedStatistics");

            migrationBuilder.DropTable(
                name: "TweetAggregatedStatistics");

            migrationBuilder.UpdateData(
                table: "Tweets",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTimeOffset(new DateTime(2022, 9, 28, 14, 28, 30, 271, DateTimeKind.Unspecified).AddTicks(492), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Tweets",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTimeOffset(new DateTime(2022, 9, 28, 14, 28, 30, 271, DateTimeKind.Unspecified).AddTicks(494), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Tweets",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTimeOffset(new DateTime(2022, 9, 28, 14, 28, 30, 271, DateTimeKind.Unspecified).AddTicks(495), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
