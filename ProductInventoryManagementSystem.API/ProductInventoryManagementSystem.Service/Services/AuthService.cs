using Microsoft.EntityFrameworkCore;
using ProductInventoryManagementSystem.Model.CommandModel;
using ProductInventoryManagementSystem.Model.DatabaseEntityModel;
using ProductInventoryManagementSystem.Service.Interfaces;

namespace ProductInventoryManagementSystem.Service.Services
{
    public class AuthService : IAuthService
    {
		private readonly ProductInventoryManagementDbContext _context;
        public AuthService(ProductInventoryManagementDbContext context)
		{
          _context = context;
		}
		/// <summary>
		/// Taken email and password and return list of roles assigned to a user when login successful
		/// </summary>
		/// <param name="loginCommandModel"></param>
		/// <returns></returns>
        public async Task<List<string>> DoLogin(LoginCommandModel loginCommandModel)
        {
			try
			{
				var user = await _context.Users.Include(x => x.Roles)
					          .FirstOrDefaultAsync(x => x.Email == loginCommandModel.Email);

				if(user == null)
				{
					throw new Exception("User not exists!");
				}
				return user.Roles.Select(x => x.RoleName).ToList();
			}
			catch (Exception)
			{
				throw;
			}
        }
    }
}
