namespace ProductInventoryManagementSystem.Model.DatabaseEntityModel
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }

        public ICollection<Inventory> Inventories { get; set; }
    }
}
