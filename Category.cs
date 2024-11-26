public class Category
{
    // Basic category information for product organization
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string CategoryDescription { get; set; }
   
    // Creates a new category with required information
    public Category(int categoryId, string categoryName, string categoryDescription)
    {
        CategoryId = categoryId;
        CategoryName = categoryName;
        CategoryDescription = categoryDescription;
    }

