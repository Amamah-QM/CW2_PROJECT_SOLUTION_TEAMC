using System;
using System.Collections.Generic;
using System.Linq;

public class ShoppingBasket
{
    // List to store products in the shopping basket
    private List<(Product)> productList = new List<Product>();

    // Method to add a product to the shopping basket
    public void AddItem(Product product)
    {
        productList.Add(product);
    }

    // Method to remove a product from the shopping basket
    public void RemoveItem(Product product)
    {
        // Remove all instances of the product with the matching ProductID
        productList.Remove(product);
    }

    // Method to update the quantity of a product in the basket
    public void UpdateItemQuantity(Product product, int newQuantity)
    {
        var item = productList.FirstOrDefault(p => p.ProductId == product.ProductId);
        if (item != null)
        {
            item.StockQuantity = newQuantity;
        }
    }

    // Method to calculate the total cost of the items in the basket
    public double CalculateTotal()
    {
        return productList.Sum(p => p.Price * p.StockQuantity);
    }

    // Method to get the count of items in the basket
    public int GetItemCount()
    {
        return productList.Count;
    }

    // Method to clear all items from the basket
    public void ClearCart()
    {
        productList.Clear();
    }

    // Method to simulate the checkout process
    public void Checkout()
    {
        // Here you can add logic for processing the payment and completing the order
        Console.WriteLine("Checkout complete. Total amount: " + CalculateTotal());
        ClearCart();
    }

    // Method to display all items in the basket
    public void DisplayItems()
    {
        foreach (var product in productList)
        {
            Console.WriteLine($"ID: {product.ProductId}, Name: {product.ProductName}, Quantity: {product.StockQuantity}, Price: {product.Price}");
        }
    }
}

// Sample shopping basket
public class Program
{
    public static void Main()
    {
        ShoppingBasket basket = new ShoppingBasket();

        // Adding sample products to the basket
        Product softwareProgramming = new Product(1, "Software Programming", "C# for beginners", 12.99, 25, 4);
        Product Blender = new Product(2, "Blender", "NutriBullet Pro", 89.99, 15, 2);

        basket.AddItem(laptop);
        basket.AddItem(smartphone);

        // Display items in the basket
        basket.DisplayItems();

        // Update quantity of a product
        basket.UpdateItemQuantity(smartphone, 3);

        // Calculate total cost
        Console.WriteLine("Total cost: " + basket.CalculateTotal());

        // Checkout
        basket.Checkout();
    }
}
