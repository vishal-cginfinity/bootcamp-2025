using ECommerceApi.Models;
using Microsoft.EntityFrameworkCore;
 
namespace ECommerceApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
 
        // These properties will become your tables
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
 
        // This method seeds your database with sample data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
 
            // --- Seed 5 Categories ---
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Electronics" },
                new Category { CategoryId = 2, Name = "Books" },
                new Category { CategoryId = 3, Name = "Clothing" },
                new Category { CategoryId = 4, Name = "Groceries" },
                new Category { CategoryId = 5, Name = "Sports" }
            );
 
            // --- Seed 50 Products (10 for each category) ---
 
            // --- Electronics (Category 1) ---
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, CategoryId = 1, Name = "Laptop", Description = "A powerful laptop for all your needs.", Price = 1200.00m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Laptop", StockQuantity = 10 },
                new Product { ProductId = 2, CategoryId = 1, Name = "Wireless Mouse", Description = "Ergonomic wireless mouse.", Price = 25.50m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Mouse", StockQuantity = 150 },
                new Product { ProductId = 3, CategoryId = 1, Name = "Mechanical Keyboard", Description = "Keyboard with tactile switches.", Price = 80.00m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Keyboard", StockQuantity = 75 },
                new Product { ProductId = 4, CategoryId = 1, Name = "4K Monitor", Description = "A 27-inch 4K UHD Monitor.", Price = 350.00m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=4K+Monitor", StockQuantity = 30 },
                new Product { ProductId = 5, CategoryId = 1, Name = "Bluetooth Headphones", Description = "Noise-cancelling over-ear headphones.", Price = 199.99m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Headphones", StockQuantity = 60 },
                new Product { ProductId = 6, CategoryId = 1, Name = "Smartphone", Description = "Latest model smartphone.", Price = 799.00m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Smartphone", StockQuantity = 25 },
                new Product { ProductId = 7, CategoryId = 1, Name = "Smart Watch", Description = "Fitness tracking smart watch.", Price = 249.00m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Smart+Watch", StockQuantity = 40 },
                new Product { ProductId = 8, CategoryId = 1, Name = "Webcam", Description = "1080p HD webcam for streaming.", Price = 65.00m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Webcam", StockQuantity = 110 },
                new Product { ProductId = 9, CategoryId = 1, Name = "Portable SSD", Description = "1TB portable solid state drive.", Price = 120.00m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Portable+SSD", StockQuantity = 55 },
                new Product { ProductId = 10, CategoryId = 1, Name = "USB-C Hub", Description = "8-in-1 USB-C adapter hub.", Price = 39.99m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=USB-C+Hub", StockQuantity = 130 }
            );
 
            // --- Books (Category 2) ---
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 11, CategoryId = 2, Name = "React Book", Description = "Learn React from scratch.", Price = 45.00m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=React+Book", StockQuantity = 50 },
                new Product { ProductId = 12, CategoryId = 2, Name = "C# Programming", Description = "In-depth guide to C#.", Price = 55.00m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=C#+Book", StockQuantity = 60 },
                new Product { ProductId = 13, CategoryId = 2, Name = "The Great Gatsby", Description = "A classic novel.", Price = 12.99m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Gatsby", StockQuantity = 200 },
                new Product { ProductId = 14, CategoryId = 2, Name = "Sci-Fi Novel", Description = "A best-selling science fiction novel.", Price = 18.50m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Sci-Fi+Novel", StockQuantity = 120 },
                new Product { ProductId = 15, CategoryId = 2, Name = "Cookbook", Description = "100 easy recipes.", Price = 22.00m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Cookbook", StockQuantity = 90 },
                new Product { ProductId = 16, CategoryId = 2, Name = "History of Rome", Description = "A detailed look at the Roman Empire.", Price = 29.99m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=History+Book", StockQuantity = 40 },
                new Product { ProductId = 17, CategoryId = 2, Name = "Python for Beginners", Description = "Introduction to Python programming.", Price = 39.99m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Python+Book", StockQuantity = 70 },
                new Product { ProductId = 18, CategoryId = 2, Name = "Mystery Thriller", Description = "A gripping mystery.", Price = 14.99m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Mystery+Book", StockQuantity = 110 },
                new Product { ProductId = 19, CategoryId = 2, Name = "Biography", Description = "Biography of a famous figure.", Price = 20.00m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Biography", StockQuantity = 30 },
                new Product { ProductId = 20, CategoryId = 2, Name = "Poetry Collection", Description = "A collection of modern poetry.", Price = 16.50m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Poetry", StockQuantity = 80 }
            );
            // --- Clothing (Category 3) ---
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 21, CategoryId = 3, Name = "T-Shirt", Description = "A comfortable cotton t-shirt.", Price = 15.00m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=T-Shirt", StockQuantity = 200 },
                new Product { ProductId = 22, CategoryId = 3, Name = "Jeans", Description = "Blue denim jeans.", Price = 40.00m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Jeans", StockQuantity = 150 },
                new Product { ProductId = 23, CategoryId = 3, Name = "Hoodie", Description = "A warm fleece hoodie.", Price = 35.00m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Hoodie", StockQuantity = 100 },
                new Product { ProductId = 24, CategoryId = 3, Name = "Sneakers", Description = "Running sneakers.", Price = 75.00m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Sneakers", StockQuantity = 80 },
                new Product { ProductId = 25, CategoryId = 3, Name = "Beanie", Description = "A warm winter beanie.", Price = 12.00m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Beanie", StockQuantity = 300 },
                new Product { ProductId = 26, CategoryId = 3, Name = "Dress Shirt", Description = "A formal cotton dress shirt.", Price = 45.00m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Dress+Shirt", StockQuantity = 60 },
                new Product { ProductId = 27, CategoryId = 3, Name = "Socks", Description = "A 3-pack of cotton socks.", Price = 10.00m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Socks", StockQuantity = 400 },
                new Product { ProductId = 28, CategoryId = 3, Name = "Winter Jacket", Description = "A waterproof winter jacket.", Price = 120.00m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Jacket", StockQuantity = 40 },
                new Product { ProductId = 29, CategoryId = 3, Name = "Shorts", Description = "Casual cargo shorts.", Price = 28.00m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Shorts", StockQuantity = 110 },
                new Product { ProductId = 30, CategoryId = 3, Name = "Leather Belt", Description = "A genuine leather belt.", Price = 22.00m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Belt", StockQuantity = 90 }
            );
 
            // --- Groceries (Category 4) ---
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 31, CategoryId = 4, Name = "Apples", Description = "1kg of fresh apples.", Price = 3.99m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Apples", StockQuantity = 500 },
                new Product { ProductId = 32, CategoryId = 4, Name = "Milk", Description = "1 gallon of whole milk.", Price = 4.50m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Milk", StockQuantity = 300 },
                new Product { ProductId = 33, CategoryId = 4, Name = "Bread", Description = "A loaf of whole wheat bread.", Price = 2.99m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Bread", StockQuantity = 400 },
                new Product { ProductId = 34, CategoryId = 4, Name = "Eggs", Description = "A dozen large eggs.", Price = 3.20m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Eggs", StockQuantity = 600 },
                new Product { ProductId = 35, CategoryId = 4, Name = "Chicken Breast", Description = "1lb of boneless chicken breast.", Price = 5.99m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Chicken", StockQuantity = 150 },
                new Product { ProductId = 36, CategoryId = 4, Name = "Pasta", Description = "A box of spaghetti.", Price = 1.50m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Pasta", StockQuantity = 700 },
                new Product { ProductId = 37, CategoryId = 4, Name = "Coffee", Description = "A bag of whole bean coffee.", Price = 12.99m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Coffee", StockQuantity = 200 },
                new Product { ProductId = 38, CategoryId = 4, Name = "Bananas", Description = "A bunch of bananas.", Price = 1.99m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Bananas", StockQuantity = 800 },
                new Product { ProductId = 39, CategoryId = 4, Name = "Cereal", Description = "A box of breakfast cereal.", Price = 4.80m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Cereal", StockQuantity = 250 },
                new Product { ProductId = 40, CategoryId = 4, Name = "Orange Juice", Description = "Half-gallon of orange juice.", Price = 5.50m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Orange+Juice", StockQuantity = 180 }
            );
 
            // --- Sports (Category 5) ---
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 41, CategoryId = 5, Name = "Basketball", Description = "Official size basketball.", Price = 24.99m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Basketball", StockQuantity = 100 },
                new Product { ProductId = 42, CategoryId = 5, Name = "Soccer Ball", Description = "Size 5 soccer ball.", Price = 22.00m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Soccer+Ball", StockQuantity = 120 },
                new Product { ProductId = 43, CategoryId = 5, Name = "Yoga Mat", Description = "A non-slip yoga mat.", Price = 18.00m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Yoga+Mat", StockQuantity = 200 },
                new Product { ProductId = 44, CategoryId = 5, Name = "Dumbbells", Description = "Set of 5lb dumbbells.", Price = 15.00m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Dumbbells", StockQuantity = 80 },
                new Product { ProductId = 45, CategoryId = 5, Name = "Tennis Racket", Description = "A lightweight tennis racket.", Price = 55.00m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Tennis+Racket", StockQuantity = 60 },
                new Product { ProductId = 46, CategoryId = 5, Name = "Water Bottle", Description = "A 32oz insulated water bottle.", Price = 20.00m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Water+Bottle", StockQuantity = 300 },
                new Product { ProductId = 47, CategoryId = 5, Name = "Running Shoes", Description = "Men's running shoes, size 10.", Price = 85.00m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Running+Shoes", StockQuantity = 70 },
                new Product { ProductId = 48, CategoryId = 5, Name = "Bicycle Helmet", Description = "A CPSC-certified bike helmet.", Price = 45.00m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Helmet", StockQuantity = 90 },
                new Product { ProductId = 49, CategoryId = 5, Name = "Jump Rope", Description = "A speed jump rope.", Price = 12.50m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Jump+Rope", StockQuantity = 150 },
                new Product { ProductId = 50, CategoryId = 5, Name = "Golf Balls", Description = "A dozen golf balls.", Price = 30.00m, ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Golf+Balls", StockQuantity = 100 }
            );
        }
    }
}