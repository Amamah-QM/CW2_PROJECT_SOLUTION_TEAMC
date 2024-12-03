using System;
using System.Collections.Generic;

public class Product
{
  // properties to store relevant information
  private int ProductID { get; set; }
  private string ProductName { get; set; }
  private string ProductDescription { get; set; }
  private double Price { get; set; }
  private int StockQuantity { get; set; }
  private int CategoryID { get; set; }

  // Constructor to initialize a new product with the given details
  public int Product ( int productId, string productName, string productDescription, double price, int stockQuantity, int categoryId)
  {
    ProductID = productId;
    ProductName = productName;
    ProductDescription = productDescription;
    Price = price;
    StockQuantity = stockQuantity;
    CategoryID = categoryId;
  }
}

public class Program
{
    public static void Main()
    {
        // Create a list of Product objects and initialize it with sample data
        List<Product> products = new List<Product>
        {
            new Product(1, "LED TV", "65 inch Samsung LED TV", 459.99, 5, 1),
            new Product(2, "Vacuum Cleaner", "Dyson V11 Vacuum Cleaner", 599.99, 10, 2),
            new Product(3, "Running Shoes", "Nike Air Zoom Pegasus", 120.00, 20, 3),
            new Product(4, "Software programming", "C# for beginners ", 12.99, 25, 4),
            new Product(5, "Blender", "NutriBullet Pro", 89.99, 15, 2)
            new Product(6, "Smartphone", "iPhone 13", 999.99, 8, 5)
        };

        // Iterate over each product in the list and print its details
        foreach (var product in products)
        {
            Console.WriteLine($"ID: {product.ProductId}, Name: {product.ProductName}, Description: {product.ProductDescription}, Price: {product.Price}, Stock: {product.StockQuantity}, Category: {product.CategoryId}");
        }
    }
}
