using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_Optiek.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountType",
                columns: table => new
                {
                    AccountTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountType", x => x.AccountTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Sterkte",
                columns: table => new
                {
                    SterkteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sterkte = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sterkte", x => x.SterkteID);
                });

            migrationBuilder.CreateTable(
                name: "Gebruikers",
                columns: table => new
                {
                    GebruikerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true),
                    Voornaam = table.Column<string>(nullable: true),
                    AccounttypeID = table.Column<int>(nullable: false),
                    EmailAdress = table.Column<string>(nullable: true),
                    Woonplaats = table.Column<string>(nullable: true),
                    Adres = table.Column<string>(nullable: true),
                    Geboortedatum = table.Column<DateTime>(nullable: false),
                    BTW_Nummer = table.Column<string>(nullable: true),
                    Oogsterkte = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruikers", x => x.GebruikerID);
                    table.ForeignKey(
                        name: "FK_Gebruikers_AccountType_AccounttypeID",
                        column: x => x.AccounttypeID,
                        principalTable: "AccountType",
                        principalColumn: "AccountTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: false),
                    Omschrijving = table.Column<string>(nullable: true),
                    SterkteID = table.Column<int>(nullable: false),
                    Prijs = table.Column<decimal>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    BrilType = table.Column<string>(nullable: true),
                    LensType = table.Column<string>(nullable: true),
                    aantal = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Product_Sterkte_SterkteID",
                        column: x => x.SterkteID,
                        principalTable: "Sterkte",
                        principalColumn: "SterkteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bestelling",
                columns: table => new
                {
                    BestellingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GebruikerID = table.Column<int>(nullable: false),
                    Besteldatum = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestelling", x => x.BestellingID);
                    table.ForeignKey(
                        name: "FK_Bestelling_Gebruikers_GebruikerID",
                        column: x => x.GebruikerID,
                        principalTable: "Gebruikers",
                        principalColumn: "GebruikerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WinkelwagenItem",
                columns: table => new
                {
                    WinkelwagenItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GebruikerID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    Aantal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WinkelwagenItem", x => x.WinkelwagenItemID);
                    table.ForeignKey(
                        name: "FK_WinkelwagenItem_Gebruikers_GebruikerID",
                        column: x => x.GebruikerID,
                        principalTable: "Gebruikers",
                        principalColumn: "GebruikerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WinkelwagenItem_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BestellingItem",
                columns: table => new
                {
                    BestellingItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BestellingID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    Aantal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BestellingItem", x => x.BestellingItemID);
                    table.ForeignKey(
                        name: "FK_BestellingItem_Bestelling_BestellingID",
                        column: x => x.BestellingID,
                        principalTable: "Bestelling",
                        principalColumn: "BestellingID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BestellingItem_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bestelling_GebruikerID",
                table: "Bestelling",
                column: "GebruikerID");

            migrationBuilder.CreateIndex(
                name: "IX_BestellingItem_BestellingID",
                table: "BestellingItem",
                column: "BestellingID");

            migrationBuilder.CreateIndex(
                name: "IX_BestellingItem_ProductID",
                table: "BestellingItem",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Gebruikers_AccounttypeID",
                table: "Gebruikers",
                column: "AccounttypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SterkteID",
                table: "Product",
                column: "SterkteID");

            migrationBuilder.CreateIndex(
                name: "IX_WinkelwagenItem_GebruikerID",
                table: "WinkelwagenItem",
                column: "GebruikerID");

            migrationBuilder.CreateIndex(
                name: "IX_WinkelwagenItem_ProductID",
                table: "WinkelwagenItem",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BestellingItem");

            migrationBuilder.DropTable(
                name: "WinkelwagenItem");

            migrationBuilder.DropTable(
                name: "Bestelling");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Gebruikers");

            migrationBuilder.DropTable(
                name: "Sterkte");

            migrationBuilder.DropTable(
                name: "AccountType");
        }
    }
}
