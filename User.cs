using System;

public class User
{
    // Basic user information for account management and authentication
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string UserEmail { get; set; }

    // Contact and shipping address information
    public string PhoneNumber { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string Postcode { get; set; }
// Updates user profile information while handling potential errors
    public void UpdateProfile()
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
