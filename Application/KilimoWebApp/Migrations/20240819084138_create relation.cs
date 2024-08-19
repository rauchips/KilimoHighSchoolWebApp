using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KilimoWebApp.Migrations
{
    /// <inheritdoc />
    public partial class createrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Streams_Students_StudentId",
                table: "Streams");

            migrationBuilder.DropIndex(
                name: "IX_Streams_StudentId",
                table: "Streams");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Streams",
                newName: "StudentEntityStudentId");

            migrationBuilder.AddColumn<Guid>(
                name: "StreamId",
                table: "Students",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Streams_Students_StudentEntityStudentId",
                table: "Streams");

            migrationBuilder.DropIndex(
                name: "IX_Streams_StudentEntityStudentId",
                table: "Streams");

            migrationBuilder.DropColumn(
                name: "StreamId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "StudentEntityStudentId",
                table: "Streams",
                newName: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Streams_StudentId",
                table: "Streams",
                column: "StudentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Streams_Students_StudentId",
                table: "Streams",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
