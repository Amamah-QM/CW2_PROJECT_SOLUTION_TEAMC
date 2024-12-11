using System;
using System.Collections.Generic;
using System.IO;

namespace CW2_PROJECT_SOLUTION_TEAMC
{
    class Program
    {
        static void Main(string[] args)
        {
            // CSV file paths
            string adminFilePath = "Admin.csv"; 
            string customerFilePath = "Customer.csv"; 
            string categoryFilePath = "Category.csv"; 
            string productFilePath = "Product.csv";

            // Read CSV files
            List<Dictionary<string, string>> adminDataList = ReadCsvFile(adminFilePath);
            List<Dictionary<string, string>> customerDataList = ReadCsvFile(customerFilePath);
            List<Dictionary<string, string>> categoryDataList = ReadCsvFile(categoryFilePath);
            List<Dictionary<string, string>> productDataList = ReadCsvFile(productFilePath);

            // Create lists for Admin, Customer, Category, and Product objects
            List<User> users = new List<User>();
            List<Category> categories = new List<Category>();
            List<Product> products = new List<Product>();

           // Create Admins
            foreach (var row in adminDataList)
            {
                int userId = int.Parse(row["UserId"]);
                string userName = row["UserName"];
                string password = row["Password"];
                string userEmail = row["UserEmail"];
                DateTime lastLogin = DateTime.Parse(row["LastLogin"]);

                Admin admin = new Admin(userId, userName, password, userEmail, lastLogin);
                users.Add(admin);
            }

            // Create Customers
            foreach (var row in customerDataList)
            {
                int userId = int.Parse(row["UserId"]);
                string userName = row["UserName"];
                string password = row["Password"];
                string role = row["Role"];
                string status = row["Status"];

                Customer customer = new Customer(userId, userName, password, role, status);
                users.Add(customer);
            }

            // Create Categories
            foreach (var row in categoryDataList)
            {
                int categoryId = int.Parse(row["CategoryId"]);
                string categoryName = row["CategoryName"];
                string description = row["Description"];

                Category category = new Category(categoryId, categoryName, description);
                categories.Add(category);
            }

            // Create Products
            foreach (var row in productDataList)
            {
                int productId = int.Parse(row["ProductId"]);
                string productName = row["ProductName"];
                decimal price = decimal.Parse(row["Price"]);
                int categoryId = int.Parse(row["CategoryId"]);

                Product product = new Product(productId, productName, price, categoryId);
                products.Add(product);
            }

            
            // Display User and Product/Category details
            Console.WriteLine("User Details:");
            foreach (var user in users)
            {
                Console.WriteLine(user.GetDetails());
            }

            Console.WriteLine("\nCategory Details:");
            foreach (var category in categories)
            {
                Console.WriteLine(category.GetDetails());
            }

            Console.WriteLine("\nProduct Details:");
            foreach (var product in products)
            {
                Console.WriteLine(product.GetDetails());
            }
        }

        // Helper method to read CSV file
        static List<Dictionary<string, string>> ReadCsvFile(string filePath)
        {
            List<Dictionary<string, string>> dataList = new List<Dictionary<string, string>>();
            var lines = File.ReadAllLines(filePath);
            var headers = lines[0].Split(',');

            for (int i = 1; i < lines.Length; i++)
            {
                var values = lines[i].Split(',');
                var row = new Dictionary<string, string>();
                for (int j = 0; j < headers.Length; j++)
                {
                    row[headers[j]] = values[j];
                }
                dataList.Add(row);
            }

            return dataList;
        }
    }

