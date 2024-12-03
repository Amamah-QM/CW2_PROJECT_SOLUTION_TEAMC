using System;
using System.Collections.Generic;

public class Category
{
    // Basic category information for product organization
    private int CategoryId { get; set; }
    private string CategoryName { get; set; }
    private string CategoryDescription { get; set; }
   
    // Creates a new category with required information
    public Category(int categoryId, string categoryName, string categoryDescription)
    {
        CategoryId = categoryId;
        CategoryName = categoryName;
        CategoryDescription = categoryDescription;
    }

    // Displays formatted category information to console
    public void DisplayCategoryInfo()
    {
        Console.WriteLine($"\n--- Category Info ---");
        Console.WriteLine($"ID: {CategoryId}");
        Console.WriteLine($"Name: {CategoryName}");
        Console.WriteLine($"Description: {CategoryDescription}");
    }
}

