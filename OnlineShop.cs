using System;
using System.Collections.Generic;

public class OnlineShop
{
    // Encapsulated attributes
    private List<Admin> adminList = new List<Admin>();
    private List<Customer> customerList = new List<Customer>();
    private List<Product> productList = new List<Product>();
    private List<Category> categoriesList = new List<Category>();

    // Constructor
    public OnlineShop()
    {
        // Initialize with sample data for demonstration
        InitializeSampleData();
    }

    // Methods


    // Displays the main menu for all users.

    public void ShowMainMenu()
    {
        Console.WriteLine("\n--- Welcome to OnlineShop ---");
        Console.WriteLine("1. Login as Admin");
        Console.WriteLine("2. Login as Customer");
        Console.WriteLine("3. Exit");
        Console.Write("Enter your choice: ");

        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                AdminLogin();
                break;
            case "2":
                CustomerLogin();
                break;
            case "3":
                Console.WriteLine("Exiting application. Goodbye!");
                break;
            default:
                Console.WriteLine("Invalid option. Returning to main menu.");
                break;
        }
    }


    // Handles admin login and displays the admin menu.

    public void AdminLogin()
    {
        try
        {
            Console.Write("Enter admin username: ");
            string username = Console.ReadLine();
            Console.Write("Enter admin password: ");
            string password = Console.ReadLine();

            Admin admin = adminList.Find(a => a.UserName == username && a.Password == password);
            if (admin != null)
            {
                Console.WriteLine($"Welcome, {admin.UserName}!");
                AdminMenu(admin);
            }
            else
            {
                Console.WriteLine("Invalid credentials. Returning to main menu.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during admin login: {ex.Message}");
        }
    }


    // Displays the admin menu for managing the shop.

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


    // Handles customer login and displays the customer menu.

    public void CustomerLogin()
    {
        try
        {
            Console.Write("Enter customer username: ");
            string username = Console.ReadLine();
            Console.Write("Enter customer password: ");
            string password = Console.ReadLine();

            Customer customer = customerList.Find(c => c.UserName == username && c.Password == password);
            if (customer != null)
            {
                Console.WriteLine($"Welcome, {customer.UserName}!");
                CustomerMenu(customer);
            }
            else
            {
                Console.WriteLine("Invalid credentials. Returning to main menu.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during customer login: {ex.Message}");
        }
    }


    // Displays the customer menu for shopping.

    private void CustomerMenu(Customer customer)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- Customer Menu ---");
            Console.WriteLine("1. View Products");
            Console.WriteLine("2. Add Product to Basket");
            Console.WriteLine("3. View Shopping Basket");
            Console.WriteLine("4. Checkout");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    DisplayProducts();
                    break;
                case "2":
                    AddProductToBasket(customer);
                    break;
                case "3":
                    DisplayBasket(customer);
                    break;
                case "4":
                    Checkout(customer);
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }


    // Displays all available products.

    private void DisplayProducts()
    {
        Console.WriteLine("\n--- Product List ---");
        foreach (var product in productList)
        {
            Console.WriteLine($"- {product.ProductName}: {product.Price:C} ({product.StockQuantity} in stock)");
        }
    }


    // Adds a product to the customer's shopping basket.

    private void AddProductToBasket(Customer customer)
    {
        try
        {
            Console.Write("Enter product name to add to basket: ");
            string productName = Console.ReadLine();

            Product product = productList.Find(p => p.ProductName == productName);
            if (product != null && product.StockQuantity > 0)
            {
                customer.ShoppingBasket.AddItem(product);
                product.StockQuantity--;
                Console.WriteLine($"{product.ProductName} added to your basket.");
            }
            else
            {
                Console.WriteLine("Product not found or out of stock.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding product to basket: {ex.Message}");
        }
    }


    // Displays the customer's shopping basket.

    private void DisplayBasket(Customer customer)
    {
        Console.WriteLine("\n--- Your Shopping Basket ---");
        customer.ShoppingBasket.DisplayContents();
    }


    // Handles checkout for the customer.

    private void Checkout(Customer customer)
    {
        try
        {
            Console.WriteLine("Processing your order...");
            double total = customer.ShoppingBasket.CalculateTotal();
            if (total > 0)
            {
                Console.WriteLine($"Order placed successfully! Total amount: {total:C}");
                customer.ShoppingBasket.ClearCart();
            }
            else
            {
                Console.WriteLine("Your basket is empty.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during checkout: {ex.Message}");
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
