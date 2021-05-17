using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IARATesteCotacao.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(64)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Quotation",
                columns: table => new
                {
                    QuotationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CnpjClient = table.Column<string>(type: "varchar(14)", nullable: false),
                    CnpjSeller = table.Column<string>(type: "varchar(14)", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateLimit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ZipCode = table.Column<string>(type: "varchar(10)", nullable: false),
                    Address = table.Column<string>(type: "varchar(64)", nullable: true),
                    ComplementAddress = table.Column<string>(type: "varchar(32)", nullable: true),
                    District = table.Column<string>(type: "varchar(32)", nullable: true),
                    State = table.Column<string>(type: "varchar(2)", nullable: true),
                    Comments = table.Column<string>(type: "varchar(300)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotation", x => x.QuotationId);
                });

            migrationBuilder.CreateTable(
                name: "ItensQuotation",
                columns: table => new
                {
                    QuotationId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ItemNumber = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false, defaultValue: 0m),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Manufacturer = table.Column<string>(type: "varchar(32)", nullable: true),
                    Unit = table.Column<string>(type: "varchar(32)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensQuotation", x => new { x.QuotationId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ItensQuotation_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensQuotation_Quotation_QuotationId",
                        column: x => x.QuotationId,
                        principalTable: "Quotation",
                        principalColumn: "QuotationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensQuotation_ProductId",
                table: "ItensQuotation",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensQuotation");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Quotation");
        }
    }
}
