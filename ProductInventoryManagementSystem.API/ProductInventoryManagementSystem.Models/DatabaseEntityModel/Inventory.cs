namespace ProductInventoryManagementSystem.Model.DatabaseEntityModel
{
    public class Inventory
    {
        public Guid InventoryId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public string WareHouseLocation { get; set; }
        public virtual Product Product { get; set; }
    }
}
