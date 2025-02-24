using ProductInventoryManagementSystem.Model.CommandModel;
using ProductInventoryManagementSystem.Model.DatabaseEntityModel;
using ProductInventoryManagementSystem.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventoryManagementSystem.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductInventoryManagementDbContext _context;

        public ProductService(ProductInventoryManagementDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddProduct(ProductCommandModel productCommandModel)
        {
            try
            {
                var product = new Product()
                {
                  ProductId = Guid.NewGuid(),
                  ProductName = productCommandModel.ProductName,
                  Description = productCommandModel.ProductDescription,
                  CreatedBy = productCommandModel.CreatedBy,
                  CreatedOn = DateTime.UtcNow
                };

                _context.Products.Add(product);
                
                var isSaved = await _context.SaveChangesAsync() > 0;
                return isSaved;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
