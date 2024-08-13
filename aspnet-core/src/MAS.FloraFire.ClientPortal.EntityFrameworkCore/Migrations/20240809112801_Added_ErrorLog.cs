using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAS.FloraFire.ClientPortal.Migrations
{
    /// <inheritdoc />
    public partial class Added_ErrorLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppErrorLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShortMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LogLevel = table.Column<int>(type: "int", nullable: false),
                    PageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferredUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppErrorLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppStore",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StoreCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StoreName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    City = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Logo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    TimeZone = table.Column<int>(type: "int", nullable: false),
                    FaxNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsAddOnMasDirectory = table.Column<bool>(type: "bit", nullable: false),
                    IsPrimaryStore = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsBillingAddress = table.Column<bool>(type: "bit", nullable: false),
                    SalesTax = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    IsTrackInventory = table.Column<bool>(type: "bit", nullable: false),
                    TimeFormateId = table.Column<int>(type: "int", nullable: false),
                    DateTimeFormate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    FacebookUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TwitterUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PinterestUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    AddtoMasDirectoryNetwork = table.Column<bool>(type: "bit", nullable: false),
                    ReceiptFooterNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppStore", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppStore_StoreCode",
                table: "AppStore",
                column: "StoreCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppErrorLog");

            migrationBuilder.DropTable(
                name: "AppStore");
        }
    }
}
