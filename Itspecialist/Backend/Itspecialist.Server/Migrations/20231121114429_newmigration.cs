using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Itspecialist.Server.Migrations
{
    /// <inheritdoc />
    public partial class newmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "specialistCompensationEntity");

            migrationBuilder.DropTable(
                name: "specialistProfileEntity");

            migrationBuilder.DropColumn(
                name: "SecondaryProgrammingLanguage",
                table: "accountEntity");

            migrationBuilder.RenameColumn(
                name: "PrimaryProgrammingLanguage",
                table: "accountEntity",
                newName: "SkillsId");

            migrationBuilder.RenameColumn(
                name: "PreferredEmploymentStatus",
                table: "accountEntity",
                newName: "AccountType");

            migrationBuilder.AddColumn<Guid>(
                name: "DistrictId",
                table: "accountEntity",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "careerOpportunityEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DistrictId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SkillsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_careerOpportunityEntity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "skillsEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PrimaryProgrammingLanguage = table.Column<Guid>(type: "TEXT", nullable: false),
                    SecondaryProgrammingLanguage = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skillsEntity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "talentCompensationEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AccountId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Wage = table.Column<decimal>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_talentCompensationEntity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "talentProfileEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    AccountId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TalentCompensationId = table.Column<Guid>(type: "TEXT", nullable: true),
                    PreferredEmploymentStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_talentProfileEntity", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "careerOpportunityEntity");

            migrationBuilder.DropTable(
                name: "skillsEntity");

            migrationBuilder.DropTable(
                name: "talentCompensationEntity");

            migrationBuilder.DropTable(
                name: "talentProfileEntity");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "accountEntity");

            migrationBuilder.RenameColumn(
                name: "SkillsId",
                table: "accountEntity",
                newName: "PrimaryProgrammingLanguage");

            migrationBuilder.RenameColumn(
                name: "AccountType",
                table: "accountEntity",
                newName: "PreferredEmploymentStatus");

            migrationBuilder.AddColumn<Guid>(
                name: "SecondaryProgrammingLanguage",
                table: "accountEntity",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "specialistCompensationEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AccountId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Wage = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specialistCompensationEntity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "specialistProfileEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AccountId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    SpecialistCompensationId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specialistProfileEntity", x => x.id);
                });
        }
    }
}
