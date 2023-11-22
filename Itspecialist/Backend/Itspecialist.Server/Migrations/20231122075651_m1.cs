using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Itspecialist.Server.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accountCompensationEntity");

            migrationBuilder.DropTable(
                name: "accountEntity");

            migrationBuilder.DropTable(
                name: "accountProgrammingFrameworkEntity");

            migrationBuilder.DropTable(
                name: "careerOpportunityEntity");

            migrationBuilder.DropTable(
                name: "districtEntity");

            migrationBuilder.DropTable(
                name: "opportunityProgrammingFrameworkEntity");

            migrationBuilder.DropTable(
                name: "programmingFrameworkEntity");

            migrationBuilder.DropTable(
                name: "programmingLanguageEntity");

            migrationBuilder.DropTable(
                name: "skillsEntity");

            migrationBuilder.DropTable(
                name: "talentCompensationEntity");

            migrationBuilder.DropTable(
                name: "talentProfileEntity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accountCompensationEntity",
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
                    table.PrimaryKey("PK_accountCompensationEntity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "accountEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AccountType = table.Column<int>(type: "INTEGER", nullable: false),
                    DistrictId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    SkillsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accountEntity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "accountProgrammingFrameworkEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AccountId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProgrammingFrameworkId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accountProgrammingFrameworkEntity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "careerOpportunityEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    DistrictId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SkillsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_careerOpportunityEntity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "districtEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_districtEntity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "opportunityProgrammingFrameworkEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CareerOpportunityId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProgrammingFrameworkId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_opportunityProgrammingFrameworkEntity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "programmingFrameworkEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ProgrammingLanguageId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_programmingFrameworkEntity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "programmingLanguageEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_programmingLanguageEntity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "skillsEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PrimaryProgrammingLanguage = table.Column<Guid>(type: "TEXT", nullable: false),
                    SecondaryProgrammingLanguage = table.Column<Guid>(type: "TEXT", nullable: true),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
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
                    AccountId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Wage = table.Column<decimal>(type: "TEXT", nullable: false)
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
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    PreferredEmploymentStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    TalentCompensationId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_talentProfileEntity", x => x.id);
                });
        }
    }
}
