using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class updateProdct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Variants");

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductWebSiteId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_ProductsWebSite_ProductWebSiteId",
                        column: x => x.ProductWebSiteId,
                        principalTable: "ProductsWebSite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ProductWebSiteId",
                table: "Tags",
                column: "ProductWebSiteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.CreateTable(
                name: "Variants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductWebSiteId = table.Column<int>(type: "INTEGER", nullable: false),
                    color = table.Column<string>(type: "TEXT", nullable: true),
                    imageId = table.Column<int>(type: "INTEGER", nullable: false),
                    size = table.Column<string>(type: "TEXT", nullable: true),
                    sku = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Variants_Images_imageId",
                        column: x => x.imageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Variants_ProductsWebSite_ProductWebSiteId",
                        column: x => x.ProductWebSiteId,
                        principalTable: "ProductsWebSite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Variants_imageId",
                table: "Variants",
                column: "imageId");

            migrationBuilder.CreateIndex(
                name: "IX_Variants_ProductWebSiteId",
                table: "Variants",
                column: "ProductWebSiteId");
        }
    }
}
