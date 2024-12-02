using System;
using System.Collections.Generic;

namespace ShoppingControl
{

    public class User
    {
        // Basic user information for account management and authentication
        private int userId;
        private string userName;
        private string password;
        private string userEmail;
        private phoneNumber;
        private string street;
        private string city;
        private string postcode;
        
        public int UserID 
        { 
            get { return userId; } 
            set {userId = value; } 
        }
        
        public string UserName 
        { 
            get { return userName; } 
            set {userName = value; } 
        }
        
        public string Password 
        { 
            get { return password; } 
            set {password = value; } 
        }
        
        public string UserEmail 
        { 
            get { return userEmail; } 
            set {userEmail = value; } 
        }
        
        public string PhoneNumber 
        { 
            get { return phoneNumber; } 
            set {phoneNumber = value; } 
        }
        
        public string Street 
        { 
            get { return street; } 
            set {street = value; } 
        }
        
        public string City 
        { 
            get { return city; } 
            set {city = value; } 
        }
        
        public string Postcode 
        { 
            get { return postcode; } 
            set {postcode = value; } 
        }
        
    // Updates user profile information while handling potential errors
        public virtual void UpdateProfile()
        {
            try
            {
                Console.WriteLine("\n--- Update Profile ---");
            
                // Only update fields if new values are provided
                Console.Write("Enter new email (leave blank to keep current): ");
                string newEmail = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newEmail))
                {
                    UserEmail = newEmail;
                }

                Console.Write("Enter new phone number (leave blank to keep current): ");
                string newPhone = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newPhone))
                {
                    PhoneNumber = newPhone;
                }

                Console.WriteLine("Profile updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating profile: {ex.Message}");
            }
        }
        // Handles user logout process
        public virtual void Logout()
        {
            Console.WriteLine($"{UserName} has logged out.");
        }
    }
}
