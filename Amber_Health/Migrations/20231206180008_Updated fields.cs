using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Amber_Health.Migrations
{
    public partial class Updatedfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "ProfileImage",
                schema: "dbo",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "ProfileImage",
                schema: "dbo",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);
        }
    }
}
