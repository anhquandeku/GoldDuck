using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace GoldDuckCamera.Client
{
    public class ApiAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService localStorage;
        public ApiAuthenticationStateProvider(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            this.localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var savedToken = await localStorage.GetItemAsync<string>("authToken");
            if (string.IsNullOrEmpty(savedToken))
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

            }
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", savedToken);
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(ParseClaimFromJwt(savedToken), "jwt")));
        }
        public void MarkUserAuthenticated(string username)
        {
            var authenticationUser = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) }, "apiauth"));
            var authState = Task.FromResult(new AuthenticationState(authenticationUser));
            NotifyAuthenticationStateChanged(authState);
        }
        public void MarkUserAsLogout()
        {
            var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(anonymousUser));
            NotifyAuthenticationStateChanged(authState);
        }
        public IEnumerable<Claim> ParseClaimFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split(".")[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));
            return claims;
        }

        private byte[] ParseBase64WithoutPadding(string payload)
        {
            switch (payload.Length % 4)
            {
                case 2:
                payload += "==";
                break;
                case 3:
                payload += "=";
                break;
            }
            return Convert.FromBase64String(payload);
        }
    }
}
