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

    /// <summary>
    /// Authenticates a user based on username and password.
    /// </summary>
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

    /// <summary>
    /// Displays the main menu and handles user input.
    /// </summary>
    public void DisplayMainMenu()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- Main Menu ---");
            Console.WriteLine("1. Manage Users");
            Console.WriteLine("2. Manage Products");
            Console.WriteLine("3. Manage Categories");
            Console.WriteLine("4. View Shopping Basket");
            Console.WriteLine("5. Exit");
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
                    DisplayBasket();
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Exiting application. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    /// <summary>
    /// Manages user-related operations.
    /// </summary>
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

    /// <summary>
    /// Manages product-related operations.
    /// </summary>
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

    /// <summary>
    /// Manages category-related operations.
    /// </summary>
    public void ManageCategories()
    {
        // Similar to users/products, implement logic for adding, updating, or removing categories.
        Console.WriteLine("\n--- Manage Categories ---");
    }

    /// <summary>
    /// Displays the shopping basket and its contents.
    /// </summary>
    public void DisplayBasket()
    {
        try
        {
            Console.WriteLine("\n--- Shopping Basket ---");
            shoppingBasket.DisplayContents();
            Console.WriteLine($"Total: ${shoppingBasket.CalculateTotal()}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error displaying basket: {ex.Message}");
        }
    }

    // Sample data initializer
    private void InitializeSampleData()
    {
        // Initialize users, products, and categories for demonstration.
    }
}
