using BlazorAppWASM.Client;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Security.Claims;
using System.Text.Json;

namespace BlazorAppWASM.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>(); //специальный провайдер дл€ отсеживани€ состо€ни€ аутентификации
            builder.Services.AddAuthorizationCore(); // дл€ функциональности авторизации

            builder.Services.AddBlazoredLocalStorage(); // дл€ хранени€ данных в браузере

            await builder.Build().RunAsync();
        }
    }

    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public CustomAuthenticationStateProvider(ILocalStorageService localStorageService, HttpClient httpClient)
        {
            _localStorage = localStorageService;
            _httpClient = httpClient;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string token = await _localStorage.GetItemAsStringAsync("token");

            var identity = new ClaimsIdentity();
            _httpClient.DefaultRequestHeaders.Authorization = null;

            if (!string.IsNullOrEmpty(token))
            {
                identity = new ClaimsIdentity(ParseClaims(token), "jwt");
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Replace("\"", ""));
            }

            var princ = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(princ);

            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }

        public static IEnumerable<Claim> ParseClaims(string token)
        {
            var s1 = token.Split('.')[1];
            var jsonStr = ParseJwt(s1);
            var keys = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonStr);
            return keys.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
        }

        public static byte[] ParseJwt(string jwt)
        {
            switch (jwt.Length % 4) 
            {
                case 2: jwt += "=="; break;
                case 3: jwt += "="; break;
            }
            return Convert.FromBase64String(jwt);
        }
    }
}
