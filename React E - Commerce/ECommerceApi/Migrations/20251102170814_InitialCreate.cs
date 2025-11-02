using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Books" },
                    { 3, "Clothing" },
                    { 4, "Groceries" },
                    { 5, "Sports" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "ImageUrl", "Name", "Price", "StockQuantity" },
                values: new object[,]
                {
                    { 1, 1, "A powerful laptop for all your needs.", "https://placehold.co/600x400/EEE/31343C?text=Laptop", "Laptop", 1200.00m, 10 },
                    { 2, 1, "Ergonomic wireless mouse.", "https://placehold.co/600x400/EEE/31343C?text=Mouse", "Wireless Mouse", 25.50m, 150 },
                    { 3, 1, "Keyboard with tactile switches.", "https://placehold.co/600x400/EEE/31343C?text=Keyboard", "Mechanical Keyboard", 80.00m, 75 },
                    { 4, 1, "A 27-inch 4K UHD Monitor.", "https://placehold.co/600x400/EEE/31343C?text=4K+Monitor", "4K Monitor", 350.00m, 30 },
                    { 5, 1, "Noise-cancelling over-ear headphones.", "https://placehold.co/600x400/EEE/31343C?text=Headphones", "Bluetooth Headphones", 199.99m, 60 },
                    { 6, 1, "Latest model smartphone.", "https://placehold.co/600x400/EEE/31343C?text=Smartphone", "Smartphone", 799.00m, 25 },
                    { 7, 1, "Fitness tracking smart watch.", "https://placehold.co/600x400/EEE/31343C?text=Smart+Watch", "Smart Watch", 249.00m, 40 },
                    { 8, 1, "1080p HD webcam for streaming.", "https://placehold.co/600x400/EEE/31343C?text=Webcam", "Webcam", 65.00m, 110 },
                    { 9, 1, "1TB portable solid state drive.", "https://placehold.co/600x400/EEE/31343C?text=Portable+SSD", "Portable SSD", 120.00m, 55 },
                    { 10, 1, "8-in-1 USB-C adapter hub.", "https://placehold.co/600x400/EEE/31343C?text=USB-C+Hub", "USB-C Hub", 39.99m, 130 },
                    { 11, 2, "Learn React from scratch.", "https://placehold.co/600x400/EEE/31343C?text=React+Book", "React Book", 45.00m, 50 },
                    { 12, 2, "In-depth guide to C#.", "https://placehold.co/600x400/EEE/31343C?text=C#+Book", "C# Programming", 55.00m, 60 },
                    { 13, 2, "A classic novel.", "https://placehold.co/600x400/EEE/31343C?text=Gatsby", "The Great Gatsby", 12.99m, 200 },
                    { 14, 2, "A best-selling science fiction novel.", "https://placehold.co/600x400/EEE/31343C?text=Sci-Fi+Novel", "Sci-Fi Novel", 18.50m, 120 },
                    { 15, 2, "100 easy recipes.", "https://placehold.co/600x400/EEE/31343C?text=Cookbook", "Cookbook", 22.00m, 90 },
                    { 16, 2, "A detailed look at the Roman Empire.", "https://placehold.co/600x400/EEE/31343C?text=History+Book", "History of Rome", 29.99m, 40 },
                    { 17, 2, "Introduction to Python programming.", "https://placehold.co/600x400/EEE/31343C?text=Python+Book", "Python for Beginners", 39.99m, 70 },
                    { 18, 2, "A gripping mystery.", "https://placehold.co/600x400/EEE/31343C?text=Mystery+Book", "Mystery Thriller", 14.99m, 110 },
                    { 19, 2, "Biography of a famous figure.", "https://placehold.co/600x400/EEE/31343C?text=Biography", "Biography", 20.00m, 30 },
                    { 20, 2, "A collection of modern poetry.", "https://placehold.co/600x400/EEE/31343C?text=Poetry", "Poetry Collection", 16.50m, 80 },
                    { 21, 3, "A comfortable cotton t-shirt.", "https://placehold.co/600x400/EEE/31343C?text=T-Shirt", "T-Shirt", 15.00m, 200 },
                    { 22, 3, "Blue denim jeans.", "https://placehold.co/600x400/EEE/31343C?text=Jeans", "Jeans", 40.00m, 150 },
                    { 23, 3, "A warm fleece hoodie.", "https://placehold.co/600x400/EEE/31343C?text=Hoodie", "Hoodie", 35.00m, 100 },
                    { 24, 3, "Running sneakers.", "https://placehold.co/600x400/EEE/31343C?text=Sneakers", "Sneakers", 75.00m, 80 },
                    { 25, 3, "A warm winter beanie.", "https://placehold.co/600x400/EEE/31343C?text=Beanie", "Beanie", 12.00m, 300 },
                    { 26, 3, "A formal cotton dress shirt.", "https://placehold.co/600x400/EEE/31343C?text=Dress+Shirt", "Dress Shirt", 45.00m, 60 },
                    { 27, 3, "A 3-pack of cotton socks.", "https://placehold.co/600x400/EEE/31343C?text=Socks", "Socks", 10.00m, 400 },
                    { 28, 3, "A waterproof winter jacket.", "https://placehold.co/600x400/EEE/31343C?text=Jacket", "Winter Jacket", 120.00m, 40 },
                    { 29, 3, "Casual cargo shorts.", "https://placehold.co/600x400/EEE/31343C?text=Shorts", "Shorts", 28.00m, 110 },
                    { 30, 3, "A genuine leather belt.", "https://placehold.co/600x400/EEE/31343C?text=Belt", "Leather Belt", 22.00m, 90 },
                    { 31, 4, "1kg of fresh apples.", "https://placehold.co/600x400/EEE/31343C?text=Apples", "Apples", 3.99m, 500 },
                    { 32, 4, "1 gallon of whole milk.", "https://placehold.co/600x400/EEE/31343C?text=Milk", "Milk", 4.50m, 300 },
                    { 33, 4, "A loaf of whole wheat bread.", "https://placehold.co/600x400/EEE/31343C?text=Bread", "Bread", 2.99m, 400 },
                    { 34, 4, "A dozen large eggs.", "https://placehold.co/600x400/EEE/31343C?text=Eggs", "Eggs", 3.20m, 600 },
                    { 35, 4, "1lb of boneless chicken breast.", "https://placehold.co/600x400/EEE/31343C?text=Chicken", "Chicken Breast", 5.99m, 150 },
                    { 36, 4, "A box of spaghetti.", "https://placehold.co/600x400/EEE/31343C?text=Pasta", "Pasta", 1.50m, 700 },
                    { 37, 4, "A bag of whole bean coffee.", "https://placehold.co/600x400/EEE/31343C?text=Coffee", "Coffee", 12.99m, 200 },
                    { 38, 4, "A bunch of bananas.", "https://placehold.co/600x400/EEE/31343C?text=Bananas", "Bananas", 1.99m, 800 },
                    { 39, 4, "A box of breakfast cereal.", "https://placehold.co/600x400/EEE/31343C?text=Cereal", "Cereal", 4.80m, 250 },
                    { 40, 4, "Half-gallon of orange juice.", "https://placehold.co/600x400/EEE/31343C?text=Orange+Juice", "Orange Juice", 5.50m, 180 },
                    { 41, 5, "Official size basketball.", "https://placehold.co/600x400/EEE/31343C?text=Basketball", "Basketball", 24.99m, 100 },
                    { 42, 5, "Size 5 soccer ball.", "https://placehold.co/600x400/EEE/31343C?text=Soccer+Ball", "Soccer Ball", 22.00m, 120 },
                    { 43, 5, "A non-slip yoga mat.", "https://placehold.co/600x400/EEE/31343C?text=Yoga+Mat", "Yoga Mat", 18.00m, 200 },
                    { 44, 5, "Set of 5lb dumbbells.", "https://placehold.co/600x400/EEE/31343C?text=Dumbbells", "Dumbbells", 15.00m, 80 },
                    { 45, 5, "A lightweight tennis racket.", "https://placehold.co/600x400/EEE/31343C?text=Tennis+Racket", "Tennis Racket", 55.00m, 60 },
                    { 46, 5, "A 32oz insulated water bottle.", "https://placehold.co/600x400/EEE/31343C?text=Water+Bottle", "Water Bottle", 20.00m, 300 },
                    { 47, 5, "Men's running shoes, size 10.", "https://placehold.co/600x400/EEE/31343C?text=Running+Shoes", "Running Shoes", 85.00m, 70 },
                    { 48, 5, "A CPSC-certified bike helmet.", "https://placehold.co/600x400/EEE/31343C?text=Helmet", "Bicycle Helmet", 45.00m, 90 },
                    { 49, 5, "A speed jump rope.", "https://placehold.co/600x400/EEE/31343C?text=Jump+Rope", "Jump Rope", 12.50m, 150 },
                    { 50, 5, "A dozen golf balls.", "https://placehold.co/600x400/EEE/31343C?text=Golf+Balls", "Golf Balls", 30.00m, 100 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
