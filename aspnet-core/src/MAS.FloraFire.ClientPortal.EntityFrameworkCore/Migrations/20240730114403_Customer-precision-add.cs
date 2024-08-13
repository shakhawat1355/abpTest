using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAS.FloraFire.ClientPortal.Migrations
{
    /// <inheritdoc />
    public partial class Customerprecisionadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
              name: "TempStateProvinceId",
              table: "AppCustomer",
              type: "uniqueidentifier",
              nullable: true
          );

            migrationBuilder.AddColumn<Guid>(
                name: "TempCountryId",
                table: "AppCustomer",
                type: "uniqueidentifier",
                nullable: true
            );

            migrationBuilder.Sql(
                @"
                    UPDATE AppCustomer 
                    SET TempStateProvinceId = NEWID(), -- Generate a new unique identifier
                        TempCountryId = NEWID()         -- Generate a new unique identifier
                    WHERE StateProvinceId IS NOT NULL AND CountryId IS NOT NULL "
            );

            migrationBuilder.DropColumn(name: "StateProvinceId", table: "AppCustomer");

            migrationBuilder.DropColumn(name: "CountryId", table: "AppCustomer");

            migrationBuilder.RenameColumn(
                name: "TempStateProvinceId",
                table: "AppCustomer",
                newName: "StateProvinceId"
            );

            migrationBuilder.RenameColumn(
                name: "TempCountryId",
                table: "AppCustomer",
                newName: "CountryId"
            );

            migrationBuilder.AlterColumn<Guid>(
                name: "StateProvinceId",
                table: "AppCustomer",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true
            );

            migrationBuilder.AlterColumn<Guid>(
                name: "CountryId",
                table: "AppCustomer",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true
            );

            migrationBuilder.AlterColumn<decimal>(
                name: "YTDPayments",
                table: "AppCustomer",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)"
            );

            migrationBuilder.AlterColumn<decimal>(
                name: "YTDAmount",
                table: "AppCustomer",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)"
            );

            migrationBuilder.AlterColumn<decimal>(
                name: "LifetimeSalesAmount",
                table: "AppCustomer",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)"
            );

            migrationBuilder.AlterColumn<decimal>(
                name: "LifetimePayments",
                table: "AppCustomer",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)"
            );

            migrationBuilder.AlterColumn<decimal>(
                name: "LifetimeCreditLimit",
                table: "AppCustomer",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)"
            );

            migrationBuilder.AlterColumn<decimal>(
                name: "LYTDsalesAmount",
                table: "AppCustomer",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)"
            );

            migrationBuilder.AlterColumn<decimal>(
                name: "LYTDPayments",
                table: "AppCustomer",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)"
            );

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountOnWireout",
                table: "AppCustomer",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)"
            );

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "AppCustomer",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
               name: "YTDPayments",
               table: "AppCustomer",
               type: "decimal(18,2)",
               nullable: false,
               oldClrType: typeof(decimal),
               oldType: "decimal(18,4)"
           );

            migrationBuilder.AlterColumn<decimal>(
                name: "YTDAmount",
                table: "AppCustomer",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)"
            );

            migrationBuilder.AlterColumn<int>(
                name: "StateProvinceId",
                table: "AppCustomer",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier"
            );

            migrationBuilder.AlterColumn<decimal>(
                name: "LifetimeSalesAmount",
                table: "AppCustomer",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)"
            );

            migrationBuilder.AlterColumn<decimal>(
                name: "LifetimePayments",
                table: "AppCustomer",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)"
            );

            migrationBuilder.AlterColumn<decimal>(
                name: "LifetimeCreditLimit",
                table: "AppCustomer",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)"
            );

            migrationBuilder.AlterColumn<decimal>(
                name: "LYTDsalesAmount",
                table: "AppCustomer",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)"
            );

            migrationBuilder.AlterColumn<decimal>(
                name: "LYTDPayments",
                table: "AppCustomer",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)"
            );

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountOnWireout",
                table: "AppCustomer",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)"
            );

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "AppCustomer",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)"
            );

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "AppCustomer",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier"
            );
        }
    }
}
