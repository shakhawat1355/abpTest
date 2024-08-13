using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAS.FloraFire.ClientPortal.Migrations
{
    /// <inheritdoc />
    public partial class Added_Core_Entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppCountry",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TwoLetterIsoCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    ThreeLetterIsoCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    NumericIsoCode = table.Column<int>(type: "int", nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCountry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppCustomer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StateProvinceId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    IsWholeSale = table.Column<bool>(type: "bit", nullable: false),
                    IsOptDirectoryMarketing = table.Column<bool>(type: "bit", nullable: false),
                    StatusValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AcctClassValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AcctManagerValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TaxExempt = table.Column<bool>(type: "bit", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvoicePaymentSchedulerValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ARStatementInvoiceTypeValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReferredByValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiscountOnWireout = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TermValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriceSheetCodeValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerReference = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountOpenDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastStatementDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastPurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastPaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    YTDPayments = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LYTDPayments = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LifetimePayments = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LifetimeCreditLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    YTDAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LYTDsalesAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LifetimeSalesAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCustomer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppCustomerComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CommentAsLocationNote = table.Column<bool>(type: "bit", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCustomerComments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppEmailDirectory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    OptOutForMarketing = table.Column<bool>(type: "bit", nullable: false),
                    OptForDirectMarketing = table.Column<bool>(type: "bit", nullable: false),
                    EntityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppEmailDirectory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppPhoneDirectory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumberType = table.Column<int>(type: "int", nullable: false),
                    IsAcceptTextMessage = table.Column<bool>(type: "bit", nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    EntityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPhoneDirectory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppStoreWorkHours",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Day = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    EndTime = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    IsClose = table.Column<bool>(type: "bit", nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppStoreWorkHours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppValueType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppValueType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppStateProvince",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppStateProvince", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppStateProvince_AppCountry_CountryId",
                        column: x => x.CountryId,
                        principalTable: "AppCountry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppValue",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ValueTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsPreSelect = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppValue_AppValueType_ValueTypeId",
                        column: x => x.ValueTypeId,
                        principalTable: "AppValueType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppCustomer_Name",
                table: "AppCustomer",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_AppEmailDirectory_Email",
                table: "AppEmailDirectory",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_AppPhoneDirectory_PhoneNumber",
                table: "AppPhoneDirectory",
                column: "PhoneNumber");

            migrationBuilder.CreateIndex(
                name: "IX_AppStateProvince_CountryId",
                table: "AppStateProvince",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_AppValue_Name",
                table: "AppValue",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_AppValue_ValueTypeId",
                table: "AppValue",
                column: "ValueTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppValueType_Name",
                table: "AppValueType",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppCustomer");

            migrationBuilder.DropTable(
                name: "AppCustomerComments");

            migrationBuilder.DropTable(
                name: "AppEmailDirectory");

            migrationBuilder.DropTable(
                name: "AppPhoneDirectory");

            migrationBuilder.DropTable(
                name: "AppStateProvince");

            migrationBuilder.DropTable(
                name: "AppStoreWorkHours");

            migrationBuilder.DropTable(
                name: "AppValue");

            migrationBuilder.DropTable(
                name: "AppCountry");

            migrationBuilder.DropTable(
                name: "AppValueType");
        }
    }
}
