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

    /// <summary>
    /// Displays the main menu for all users.
    /// </summary>
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
                Console.WriteLine("Thank you for visiting OnlineShop. Goodbye!");
                break;
            default:
                Console.WriteLine("Invalid option. Returning to main menu.");
                break;
        }
    }

    /// <summary>
    /// Handles admin login and displays the admin menu.
    /// </summary>
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

    /// <summary>
    /// Displays the admin menu for managing the shop.
    /// </summary>
    private void AdminMenu(Admin admin)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- Admin Menu ---");
            Console.WriteLine("1. Manage Products");
            Console.WriteLine("2. Manage Categories");
            Console.WriteLine("3. Manage Users");
            Console.WriteLine("4. Logout");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ManageProducts();
                    break;
                case "2":
                    ManageCategories();
                    break;
                case "3":
                    ManageUsers();
                    break;
                case "4":
                    Console.WriteLine("Logging out...");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    /// <summary>
    /// Handles customer login and displays the customer menu.
    /// </summary>
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

    /// <summary>
    /// Displays the customer menu for shopping.
    /// </summary>
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
            Console.WriteLine("5. Logout");
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
                case "5":
                    Console.WriteLine("Logging out...");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    /// <summary>
    /// Displays all available products.
    /// </summary>
    private void DisplayProducts()
    {
        Console.WriteLine("\n--- Product List ---");
        foreach (var product in productList)
        {
            Console.WriteLine($"- {product.ProductName}: {product.Price:C} ({product.StockQuantity} in stock)");
        }
    }

    /// <summary>
    /// Adds a product to the customer's shopping basket.
    /// </summary>
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

    /// <summary>
    /// Displays the customer's shopping basket.
    /// </summary>
    private void DisplayBasket(Customer customer)
    {
        Console.WriteLine("\n--- Your Shopping Basket ---");
        customer.ShoppingBasket.DisplayContents();
    }

    /// <summary>
    /// Handles checkout for the customer.
    /// </summary>
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

    /// <summary>
    /// Manages products (add, update, remove).
    /// </summary>
    private void ManageProducts()
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
                Console.WriteLine("Invalid option. Returning to admin menu.");
                break;
        }
    }

    private void AddProduct()
    {
        try
        {
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();
            Console.Write("Enter price: ");
            double price = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter stock quantity: ");
            int stock = Convert.ToInt32(Console.ReadLine());

            Product newProduct = new Product
            {
                ProductName = name,
                Price = price,
                StockQuantity = stock
            };
            productList.Add(newProduct);
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
    /// Manages categories (add, update, remove).
    /// </summary>
    private void ManageCategories()
    {
        Console.WriteLine("\n--- Manage Categories ---");
        Console.WriteLine("1. Add Category");
        Console.WriteLine("2. Remove Category");
        Console.WriteLine("3. Update Category");
        Console.Write("Enter your choice: ");

        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                AddCategory();
                break;
            case "2":
                RemoveCategory();
                break;
            case "3":
                UpdateCategory();
                break;
            default:
                Console.WriteLine("Invalid option. Returning to admin menu.");
                break;
        }
    }

    private void AddCategory()
    {
        try
        {
            Console.Write("Enter category name: ");
            string categoryName = Console.ReadLine();

            Category newCategory = new Category
            {
                CategoryName = categoryName
            };
            categoriesList.Add(newCategory);
            Console.WriteLine("Category added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding category: {ex.Message}");
        }
    }

    private void RemoveCategory()
    {
        try
        {
            Console.Write("Enter category name to remove: ");
            string categoryName = Console.ReadLine();

            Category category = categoriesList.Find(c => c.CategoryName == categoryName);
            if (category != null)
            {
                categoriesList.Remove(category);
                Console.WriteLine("Category removed successfully.");
            }
            else
            {
                Console.WriteLine("Category not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error removing category: {ex.Message}");
        }
    }

    private void UpdateCategory()
    {
        try
        {
            Console.Write("Enter category name to update: ");
            string categoryName = Console.ReadLine();

            Category category = categoriesList.Find(c => c.CategoryName == categoryName);
            if (category != null)
            {
                Console.Write("Enter new category name: ");
                category.CategoryName = Console.ReadLine();

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

    /// <summary>
    /// Manages users (add, update, remove).
    /// </summary>
    private void ManageUsers()
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
                Console.WriteLine("Invalid option. Returning to admin menu.");
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

            Customer newUser = new Customer { UserName = username, Password = password };
            customerList.Add(newUser);
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

            Customer user = customerList.Find(c => c.UserName == username);
            if (user != null)
            {
                customerList.Remove(user);
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

            Customer user = customerList.Find(c => c.UserName == username);
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

    // Sample data initializer
    private void InitializeSampleData()
    {
        // Initialize admins, customers, products, and categories for demonstration.
        adminList.Add(new Admin { UserName = "admin", Password = "admin123" });
        customerList.Add(new Customer { UserName = "customer", Password = "password" });
        productList.Add(new Product { ProductName = "Laptop", Price = 1000, StockQuantity = 10 });
        categoriesList.Add(new Category { CategoryName = "Electronics" });
    }
}
