using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Seller.Offers.Infrastructure.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ListingId = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<string>(nullable: false),
                    CreatorName = table.Column<string>(nullable: false),
                    IsAccepted = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offers");
        }
    }
}
