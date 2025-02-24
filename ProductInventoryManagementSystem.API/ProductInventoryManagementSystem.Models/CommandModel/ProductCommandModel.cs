namespace ProductInventoryManagementSystem.Model.CommandModel
{
    public class ProductCommandModel
    {
     public string ProductName { get; set; }
     public string ProductDescription { get; set; }
     public double price { get; set; }
     public Guid CreatedBy { get; set; }
    }
}
