using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TestTask.Migrations
{
    public partial class RemakeCurrencies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DateCurrencyExchanges_Currencies_CurrencyId",
                table: "DateCurrencyExchanges");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropIndex(
                name: "IX_DateCurrencyExchanges_CurrencyId",
                table: "DateCurrencyExchanges");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "DateCurrencyExchanges");

            migrationBuilder.AlterColumn<double>(
                name: "Exchange",
                table: "DateCurrencyExchanges",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "DateCurrencyExchanges",
                type: "text",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<string>(
                name: "CurrencyName",
                table: "DateCurrencyExchanges",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyName",
                table: "DateCurrencyExchanges");

            migrationBuilder.AlterColumn<float>(
                name: "Exchange",
                table: "DateCurrencyExchanges",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "DateCurrencyExchanges",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "DateCurrencyExchanges",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Properties = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DateCurrencyExchanges_CurrencyId",
                table: "DateCurrencyExchanges",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_DateCurrencyExchanges_Currencies_CurrencyId",
                table: "DateCurrencyExchanges",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
