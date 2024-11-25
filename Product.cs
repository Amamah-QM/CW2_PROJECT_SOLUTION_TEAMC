public class Product
{
  // properties to store relevant information
  private int ProductID { get; set; }
  private string ProductName { get; set; }
  private string ProductDescription { get; set; }
  private double Price { get; set; }
  private int StockQuantity { get; set; }
  private int CategoryID { get; set; }

  // Constructor to initialize a new product with the given details
  public int Product ( int productId, string productName, string productDescription, double price, int stockQuantity, int categoryId)
  {
    ProductID = productId;
    ProductName = productName;
    ProductDescription = productDescription;
    Price = price;
    StockQuantity = stockQuantity;
    CategoryID = categoryId;
  }
}
