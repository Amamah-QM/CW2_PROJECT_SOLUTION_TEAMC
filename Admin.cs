using System;
using System.Collections.Generic;

public class Admin : User
{
    // Additional attribute
    public DateTime LastLogin { get; set; }

    // References to shared system lists from OnlineShop
    private List<Product> ProductList;
    private List<User> UserList;
    private List<Category> CategoryList;
    private List<Payment> PaymentList;

    // Constructor to initialize shared lists from the OnlineShop class
    public Admin(List<Product> productList, List<User> userList, List<Category> categoryList, List<Payment> paymentList)
    {
        ProductList = productList;
        UserList = userList;
        CategoryList = categoryList;
        PaymentList = paymentList;
    }

    // Method to create sample admin users
    public void CreateSampleAdmins()
    {
        Console.WriteLine("Creating sample admins...");

        UserList.Add(new Admin(ProductList, UserList, CategoryList, PaymentList)
        {
            UserId = 1,
            UserName = "Admin1",
            Password = "admin123",
            UserEmail = "admin1@example.com",
            LastLogin = DateTime.Now
        });

        UserList.Add(new Admin(ProductList, UserList, CategoryList, PaymentList)
        {
            UserId = 2,
            UserName = "Admin2",
            Password = "admin456",
            UserEmail = "admin2@example.com",
            LastLogin = DateTime.Now
        });

        Console.WriteLine("Sample admins created successfully.");
    }

    // Method to add a new product
    public void AddProduct()
    {
        try
        {
            Console.WriteLine("\n--- Add Product ---");
            Console.Write("Enter product name: ");
            string productName = Console.ReadLine();

            Console.Write("Enter product description: ");
            string productDescription = Console.ReadLine();

            Console.Write("Enter product price: ");
            double price = double.Parse(Console.ReadLine());

            Console.Write("Enter stock quantity: ");
            int stockQuantity = int.Parse(Console.ReadLine());

            Console.Write("Enter category ID: ");
            int categoryId = int.Parse(Console.ReadLine());

            // Ensure the category exists
            if (CategoryList.Exists(c => c.CategoryId == categoryId))
            {
                Product newProduct = new Product
                {
                    ProductId = ProductList.Count + 1,
                    ProductName = productName,
                    ProductDescription = productDescription,
                    Price = price,
                    StockQuantity = stockQuantity,
                    CategoryId = categoryId
                };

                ProductList.Add(newProduct);
                Console.WriteLine($"Product '{productName}' added successfully.");
            }
            else
            {
                Console.WriteLine("Category ID not found. Product not added.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding product: {ex.Message}");
        }
    }

    // Method to update an existing product
    public void UpdateProduct()
    {
        try
        {
            Console.WriteLine("\n--- Update Product ---");
            Console.Write("Enter product ID to update: ");
            int productId = int.Parse(Console.ReadLine());

            Product product = ProductList.Find(p => p.ProductId == productId);

            if (product != null)
            {
                Console.Write("Enter new product name (leave blank to keep current): ");
                string newName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newName))
                {
                    product.ProductName = newName;
                }

                Console.Write("Enter new product description (leave blank to keep current): ");
                string newDescription = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newDescription))
                {
                    product.ProductDescription = newDescription;
                }

                Console.Write("Enter new product price (leave blank to keep current): ");
                string newPriceInput = Console.ReadLine();
                if (double.TryParse(newPriceInput, out double newPrice))
                {
                    product.Price = newPrice;
                }

                Console.Write("Enter new stock quantity (leave blank to keep current): ");
                string newQuantityInput = Console.ReadLine();
                if (int.TryParse(newQuantityInput, out int newQuantity))
                {
                    product.StockQuantity = newQuantity;
                }

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

    // Method to remove a product
    public void RemoveProduct()
    {
        try
        {
            Console.WriteLine("\n--- Remove Product ---");
            Console.Write("Enter product ID to remove: ");
            int productId = int.Parse(Console.ReadLine());

            Product product = ProductList.Find(p => p.ProductId == productId);
            if (product != null)
            {
                ProductList.Remove(product);
                Console.WriteLine($"Product '{product.ProductName}' removed successfully.");
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

    // Method to manage users (add/remove/update)
    public void ManageUsers()
    {
        try
        {
            Console.WriteLine("\n--- Manage Users ---");
            Console.WriteLine("1. Add User");
            Console.WriteLine("2. Remove User");
            Console.WriteLine("3. Update User");
            Console.Write("Select an option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\n--- Add User ---");
                    Console.Write("Enter user name: ");
                    string userName = Console.ReadLine();

                    Console.Write("Enter user email: ");
                    string userEmail = Console.ReadLine();

                    Console.Write("Enter user password: ");
                    string password = Console.ReadLine();

                    User newUser = new Customer() // Default to Customer; can be adjusted
                    {
                        UserId = UserList.Count + 1,
                        UserName = userName,
                        UserEmail = userEmail,
                        Password = password,
                        Role = "Standard",
                        Status = "Active"
                    };

                    UserList.Add(newUser);
                    Console.WriteLine($"User '{userName}' added successfully.");
                    break;

                case 2:
                    Console.WriteLine("\n--- Remove User ---");
                    Console.Write("Enter user ID to remove: ");
                    int userId = int.Parse(Console.ReadLine());

                    User user = UserList.Find(u => u.UserId == userId);
                    if (user != null)
                    {
                        UserList.Remove(user);
                        Console.WriteLine($"User '{user.UserName}' removed successfully.");
                    }
                    else
                    {
                        Console.WriteLine("User not found.");
                    }
                    break;

                case 3:
                    Console.WriteLine("\n--- Update User ---");
                    Console.Write("Enter user ID to update: ");
                    int updateUserId = int.Parse(Console.ReadLine());

                    User updateUser = UserList.Find(u => u.UserId == updateUserId);
                    if (updateUser != null)
                    {
                        Console.Write("Enter new email (leave blank to keep current): ");
                        string newEmail = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newEmail))
                        {
                            updateUser.UserEmail = newEmail;
                        }

                        Console.Write("Enter new phone number (leave blank to keep current): ");
                        string newPhone = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newPhone))
                        {
                            updateUser.PhoneNumber = newPhone;
                        }

                        Console.WriteLine("User updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("User not found.");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error managing users: {ex.Message}");
        }
    }

    // Method to calculate total revenue
    public void CalculateTotalRevenue()
    {
        try
        {
            double totalRevenue = 0;

            foreach (Payment payment in PaymentList)
            {
                totalRevenue += payment.PaymentAmount;
            }

            Console.WriteLine($"Total revenue: ${totalRevenue:F2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error calculating revenue: {ex.Message}");
        }
    }

    // Method to add a new category
    public void AddCategory()
    {
        try
        {
            Console.WriteLine("\n--- Add Category ---");
            Console.Write("Enter category name: ");
            string categoryName = Console.ReadLine();

            Console.Write("Enter category description: ");
            string categoryDescription = Console.ReadLine();

            Category newCategory = new Category
            {
                CategoryId = CategoryList.Count + 1,
                CategoryName = categoryName,
                CategoryDescription = categoryDescription
            };

            CategoryList.Add(newCategory);
            Console.WriteLine($"Category '{categoryName}' added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding category: {ex.Message}");
        }
    }

    // Method to update an existing category
    public void UpdateCategory()
    {
        try
        {
            Console.WriteLine("\n--- Update Category ---");
            Console.Write("Enter category ID to update: ");
            int categoryId = int.Parse(Console.ReadLine());

            Category category = CategoryList.Find(c => c.CategoryId == categoryId);

            if (category != null)
            {
                Console.Write("Enter new category name (leave blank to keep current): ");
                string newName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newName))
                {
                    category.CategoryName = newName;
                }

                Console.Write("Enter new category description (leave blank to keep current): ");
                string newDescription = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newDescription))
                {
                    category.CategoryDescription = newDescription;
                }

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
}
