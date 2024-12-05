using System;
using System.Collections.Generic;

public class ShoppingControl
{
    // Encapsulated attributes
    private List<Product> productList = new List<Product>();
    private List<User> userList = new List<User>();
    private List<Category> categoryList = new List<Category>();
    private ShoppingBasket shoppingBasket = new ShoppingBasket();

    // Constructor
    public ShoppingControl()
    {
        // Initialize with some sample data for demonstration purposes
        InitializeSampleData();
    }

    // Methods


    // Authenticates a user based on username and password.

    public bool Authenticate(string username, string password)
    {
        try
        {
            foreach (var user in userList)
            {
                if (user.UserName == username && user.Password == password)
                {
                    Console.WriteLine("Authentication successful.");
                    return true;
                }
            }
            Console.WriteLine("Invalid username or password.");
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during authentication: {ex.Message}");
            return false;
        }
    }


    // Displays the main menu and handles user input.

    public void DisplayAdminMenu()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- Main Menu ---");
            Console.WriteLine("1. Manage Users");
            Console.WriteLine("2. Manage Products");
            Console.WriteLine("3. Manage Categories");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ManageUsers();
                    break;
                case "2":
                    ManageProducts();
                    break;
                case "3":
                    ManageCategories();
                    break;
                case "4":
                    running = false;
                    Console.WriteLine("Exiting application. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }


    // Manages user-related operations.

    public void ManageUsers()
    {
        Console.WriteLine("\n--- Manage Users ---");
        Console.WriteLine("1. Add User");
        Console.WriteLine("2. Remove User");
        Console.WriteLine("3. Update User");
        Console.Write("Enter your choice: ");

        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                AddUser();
                break;
            case "2":
                RemoveUser();
                break;
            case "3":
                UpdateUser();
                break;
            default:
                Console.WriteLine("Invalid option. Returning to main menu.");
                break;
        }
    }

    private void AddUser()
    {
        try
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            User newUser = new User { UserName = username, Password = password };
            userList.Add(newUser);
            Console.WriteLine("User added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding user: {ex.Message}");
        }
    }

    private void RemoveUser()
    {
        try
        {
            Console.Write("Enter username to remove: ");
            string username = Console.ReadLine();

            User user = userList.Find(u => u.UserName == username);
            if (user != null)
            {
                userList.Remove(user);
                Console.WriteLine("User removed successfully.");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error removing user: {ex.Message}");
        }
    }

    private void UpdateUser()
    {
        try
        {
            Console.Write("Enter username to update: ");
            string username = Console.ReadLine();

            User user = userList.Find(u => u.UserName == username);
            if (user != null)
            {
                Console.Write("Enter new password: ");
                user.Password = Console.ReadLine();
                Console.WriteLine("User updated successfully.");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating user: {ex.Message}");
        }
    }


    // Manages product-related operations.

    public void ManageProducts()
    {
        Console.WriteLine("\n--- Manage Products ---");
        Console.WriteLine("1. Add Product");
        Console.WriteLine("2. Remove Product");
        Console.WriteLine("3. Update Product");
        Console.Write("Enter your choice: ");

        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                AddProduct();
                break;
            case "2":
                RemoveProduct();
                break;
            case "3":
                UpdateProduct();
                break;
            default:
                Console.WriteLine("Invalid option. Returning to main menu.");
                break;
        }
    }

    private void AddProduct()
    {
        try
        {
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();
            Console.Write("Enter product description: ");
            string description = Console.ReadLine();
            Console.Write("Enter price: ");
            double price = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter stock quantity: ");
            int stock = Convert.ToInt32(Console.ReadLine());

            Product product = new Product
            {
                ProductName = name,
                ProductDescription = description,
                Price = price,
                StockQuantity = stock
            };
            productList.Add(product);
            Console.WriteLine("Product added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding product: {ex.Message}");
        }
    }

    private void RemoveProduct()
    {
        try
        {
            Console.Write("Enter product name to remove: ");
            string name = Console.ReadLine();

            Product product = productList.Find(p => p.ProductName == name);
            if (product != null)
            {
                productList.Remove(product);
                Console.WriteLine("Product removed successfully.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error removing product: {ex.Message}");
        }
    }

    private void UpdateProduct()
    {
        try
        {
            Console.Write("Enter product name to update: ");
            string name = Console.ReadLine();

            Product product = productList.Find(p => p.ProductName == name);
            if (product != null)
            {
                Console.Write("Enter new price: ");
                product.Price = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter new stock quantity: ");
                product.StockQuantity = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Product updated successfully.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating product: {ex.Message}");
        }
    }


    // Manages category-related operations.

    public void ManageCategories()
    {
        Console.WriteLine("\n--- Manage Categories ---");
        Console.WriteLine("1. Add Category");
        Console.WriteLine("2. Update Category");
        Console.Write("Enter your choice: ");

        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                AddCategory();
                break;
            case "2":
                UpdateCategory();
                break;
            default:
                Console.WriteLine("Invalid option. Returning to main menu.");
                break;
        }
    }

    private void AddCategory()
    {
        try
        {
            Console.Write("Enter category name: ");
            string name = Console.ReadLine();
            Console.Write("Enter category description: ");
            string description = Console.ReadLine();

            Category category = new Category
            {
                CategoryId = categoryList.Count + 1,
                CategoryName = name,
                CategoryDescription = description
            };
            categoryList.Add(category);
            Console.WriteLine("Category added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding category: {ex.Message}");
        }
    }

    private void UpdateCategory()
    {
        try
        {
            Console.Write("Enter category name to update: ");
            string name = Console.ReadLine();

            Category category = categoryList.Find(c => c.CategoryName == name);
            if (category != null)
            {
                Console.Write("Enter new category name: ");
string newName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newName)) category.CategoryName = newName;

                Console.Write("Enter new category description: ");
                string newDescription = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newDescription)) category.CategoryDescription = newDescription;

                Console.WriteLine("Category updated successfully.");
            }
            else
            {
                Console.WriteLine("Category not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating category: {ex.Message}");
        }
    }

    // Sample data initializer
    private void InitializeSampleData()
    {
        // Sample users
        userList.Add(new User { UserId= 1, UserName = "admin" });
        userList.Add(new User { UserId= 2, UserName = "admin59" });
        userList.Add(new User { UserId= 3, UserName = "john_doe" });
        userList.Add(new User { UserId= 4, UserName = "jane_smith" });
        userList.Add(new User { UserId= 5, UserName = "alice_brown" });

        // Sample categories
        categoryList.Add(new Category { CategoryID = 1, CategoryName = "Electronics", CategoryDescription = "Devices and gadgets" });
        categoryList.Add(new Category { CategoryID = 2, CategoryName = "Household", CategoryDescription = "Household items and appliances" });
        categoryList.Add(new Category { CategoryID = 3, CategoryName = "Clothing", CategoryDescription = "Clothing for men, women, and children" });
        categoryList.Add(new Category { CategoryID = 4, CategoryName = "Books", CategoryDescription = "Fiction, non-fiction, educational, and more" });
        categoryList.Add(new Category { CategoryID = 5, CategoryName = "Toys & Games", CategoryDescription = "Toys for kids, board games, and puzzles" });

        // Sample products
        productList.Add(new Product { ProductID = 1, ProductName = "LED TV", ProductDescription = "65 inch Samsung LED TV", Price = 459.99, StockQuantity = 5, CategoryID = 1 });
        productList.Add(new Product { ProductID = 2, ProductName = "Vacuum Cleaner", ProductDescription = "Dyson V11 Vacuum Cleaner", Price = 599.99, StockQuantity = 10, CategoryID = 2 });
        productList.Add(new Product { ProductID = 3, ProductName = "Running Shoes", ProductDescription = "Nike Air Zoom Pegasus", Price = 120.00, StockQuantity = 20, CategoryID = 3 });
        productList.Add(new Product { ProductID = 4, ProductName = "Software Programming", ProductDescription = "C# for beginners", Price = 12.99, StockQuantity = 25, CategoryID = 4 });
        productList.Add(new Product { ProductID = 5, ProductName = "Blender", ProductDescription = "NutriBullet Pro", Price = 89.99, StockQuantity = 15, CategoryID = 2 });
        productList.Add(new Product { ProductID = 6, ProductName = "Smartphone", ProductDescription = "iPhone13", Price = 999.99, StockQuantity = 8, CategoryID = 5 });
