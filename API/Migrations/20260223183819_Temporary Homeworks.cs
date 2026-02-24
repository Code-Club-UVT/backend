using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class TemporaryHomeworks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "HomeworkId",
                table: "TempFiles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "TempHomeworks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Number = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "character varying(4096)", maxLength: 4096, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempHomeworks", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TempFiles_HomeworkId",
                table: "TempFiles",
                column: "HomeworkId");

            migrationBuilder.AddForeignKey(
                name: "FK_TempFiles_TempHomeworks_HomeworkId",
                table: "TempFiles",
                column: "HomeworkId",
                principalTable: "TempHomeworks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TempFiles_TempHomeworks_HomeworkId",
                table: "TempFiles");

            migrationBuilder.DropTable(
                name: "TempHomeworks");

            migrationBuilder.DropIndex(
                name: "IX_TempFiles_HomeworkId",
                table: "TempFiles");

            migrationBuilder.DropColumn(
                name: "HomeworkId",
                table: "TempFiles");
        }
    }
}
