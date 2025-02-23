namespace ProductInventoryManagementSystem.Model.DatabaseEntityModel
{
    public class UserRole
    {
      public Guid UserRoleId { get; set; }
      public Guid UserId { get; set; }
      public Guid RoleId { get; set; }
      public Guid CreatedBy { get; set; }
      public DateTime CreatedOn { get; set; }
    }
}
