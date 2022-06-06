using Blazored.LocalStorage;
using GoldDuckCamera.Shared.Authentication;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace GoldDuckCamera.Client.Services
{
    
    public class AuthService: IAuthService
    {
        public readonly HttpClient httpClient;
        public readonly ILocalStorageService localStorage;
        public readonly ApiAuthenticationStateProvider apiAuthenticationStateProvider;

        public AuthService(HttpClient httpClient, ApiAuthenticationStateProvider apiAuthenticationStateProvider, ILocalStorageService localStorage)
        {
            this.httpClient = httpClient;
            this.apiAuthenticationStateProvider = apiAuthenticationStateProvider;
            this.localStorage = localStorage;
        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var result = await httpClient.PostAsJsonAsync("api/login", loginRequest);
            var content = await result.Content.ReadAsStringAsync();

            var loginResponse = JsonSerializer.Deserialize<LoginResponse>(content,
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });
            if (!result.IsSuccessStatusCode)
            {
                return loginResponse;
            }
            await localStorage.SetItemAsync("authToken", loginResponse.Token);
            ((ApiAuthenticationStateProvider) apiAuthenticationStateProvider).MarkUserAuthenticated(loginRequest.UserName);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResponse.Token);
            return loginResponse;
        }

        public async Task Logout()
        {
            await localStorage.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider) apiAuthenticationStateProvider).MarkUserAsLogout();
        }
    }
}
