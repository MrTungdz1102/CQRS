namespace CQRS.BlazorUI.InterfaceContracts
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(string email, string password);
        Task<bool> RegisterAsync(string firstName, string lastName, string userName, string email, string password);
        Task Logout();
    }
}
