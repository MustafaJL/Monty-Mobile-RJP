using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MobileDataPlans",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    PricePerMonth = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileDataPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Username = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Salt = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    isAdmin = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    MobileDataPlanId = table.Column<long>(type: "bigint", nullable: false),
                    Cost = table.Column<decimal>(type: "numeric", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_MobileDataPlans_MobileDataPlanId",
                        column: x => x.MobileDataPlanId,
                        principalTable: "MobileDataPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MobileDataPlans",
                columns: new[] { "Id", "CreatedDate", "Description", "ModifiedDate", "Name", "PricePerMonth" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 1, 3, 19, 19, 5, 283, DateTimeKind.Utc).AddTicks(6385), "2GB for anghami", null, "Anghami", 10m },
                    { 2L, new DateTime(2024, 1, 3, 19, 19, 5, 283, DateTimeKind.Utc).AddTicks(6397), "60 min talking, 3Gb Mobile Data", null, "Web & Talk", 20m },
                    { 3L, new DateTime(2024, 1, 3, 19, 19, 5, 283, DateTimeKind.Utc).AddTicks(6398), "6GB Mobile Data", null, "Hs3", 30m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "FirstName", "LastName", "ModifiedDate", "Password", "PhoneNumber", "Salt", "Username", "isAdmin" },
                values: new object[] { 1L, new DateTime(2024, 1, 3, 19, 19, 5, 283, DateTimeKind.Utc).AddTicks(6997), "admin@monty.com", "admin", "admin", null, "mgjLOOyDs6fRsf94geNGIvSNk/ugZ+XstJZ0qqyMR3KG7xfEv2rd865kgsk4GqoJCCoTP7GFmBJICvJn1DaiDA==", "01000000", "Vkv4EVK21YeHqJ2xumfXsKMdOe2o0smoG4g+5Q+xKT55CHU8Gm6f2msoT+B7XdfzTUPFx3cIVa4PlOMq+iQrv+6kHRhuvWdwIv/31YtOgY2bfshFskuFzklqBiaygshnUb7NrwwwdhJcaGLcMHQ7L9RW7cKjgAbHABRUWxsm4eU=", "admin", true });

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_MobileDataPlanId",
                table: "Subscriptions",
                column: "MobileDataPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_UserId",
                table: "Subscriptions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "MobileDataPlans");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
