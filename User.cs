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
