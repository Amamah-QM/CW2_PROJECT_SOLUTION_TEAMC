public class Product
{
  // properties to store relevant information
  public int ProductID { get; set; }
  public string ProductName { get; set; }
  public string ProductDescription { get; set; }
  public double Price { get; set; }
  public int StockQuantity { get; set; }
  public int CategoryID { get; set; }

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
