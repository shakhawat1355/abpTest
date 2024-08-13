using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAS.FloraFire.ClientPortal.Migrations
{
    /// <inheritdoc />
    public partial class Created_Shop_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppShop",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ShopCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsFFC = table.Column<bool>(type: "bit", nullable: true),
                    OpenSunday = table.Column<int>(type: "int", nullable: true),
                    OrderSent = table.Column<int>(type: "int", nullable: true),
                    OrderReceived = table.Column<int>(type: "int", nullable: true),
                    OrderRejected = table.Column<int>(type: "int", nullable: true),
                    WireServiceId = table.Column<int>(type: "int", nullable: true),
                    IsPreferred = table.Column<bool>(type: "bit", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppShop", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppShop_Name",
                table: "AppShop",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppShop");
        }
    }
}
