using System;
using System.Collections.Generic;

namespace ShoppingControl
{
    public class Customer : User
    {
        private string role;
        private string status;
        
        public string Role {
            get { return role; } 
            set { role = value; }
        }

        private ShoppingBasket shoppingBasket;

        public ShoppingBasket ShoppingBasket
        {
            get { return shoppingBasket; }
            private set { shoppingBasket = value; }
        }

        public Customer()
        {
            Role = "Customer";
            Status = "Active";
            ShoppingBasket = new ShoppingBasket();
        }

        public static List<Customer> CreateSampleCustomers()
        {
            List<Customer> sampleCustomers = new List<Customer>
            {
                new Customer
                {
                    UserName = "john_doe",
                    Password = "password123",
                    Role = "Customer",
                    Status = "Active"
                },
                new Customer
                {
                    UserName = "jane_smith",
                    Password = "securepass",
                    Role = "Customer",
                    Status = "Inactive"
                },
                new Customer
                {
                    UserName = "alice_brown",
                    Password = "alice2023",
                    Role = "Customer",
                    Status = "Active"
                }
            };

            return sampleCustomers;
        }

        public void SetStatus(string newStatus)
        {
            if (newStatus == "Active" || newStatus == "Inactive")
            {
                status = newStatus;
            }
            else
            {
                throw new ArgumentException("Invalid status. Must be either 'Active' or 'Inactive'.");
            }
        }

        public override void UpdateProfile()
        {
            Console.WriteLine("Updating profile for customer...");
        
            Console.Write("Enter new username: ");
            string newUsername = Console.ReadLine();
            Console.Write("Enter new password: ");
            string newPassword = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(newUsername))
                UserName = newUsername;

            if (!string.IsNullOrWhiteSpace(newPassword))
                Password = newPassword;

            Console.WriteLine("Profile updated successfully!");
        }

        public override void Logout()
        {
            Console.WriteLine("Customer logged out.");
        }
        
        public void DisplayCustomerMenu()
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
                        ViewProducts();
                        break;
                    case "2":
                        AddProductToBasket();
                        break;
                    case "3":
                        ViewShoppingBasket();
                        break;
                    case "4":
                        Checkout();
                        break;
                    case "5":
                        Console.WriteLine("Logging out...");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private void ViewProducts()
        {
            Console.WriteLine("\n--- Available Products ---");
            foreach (var product in OnlineShop.GetProductList())
            {
                Console.WriteLine($"- {product.ProductName}: {product.Price:C} ({product.StockQuantity} in stock)");
            }
        }

        private void AddProductToBasket()
        {
            Console.Write("Enter the product name to add to the basket: ");
            string productName = Console.ReadLine();

            Product product = OnlineShop.GetProductList().Find(p => p.ProductName == productName);
            if (product != null && product.StockQuantity > 0)
            {
                ShoppingBasket.AddItem(product);
                product.StockQuantity--;
                Console.WriteLine($"{product.ProductName} added to your basket.");
            }
            else
            {
                Console.WriteLine("Product not found or out of stock.");
            }
        }

        private void ViewShoppingBasket()
        {
            Console.WriteLine("\n--- Your Shopping Basket ---");
            ShoppingBasket.DisplayContents();
        }

        private void Checkout()
        {
            Console.WriteLine("\n--- Checkout ---");
            double total = ShoppingBasket.CalculateTotal();

            if (total > 0)
            {
                Console.WriteLine($"Your total is: {total:C}. Proceeding to checkout...");
                ShoppingBasket.ClearCart();
                Console.WriteLine("Thank you for your purchase!");
            }
            else
            {
                Console.WriteLine("Your shopping basket is empty. Add items before checking out.");
            }
        }
    }
}
