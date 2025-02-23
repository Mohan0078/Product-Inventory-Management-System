using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventoryManagementSystem.Model.DatabaseEntityModel
{
    public class Role
    {
      public Guid RoleId { get; set; }
      public string RoleName { get; set; }
      public string RoleType { get; set; }
      public DateTime CreatedOn { get; set; }
      public Guid CreatedBy { get; set; }
    }
}
