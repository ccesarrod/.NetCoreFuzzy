using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace fuzzy.core.Migrations
{
    public partial class CartDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          //  migrationBuilder.DropTable(
            //    name: "CartDetails");

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerID = table.Column<string>(nullable: false,maxLength:5,type:"nchar"),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                    //table.ForeignKey(
                    //    name: "FK_Cart_Customers_CustomerID",
                    //    column: x => x.CustomerID,
                    //    principalTable: "Customers",
                    //    principalColumn: "CustomerID",
                    //    onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cart_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Cart_CustomerID",
            //    table: "Cart",
            //    column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ProductId",
                table: "Cart",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Cart");

            //migrationBuilder.CreateTable(
            //    name: "CartDetails",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        CustomerID = table.Column<string>(nullable: true),
            //        Price = table.Column<decimal>(nullable: false),
            //        ProductId = table.Column<int>(nullable: false),
            //        Quantity = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CartDetails", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_CartDetails_Customers_CustomerID",
            //            column: x => x.CustomerID,
            //            principalTable: "Customers",
            //            principalColumn: "CustomerID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_CartDetails_Products_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "ProductID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_CartDetails_CustomerID",
            //    table: "CartDetails",
            //    column: "CustomerID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CartDetails_ProductId",
            //    table: "CartDetails",
            //    column: "ProductId");
        }
    }
}
