using ProductInventoryManagementSystem.Model.CommandModel;

namespace ProductInventoryManagementSystem.Service.Interfaces
{
    public interface IAuthService
    {
        Task<List<string>> DoLogin(LoginCommandModel loginCommandModel);
    }
}
