using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace fuzzy.core.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Categories",
            //    columns: table => new
            //    {
            //        CategoryID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        CategoryName = table.Column<string>(nullable: true),
            //        Description = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Categories", x => x.CategoryID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Customers",
            //    columns: table => new
            //    {
            //        CustomerID = table.Column<string>(nullable: false),
            //        CompanyName = table.Column<string>(nullable: true),
            //        ContactName = table.Column<string>(nullable: true),
            //        ContactTitle = table.Column<string>(nullable: true),
            //        Email = table.Column<string>(nullable: true),
            //        Address = table.Column<string>(nullable: true),
            //        City = table.Column<string>(nullable: true),
            //        Region = table.Column<string>(nullable: true),
            //        PostalCode = table.Column<string>(nullable: true),
            //        Country = table.Column<string>(nullable: true),
            //        Phone = table.Column<string>(nullable: true),
            //        Fax = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Customers", x => x.CustomerID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Products",
            //    columns: table => new
            //    {
            //        ProductID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        ProductName = table.Column<string>(maxLength: 10, nullable: false),
            //        CategoryID = table.Column<int>(nullable: true),
            //        QuantityPerUnit = table.Column<string>(nullable: true),
            //        UnitPrice = table.Column<decimal>(nullable: true),
            //        UnitsInStock = table.Column<short>(nullable: true),
            //        UnitsOnOrder = table.Column<short>(nullable: true),
            //        ReorderLevel = table.Column<short>(nullable: true),
            //        Discontinued = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Products", x => x.ProductID);
            //        table.ForeignKey(
            //            name: "FK_Products_Categories_CategoryID",
            //            column: x => x.CategoryID,
            //            principalTable: "Categories",
            //            principalColumn: "CategoryID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CartDetails",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        CustomerID = table.Column<string>(nullable: true),
            //        ProductId = table.Column<int>(nullable: false),
            //        Quantity = table.Column<int>(nullable: false),
            //        Price = table.Column<decimal>(nullable: false)
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

            //migrationBuilder.CreateIndex(
            //    name: "IX_Products_CategoryID",
            //    table: "Products",
            //    column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "CartDetails");

            //migrationBuilder.DropTable(
            //    name: "Customers");

            //migrationBuilder.DropTable(
            //    name: "Products");

            //migrationBuilder.DropTable(
            //    name: "Categories");
        }
    }
}
