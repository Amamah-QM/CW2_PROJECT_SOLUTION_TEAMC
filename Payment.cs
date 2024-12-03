using System;
using System.Collections.Generic;

public class Payment
{
    private int PaymentId { get; set; }
    private int OrderId { get; set; }
    private DateTime PaymentDate { get; set; }
    private double PaymentAmount { get; set; }

    // Constructor to initialize the Payment object with given values
    public Payment(int paymentId, int orderId, DateTime paymentDate, double paymentAmount)
    {
        PaymentId = paymentId;
        OrderId = orderId;
        PaymentDate = paymentDate;
        PaymentAmount = paymentAmount;
    }

    // Method to display the payment details
    public void DisplayPaymentDetails()
    {
        Console.WriteLine($"Payment ID: {PaymentId}");
        Console.WriteLine($"Order ID: {OrderId}");
        Console.WriteLine($"Payment Date: {PaymentDate}");
        Console.WriteLine($"Payment Amount: {PaymentAmount}");
    }
}
public class Program
{
    public static void Main()
    {
        // Sample payment data
        Payment payment = new Payment(1, 10, DateTime.Now, 102.98);

        // Display the payment details
        payment.DisplayPaymentDetails();
    }
}
