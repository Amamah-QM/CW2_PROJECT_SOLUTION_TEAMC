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

