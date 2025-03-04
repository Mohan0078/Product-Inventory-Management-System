﻿namespace ProductInventoryManagementSystem.Model.DatabaseEntityModel
{
    public class User
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }

        public ICollection<Role> Roles { get; set; }
    }
}
