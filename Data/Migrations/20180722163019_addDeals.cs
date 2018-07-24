using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addDeals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    Key = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Consignees",
                columns: table => new
                {
                    Key = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consignees", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Key = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Formulations",
                columns: table => new
                {
                    Key = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formulations", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Key = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Ports",
                columns: table => new
                {
                    Key = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ports", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Key = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "TransportCompanies",
                columns: table => new
                {
                    Key = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportCompanies", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Deals",
                columns: table => new
                {
                    Key = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderNumber = table.Column<string>(nullable: true),
                    Reexport = table.Column<bool>(nullable: false),
                    BuyerId = table.Column<int>(nullable: false),
                    ConsigneeId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    FormulationId = table.Column<int>(nullable: false),
                    PackageId = table.Column<int>(nullable: false),
                    PortId = table.Column<int>(nullable: false),
                    TransportCompanyId = table.Column<int>(nullable: false),
                    ExpeditionDate = table.Column<DateTime>(nullable: false),
                    AuthorId = table.Column<string>(nullable: true),
                    InvoiceNumber = table.Column<string>(nullable: true),
                    InkasoAkrNumber = table.Column<string>(nullable: true),
                    ClinetOrderId = table.Column<string>(nullable: true),
                    ZN_MN = table.Column<string>(nullable: true),
                    DestinationPort = table.Column<string>(nullable: true),
                    Quantity = table.Column<decimal>(nullable: false),
                    PricePerKg = table.Column<decimal>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    CR = table.Column<decimal>(nullable: false),
                    SumInEuro = table.Column<decimal>(nullable: false),
                    SumInUSD = table.Column<decimal>(nullable: false),
                    ViaPort = table.Column<string>(nullable: true),
                    CreditTerms = table.Column<string>(nullable: true),
                    Frei = table.Column<decimal>(nullable: false),
                    FreiCurrency = table.Column<string>(nullable: true),
                    InsCurrency = table.Column<string>(nullable: true),
                    Insurance = table.Column<decimal>(nullable: false),
                    TypeOfTransport = table.Column<string>(nullable: true),
                    TransportUnit = table.Column<int>(nullable: false),
                    TransportNumber = table.Column<string>(nullable: true),
                    TransportDoc = table.Column<string>(nullable: true),
                    DateBL = table.Column<DateTime>(nullable: false),
                    ETD = table.Column<DateTime>(nullable: false),
                    ETA = table.Column<DateTime>(nullable: false),
                    TransportDays = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deals", x => x.Key);
                    table.ForeignKey(
                        name: "FK_Deals_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Deals_Buyers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Buyers",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deals_Consignees_ConsigneeId",
                        column: x => x.ConsigneeId,
                        principalTable: "Consignees",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deals_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deals_Formulations_FormulationId",
                        column: x => x.FormulationId,
                        principalTable: "Formulations",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deals_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deals_Ports_PortId",
                        column: x => x.PortId,
                        principalTable: "Ports",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deals_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deals_TransportCompanies_TransportCompanyId",
                        column: x => x.TransportCompanyId,
                        principalTable: "TransportCompanies",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deals_AuthorId",
                table: "Deals",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_BuyerId",
                table: "Deals",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_ConsigneeId",
                table: "Deals",
                column: "ConsigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_CountryId",
                table: "Deals",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_FormulationId",
                table: "Deals",
                column: "FormulationId");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_PackageId",
                table: "Deals",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_PortId",
                table: "Deals",
                column: "PortId");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_ProductId",
                table: "Deals",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_TransportCompanyId",
                table: "Deals",
                column: "TransportCompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deals");

            migrationBuilder.DropTable(
                name: "Buyers");

            migrationBuilder.DropTable(
                name: "Consignees");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Formulations");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Ports");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "TransportCompanies");
        }
    }
}
