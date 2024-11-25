public class ShoppingBasket
{
    // List to store products and their quantities in the shopping basket
    private List<(Product product, int quantity)> items = new List<(Product, int)>();

    // Method to add a product to the shopping basket
    public void AddProduct(Product product, int quantity)
    {
        items.Add((product, quantity));
    }

    // Method to remove a product from the shopping basket
    public void RemoveProduct(Product product)
    {
        // Remove all instances of the product with the matching ProductID
        items.RemoveAll(item => item.product.ProductID == product.ProductID);
    }

    // Method to view all products in the shopping basket
    public void ViewBasket()
    {
        Console.WriteLine("Shopping Basket:");
        // Iterate through each item in the basket and display its details
        foreach (var item in items)
        {
            Console.WriteLine($"{item.product} - Quantity: {item.quantity}");
        }
    }
}
