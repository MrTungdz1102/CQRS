using Blazored.LocalStorage;

namespace CQRS.BlazorUI.Services.Base
{
    public class BaseHttpService
    {
        protected IClient _client;
        protected ILocalStorageService _localStorageService;

        public BaseHttpService(IClient client, ILocalStorageService localStorageService)
        {
            _client = client;
            _localStorageService = localStorageService;
        }
        protected Response<Guid> ConvertApiExceptions<Guid>(ApiException ex)
        {
            if (ex.StatusCode == 400)
            {
                return new Response<Guid>() { Message = "Invalid data was submitted", ValidationErrors = ex.Response, Success = false };
            }
            else if (ex.StatusCode == 404)
            {
                return new Response<Guid>() { Message = "The record was not found.", Success = false };
            }
            else
            {
                return new Response<Guid>() { Message = "Something went wrong, please try again later.", Success = false };
            }
        }

        // vi pham dry principle
        protected async Task AddBearerToken()
        {
            if(await _localStorageService.ContainKeyAsync("token"))
            {
                _client.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await _localStorageService.GetItemAsync<string>("token"));
            }
        }
    }
}
