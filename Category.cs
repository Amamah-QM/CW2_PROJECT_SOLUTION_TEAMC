using System;
using System.Collections.Generic;

public class Category
{
    // Basic category information for product organization
    private int categoryId;
    private string categoryName;
    private string categoryDescription;

    public int CategoryID
    {
        get { return categoryId; } 
        set { categoryId = value; } 
    }

    public string CategoryName
    {
        get { return categoryName; } 
        set { categoryName = value; } 
    }

    public string CategoryDescription
    {
        get { return categoryDescription; } 
        set { categoryDescription = value; } 
    }
   
    // Creates a new category with required information
    public Category(int categoryId, string categoryName, string categoryDescription)
    {
        CategoryID = categoryId;
        CategoryName = categoryName;
        CategoryDescription = categoryDescription;
    }

    // Displays formatted category information to console
    public void DisplayCategoryInfo()
    {
        Console.WriteLine($"\n--- Category Info ---");
        Console.WriteLine($"ID: {CategoryID}");
        Console.WriteLine($"Name: {CategoryName}");
        Console.WriteLine($"Description: {CategoryDescription}");
    }
}

