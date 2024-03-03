using Blazored.LocalStorage;
using CQRS.BlazorUI.InterfaceContracts;
using CQRS.BlazorUI.Provider;
using CQRS.BlazorUI.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;

namespace CQRS.BlazorUI.Services
{
    public class AuthService : BaseHttpService, IAuthService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthService(IClient client, ILocalStorageService localStorageService, AuthenticationStateProvider authenticationStateProvider) : base(client, localStorageService)
        {
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            try
            {
                AuthRequest authenticationRequest = new AuthRequest() { Email = email, Password = password };
                var authenticationResponse = await _client.LoginAsync(authenticationRequest);
                if (!string.IsNullOrEmpty(authenticationResponse.Token))
                {
                    await _localStorageService.SetItemAsync("token", authenticationResponse.Token);

                    // Set claims in Blazor and login state
                    // AuthenticationStateProvider khong co loggedin do do can ep kieu
                    await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedIn();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task Logout()
        {
            //  await _localStorageService.RemoveItemAsync("token");
            await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedOut();
        }

        public async Task<bool> RegisterAsync(string firstName, string lastName, string userName, string email, string password)
        {
            RegistrationRequest registrationRequest = new RegistrationRequest() { FirstName = firstName, LastName = lastName, Email = email, UserName = userName, Password = password };
            var response = await _client.RegisterAsync(registrationRequest);

            if (!string.IsNullOrEmpty(response.UserId))
            {
                return true;
            }
            return false;
        }
    }
}
