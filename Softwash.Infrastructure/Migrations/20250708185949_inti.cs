using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class inti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Auth");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Lookups",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "NVARCHAR(250)", maxLength: 250, nullable: true),
                    Text = table.Column<string>(type: "NVARCHAR(500)", maxLength: 500, nullable: true),
                    Value = table.Column<string>(type: "NVARCHAR(400)", maxLength: 400, nullable: true),
                    Order = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lookups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "NVARCHAR(250)", maxLength: 250, nullable: true),
                    ShopifyUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastName = table.Column<string>(type: "NVARCHAR(250)", maxLength: 250, nullable: true),
                    Email = table.Column<string>(type: "NVARCHAR(250)", maxLength: 250, nullable: true),
                    Image = table.Column<string>(type: "NVARCHAR(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "SMALLDATETIME", nullable: true),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "SMALLDATETIME", nullable: true),
                    ModifiedById = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OTP = table.Column<string>(type: "NVARCHAR(10)", maxLength: 10, nullable: true),
                    OTPExpiry = table.Column<DateTime>(type: "DATETIME", nullable: true, defaultValueSql: "DATEADD(MINUTE, 1, GETUTCDATE())"),
                    IsVerified = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    IsProfileCompleted = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    IsPasswordSetted = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    EndDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    IsDeleted = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    CreatedDate = table.Column<DateTime>(type: "SMALLDATETIME", nullable: true),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "SMALLDATETIME", nullable: true),
                    ModifiedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_Users_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectTask",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    IsCompleted = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    DueDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "SMALLDATETIME", nullable: true),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "SMALLDATETIME", nullable: true),
                    ModifiedById = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectTask_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Lookups",
                columns: new[] { "Id", "Order", "Text", "Type", "Value" },
                values: new object[,]
                {
                    { 1, 1, "Male", "Gender", "Male" },
                    { 2, 2, "FeMale", "Gender", "FeMale" },
                    { 101, 1, "Videos", "ScreenType", "Videos" },
                    { 102, 2, "Products", "ScreenType", "Products" },
                    { 103, 3, "Deals", "ScreenType", "Deals" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Logins_UserId",
                schema: "Auth",
                table: "Logins",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CreatedById",
                table: "Project",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ModifiedById",
                table: "Project",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTask_ProjectId",
                table: "ProjectTask",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logins",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "Lookups",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProjectTask");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
