using Microsoft.EntityFrameworkCore.Migrations;

namespace GastonCardenas.Test.Infrastructure.Migrations
{
    public partial class BlogDraftStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PostStatus",
                columns: new[] { "PostStatusId", "Name" },
                values: new object[] { 0, "Draft" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PostStatus",
                keyColumn: "PostStatusId",
                keyValue: 0);
        }
    }
}
