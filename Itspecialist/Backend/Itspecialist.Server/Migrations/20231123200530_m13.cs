using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Itspecialist.Server.Migrations
{
    /// <inheritdoc />
    public partial class m13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SkillsId",
                table: "talentProfileEntity",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SkillsId",
                table: "talentProfileEntity");
        }
    }
}
