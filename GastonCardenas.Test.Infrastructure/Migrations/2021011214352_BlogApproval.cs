using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace GastonCardenas.Test.Infrastructure.Migrations
{
    public partial class BlogApproval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovalDate",
                table: "Post",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApproverName",
                table: "Post",
                maxLength: 100,
                nullable: true);

            migrationBuilder.InsertData(
                table: "PostStatus",
                columns: new[] { "PostStatusId", "Name" },
                values: new object[] { 1, "Pending Publish Approval" });

            migrationBuilder.InsertData(
                table: "PostStatus",
                columns: new[] { "PostStatusId", "Name" },
                values: new object[] { 2, "Published" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PostStatus",
                keyColumn: "PostStatusId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PostStatus",
                keyColumn: "PostStatusId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "ApprovalDate",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "ApproverName",
                table: "Post");
        }
    }
}
