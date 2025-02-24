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

				// matching the hashed password with the given password
				var isPasswordMatched = BCrypt.Net.BCrypt.Verify(loginCommandModel.Password, user.Password);

				if (isPasswordMatched)
					return user.Roles.Select(x => x.RoleName).ToList();
				else
					throw new Exception("Password is incorrect!");
			}
			catch (Exception ex)
			{
				throw new Exception("Something went wrong while login - "+ex);
			}
        }
    }
}
