using ECommerceApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ECommerceApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ECommerceApi.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Electronics"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "Books"
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "Clothing"
                        },
                        new
                        {
                            CategoryId = 4,
                            Name = "Groceries"
                        },
                        new
                        {
                            CategoryId = 5,
                            Name = "Sports"
                        });
                });

            modelBuilder.Entity("ECommerceApi.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1,
                            Description = "A powerful laptop for all your needs.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Laptop",
                            Name = "Laptop",
                            Price = 1200.00m,
                            StockQuantity = 10
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 1,
                            Description = "Ergonomic wireless mouse.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Mouse",
                            Name = "Wireless Mouse",
                            Price = 25.50m,
                            StockQuantity = 150
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 1,
                            Description = "Keyboard with tactile switches.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Keyboard",
                            Name = "Mechanical Keyboard",
                            Price = 80.00m,
                            StockQuantity = 75
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 1,
                            Description = "A 27-inch 4K UHD Monitor.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=4K+Monitor",
                            Name = "4K Monitor",
                            Price = 350.00m,
                            StockQuantity = 30
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryId = 1,
                            Description = "Noise-cancelling over-ear headphones.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Headphones",
                            Name = "Bluetooth Headphones",
                            Price = 199.99m,
                            StockQuantity = 60
                        },
                        new
                        {
                            ProductId = 6,
                            CategoryId = 1,
                            Description = "Latest model smartphone.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Smartphone",
                            Name = "Smartphone",
                            Price = 799.00m,
                            StockQuantity = 25
                        },
                        new
                        {
                            ProductId = 7,
                            CategoryId = 1,
                            Description = "Fitness tracking smart watch.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Smart+Watch",
                            Name = "Smart Watch",
                            Price = 249.00m,
                            StockQuantity = 40
                        },
                        new
                        {
                            ProductId = 8,
                            CategoryId = 1,
                            Description = "1080p HD webcam for streaming.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Webcam",
                            Name = "Webcam",
                            Price = 65.00m,
                            StockQuantity = 110
                        },
                        new
                        {
                            ProductId = 9,
                            CategoryId = 1,
                            Description = "1TB portable solid state drive.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Portable+SSD",
                            Name = "Portable SSD",
                            Price = 120.00m,
                            StockQuantity = 55
                        },
                        new
                        {
                            ProductId = 10,
                            CategoryId = 1,
                            Description = "8-in-1 USB-C adapter hub.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=USB-C+Hub",
                            Name = "USB-C Hub",
                            Price = 39.99m,
                            StockQuantity = 130
                        },
                        new
                        {
                            ProductId = 11,
                            CategoryId = 2,
                            Description = "Learn React from scratch.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=React+Book",
                            Name = "React Book",
                            Price = 45.00m,
                            StockQuantity = 50
                        },
                        new
                        {
                            ProductId = 12,
                            CategoryId = 2,
                            Description = "In-depth guide to C#.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=C#+Book",
                            Name = "C# Programming",
                            Price = 55.00m,
                            StockQuantity = 60
                        },
                        new
                        {
                            ProductId = 13,
                            CategoryId = 2,
                            Description = "A classic novel.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Gatsby",
                            Name = "The Great Gatsby",
                            Price = 12.99m,
                            StockQuantity = 200
                        },
                        new
                        {
                            ProductId = 14,
                            CategoryId = 2,
                            Description = "A best-selling science fiction novel.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Sci-Fi+Novel",
                            Name = "Sci-Fi Novel",
                            Price = 18.50m,
                            StockQuantity = 120
                        },
                        new
                        {
                            ProductId = 15,
                            CategoryId = 2,
                            Description = "100 easy recipes.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Cookbook",
                            Name = "Cookbook",
                            Price = 22.00m,
                            StockQuantity = 90
                        },
                        new
                        {
                            ProductId = 16,
                            CategoryId = 2,
                            Description = "A detailed look at the Roman Empire.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=History+Book",
                            Name = "History of Rome",
                            Price = 29.99m,
                            StockQuantity = 40
                        },
                        new
                        {
                            ProductId = 17,
                            CategoryId = 2,
                            Description = "Introduction to Python programming.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Python+Book",
                            Name = "Python for Beginners",
                            Price = 39.99m,
                            StockQuantity = 70
                        },
                        new
                        {
                            ProductId = 18,
                            CategoryId = 2,
                            Description = "A gripping mystery.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Mystery+Book",
                            Name = "Mystery Thriller",
                            Price = 14.99m,
                            StockQuantity = 110
                        },
                        new
                        {
                            ProductId = 19,
                            CategoryId = 2,
                            Description = "Biography of a famous figure.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Biography",
                            Name = "Biography",
                            Price = 20.00m,
                            StockQuantity = 30
                        },
                        new
                        {
                            ProductId = 20,
                            CategoryId = 2,
                            Description = "A collection of modern poetry.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Poetry",
                            Name = "Poetry Collection",
                            Price = 16.50m,
                            StockQuantity = 80
                        },
                        new
                        {
                            ProductId = 21,
                            CategoryId = 3,
                            Description = "A comfortable cotton t-shirt.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=T-Shirt",
                            Name = "T-Shirt",
                            Price = 15.00m,
                            StockQuantity = 200
                        },
                        new
                        {
                            ProductId = 22,
                            CategoryId = 3,
                            Description = "Blue denim jeans.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Jeans",
                            Name = "Jeans",
                            Price = 40.00m,
                            StockQuantity = 150
                        },
                        new
                        {
                            ProductId = 23,
                            CategoryId = 3,
                            Description = "A warm fleece hoodie.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Hoodie",
                            Name = "Hoodie",
                            Price = 35.00m,
                            StockQuantity = 100
                        },
                        new
                        {
                            ProductId = 24,
                            CategoryId = 3,
                            Description = "Running sneakers.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Sneakers",
                            Name = "Sneakers",
                            Price = 75.00m,
                            StockQuantity = 80
                        },
                        new
                        {
                            ProductId = 25,
                            CategoryId = 3,
                            Description = "A warm winter beanie.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Beanie",
                            Name = "Beanie",
                            Price = 12.00m,
                            StockQuantity = 300
                        },
                        new
                        {
                            ProductId = 26,
                            CategoryId = 3,
                            Description = "A formal cotton dress shirt.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Dress+Shirt",
                            Name = "Dress Shirt",
                            Price = 45.00m,
                            StockQuantity = 60
                        },
                        new
                        {
                            ProductId = 27,
                            CategoryId = 3,
                            Description = "A 3-pack of cotton socks.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Socks",
                            Name = "Socks",
                            Price = 10.00m,
                            StockQuantity = 400
                        },
                        new
                        {
                            ProductId = 28,
                            CategoryId = 3,
                            Description = "A waterproof winter jacket.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Jacket",
                            Name = "Winter Jacket",
                            Price = 120.00m,
                            StockQuantity = 40
                        },
                        new
                        {
                            ProductId = 29,
                            CategoryId = 3,
                            Description = "Casual cargo shorts.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Shorts",
                            Name = "Shorts",
                            Price = 28.00m,
                            StockQuantity = 110
                        },
                        new
                        {
                            ProductId = 30,
                            CategoryId = 3,
                            Description = "A genuine leather belt.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Belt",
                            Name = "Leather Belt",
                            Price = 22.00m,
                            StockQuantity = 90
                        },
                        new
                        {
                            ProductId = 31,
                            CategoryId = 4,
                            Description = "1kg of fresh apples.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Apples",
                            Name = "Apples",
                            Price = 3.99m,
                            StockQuantity = 500
                        },
                        new
                        {
                            ProductId = 32,
                            CategoryId = 4,
                            Description = "1 gallon of whole milk.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Milk",
                            Name = "Milk",
                            Price = 4.50m,
                            StockQuantity = 300
                        },
                        new
                        {
                            ProductId = 33,
                            CategoryId = 4,
                            Description = "A loaf of whole wheat bread.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Bread",
                            Name = "Bread",
                            Price = 2.99m,
                            StockQuantity = 400
                        },
                        new
                        {
                            ProductId = 34,
                            CategoryId = 4,
                            Description = "A dozen large eggs.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Eggs",
                            Name = "Eggs",
                            Price = 3.20m,
                            StockQuantity = 600
                        },
                        new
                        {
                            ProductId = 35,
                            CategoryId = 4,
                            Description = "1lb of boneless chicken breast.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Chicken",
                            Name = "Chicken Breast",
                            Price = 5.99m,
                            StockQuantity = 150
                        },
                        new
                        {
                            ProductId = 36,
                            CategoryId = 4,
                            Description = "A box of spaghetti.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Pasta",
                            Name = "Pasta",
                            Price = 1.50m,
                            StockQuantity = 700
                        },
                        new
                        {
                            ProductId = 37,
                            CategoryId = 4,
                            Description = "A bag of whole bean coffee.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Coffee",
                            Name = "Coffee",
                            Price = 12.99m,
                            StockQuantity = 200
                        },
                        new
                        {
                            ProductId = 38,
                            CategoryId = 4,
                            Description = "A bunch of bananas.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Bananas",
                            Name = "Bananas",
                            Price = 1.99m,
                            StockQuantity = 800
                        },
                        new
                        {
                            ProductId = 39,
                            CategoryId = 4,
                            Description = "A box of breakfast cereal.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Cereal",
                            Name = "Cereal",
                            Price = 4.80m,
                            StockQuantity = 250
                        },
                        new
                        {
                            ProductId = 40,
                            CategoryId = 4,
                            Description = "Half-gallon of orange juice.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Orange+Juice",
                            Name = "Orange Juice",
                            Price = 5.50m,
                            StockQuantity = 180
                        },
                        new
                        {
                            ProductId = 41,
                            CategoryId = 5,
                            Description = "Official size basketball.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Basketball",
                            Name = "Basketball",
                            Price = 24.99m,
                            StockQuantity = 100
                        },
                        new
                        {
                            ProductId = 42,
                            CategoryId = 5,
                            Description = "Size 5 soccer ball.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Soccer+Ball",
                            Name = "Soccer Ball",
                            Price = 22.00m,
                            StockQuantity = 120
                        },
                        new
                        {
                            ProductId = 43,
                            CategoryId = 5,
                            Description = "A non-slip yoga mat.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Yoga+Mat",
                            Name = "Yoga Mat",
                            Price = 18.00m,
                            StockQuantity = 200
                        },
                        new
                        {
                            ProductId = 44,
                            CategoryId = 5,
                            Description = "Set of 5lb dumbbells.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Dumbbells",
                            Name = "Dumbbells",
                            Price = 15.00m,
                            StockQuantity = 80
                        },
                        new
                        {
                            ProductId = 45,
                            CategoryId = 5,
                            Description = "A lightweight tennis racket.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Tennis+Racket",
                            Name = "Tennis Racket",
                            Price = 55.00m,
                            StockQuantity = 60
                        },
                        new
                        {
                            ProductId = 46,
                            CategoryId = 5,
                            Description = "A 32oz insulated water bottle.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Water+Bottle",
                            Name = "Water Bottle",
                            Price = 20.00m,
                            StockQuantity = 300
                        },
                        new
                        {
                            ProductId = 47,
                            CategoryId = 5,
                            Description = "Men's running shoes, size 10.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Running+Shoes",
                            Name = "Running Shoes",
                            Price = 85.00m,
                            StockQuantity = 70
                        },
                        new
                        {
                            ProductId = 48,
                            CategoryId = 5,
                            Description = "A CPSC-certified bike helmet.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Helmet",
                            Name = "Bicycle Helmet",
                            Price = 45.00m,
                            StockQuantity = 90
                        },
                        new
                        {
                            ProductId = 49,
                            CategoryId = 5,
                            Description = "A speed jump rope.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Jump+Rope",
                            Name = "Jump Rope",
                            Price = 12.50m,
                            StockQuantity = 150
                        },
                        new
                        {
                            ProductId = 50,
                            CategoryId = 5,
                            Description = "A dozen golf balls.",
                            ImageUrl = "https://placehold.co/600x400/EEE/31343C?text=Golf+Balls",
                            Name = "Golf Balls",
                            Price = 30.00m,
                            StockQuantity = 100
                        });
                });

            modelBuilder.Entity("ECommerceApi.Models.Product", b =>
                {
                    b.HasOne("ECommerceApi.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ECommerceApi.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
