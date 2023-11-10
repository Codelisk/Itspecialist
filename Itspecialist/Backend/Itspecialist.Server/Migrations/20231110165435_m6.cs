using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Itspecialist.Server.Migrations
{
    /// <inheritdoc />
    public partial class m6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "testEntity");

            migrationBuilder.CreateTable(
                name: "accountCompensationEntity",
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
                    table.PrimaryKey("PK_accountCompensationEntity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "accountEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PrimaryProgrammingLanguage = table.Column<Guid>(type: "TEXT", nullable: false),
                    SecondaryProgrammingLanguage = table.Column<Guid>(type: "TEXT", nullable: true),
                    PreferredEmploymentStatus = table.Column<int>(type: "INTEGER", nullable: false)
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
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AccountId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProgrammingFrameworkId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accountProgrammingFrameworkEntity", x => x.id);
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
                name: "specialistCompensationEntity",
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
                    table.PrimaryKey("PK_specialistCompensationEntity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "specialistProfileEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    AccountId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SpecialistCompensationId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specialistProfileEntity", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accountCompensationEntity");

            migrationBuilder.DropTable(
                name: "accountEntity");

            migrationBuilder.DropTable(
                name: "accountProgrammingFrameworkEntity");

            migrationBuilder.DropTable(
                name: "programmingFrameworkEntity");

            migrationBuilder.DropTable(
                name: "programmingLanguageEntity");

            migrationBuilder.DropTable(
                name: "specialistCompensationEntity");

            migrationBuilder.DropTable(
                name: "specialistProfileEntity");

            migrationBuilder.CreateTable(
                name: "testEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_testEntity", x => x.id);
                });
        }
    }
}
