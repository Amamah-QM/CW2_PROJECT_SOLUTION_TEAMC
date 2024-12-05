using System;
using System.Collections.Generic;

namespace ShoppingControl
{
    public class Admin : User
    {
        private DateTime lastLogin;
        
        public DateTime LastLogin 
        { 
            get { return lastLogin; } 
            set { lastLogin = value; }
         }

        // References to shared system lists from OnlineShop
        private List<Product> productList;
        private List<User> userList;
        private List<Category> categoryList;
        private List<Payment> paymentList;

        // Constructor to initialize shared lists from the OnlineShop class
        public Admin(List<Product> productList, List<User> userList, List<Category> categoryList, List<Payment> paymentList)
        {
            this.productList = productList;
            this.userList = userList;
            this.categoryList = categoryList;
            this.paymentList = paymentList;
        }

        // Method to create sample admin users
        public void CreateSampleAdmins()
        {
            try
            {
                Console.WriteLine("Sample admins...");

                userList.Add(new Admin(productList, userList, categoryList, paymentList)
                {
                    UserId = 1,
                    UserName = "admin",
                    Password = "admin123",
                    UserEmail = "admin1@example.com",
                    LastLogin = DateTime.Now
                });

                userList.Add(new Admin(productList, userList, categoryList, paymentList)
                {
                    UserId = 2,
                    UserName = "admin59",
                    Password = "admin456",
                    UserEmail = "admin2@example.com",
                    LastLogin = DateTime.Now
                });

                Console.WriteLine("Sample admins displayed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating admins: {ex.Message}");
            }
        }

        // Method to add a new product
        public void AddProduct()
        {
            try
            {
                Console.WriteLine("\n--- Add Product ---");
                Console.Write("Enter product ID: ");
                string productName = Console.ReadLine();
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
                if (categoryList.Exists(c => c.CategoryId == categoryId))
                {
                    Product newProduct = new Product
                    {
                        ProductId = productList.Count + 1,
                        ProductName = productName,
                        ProductDescription = productDescription,
                        Price = price,
                        StockQuantity = stockQuantity,
                        CategoryId = categoryId
                    };

                    productList.Add(newProduct);
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

                Product product = productList.Find(p => p.ProductId == productId);

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

                Product product = productList.Find(p => p.ProductId == productId);
                if (product != null)
                {
                    productList.Remove(product);
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
                            UserId = userList.Count + 1,
                            UserName = userName,
                            UserEmail = userEmail,
                            Password = password,
                            Role = "Standard",
                            Status = "Active"
                        };

                        userList.Add(newUser);
                        Console.WriteLine($"User '{userName}' added successfully.");
                        break;

                    case 2:
                        Console.WriteLine("\n--- Remove User ---");
                        Console.Write("Enter user ID to remove: ");
                        int userId = int.Parse(Console.ReadLine());

                        User user = userList.Find(u => u.UserId == userId);
                        if (user != null)
                        {
                            userList.Remove(user);
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

                        User updateUser = userList.Find(u => u.UserId == updateUserId);
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

                    case 4:
                        Console.WriteLine("\n--- Update Customer Status ---");
                        Console.Write("Enter User ID to update status: ");
                        int customerId = int.Parse(Console.ReadLine());

                        Customer customer = userList.Find(u => u.UserId == customerId) as Customer;
                        if (customer != null)
                        {
                            Console.Write("Enter new status: ");
                            string status = Console.ReadLine();

                            if (status != null)
                            {
                                // Admin updates the status of the customer
                                customer.SetStatus(status);
                                Console.WriteLine($"Customer '{customer.UserName}' status updated to {status}.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid status.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Customer not found or invalid customer ID.");
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

        // Method to calculate total value
        public void CalculateTotalValue()
        {
            try
            {
                double totalValue = 0;

                foreach (Payment payment in paymentList)
                {
                    totalValue += payment.PaymentAmount;
                }

                Console.WriteLine($"Total value: ${totalValue:F2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calculating value: {ex.Message}");
            }
        }

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

        // Method to update the admin profile (override)
        public override void UpdateProfile()
        {
            try
            {
                Console.WriteLine("\n--- Update Admin Profile ---");
                Console.Write("Enter new username (leave blank to keep current): ");
                string newUserName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newUserName))
                {
                    UserName = newUserName;
                }

                Console.Write("Enter new email (leave blank to keep current): ");
                string newEmail = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newEmail))
                {
                    UserEmail = newEmail;
                }

                Console.Write("Enter new password (leave blank to keep current): ");
                string newPassword = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newPassword))
                {
                    Password = newPassword;
                }

                Console.WriteLine("Profile updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating profile: {ex.Message}");
            }
        }

        // Method to log out the admin (override)
        public override void Logout()
        {
            try
            {
                LastLogin = DateTime.MinValue;
                Console.WriteLine("Admin logged out successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging out: {ex.Message}");
            }
        }
    }
}
