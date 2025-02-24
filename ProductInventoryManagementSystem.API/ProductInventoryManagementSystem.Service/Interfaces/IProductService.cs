using ProductInventoryManagementSystem.Model.CommandModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventoryManagementSystem.Service.Interfaces
{
    public interface IProductService
    {
        Task<bool> AddProduct(ProductCommandModel productCommandModel);
    }
}
