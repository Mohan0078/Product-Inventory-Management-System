using ProductInventoryManagementSystem.Model.CommandModel;
using ProductInventoryManagementSystem.Service.Interfaces;

namespace ProductInventoryManagementSystem.Service.Services
{
    public class AuthService : IAuthService
    {
        public async Task<List<string>> DoLogin(LoginCommandModel loginCommandModel)
        {
			try
			{
                return new List<string>();
			}
			catch (Exception)
			{
				throw;
			}
        }
    }
}
