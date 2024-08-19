using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KilimoWebApp.Migrations
{
    /// <inheritdoc />
    public partial class updatestreamtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Streams_Students_StudentEntityStudentId",
                table: "Streams");

            migrationBuilder.DropIndex(
                name: "IX_Streams_StudentEntityStudentId",
                table: "Streams");

            migrationBuilder.DropColumn(
                name: "StudentEntityStudentId",
                table: "Streams");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StudentEntityStudentId",
                table: "Streams",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Streams_StudentEntityStudentId",
                table: "Streams",
                column: "StudentEntityStudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Streams_Students_StudentEntityStudentId",
                table: "Streams",
                column: "StudentEntityStudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
