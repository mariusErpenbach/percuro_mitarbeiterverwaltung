using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace percuro_mitarbeiterverwaltung.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient = new();

        public async Task<(bool Success, string? Token, string? Username, string? Role, string? Error)> LoginAsync(string username, string password)
        {
            var request = new { username = username, password = password };
            try
            {
                Console.WriteLine($"[AuthService] Sende Login-Request: Username={username}, Password={password}");
                var jsonString = System.Text.Json.JsonSerializer.Serialize(request);
                Console.WriteLine($"[AuthService] Gesendetes JSON: {jsonString}");
                var response = await _httpClient.PostAsJsonAsync("http://localhost:5005/api/login", request);
                var json = await response.Content.ReadFromJsonAsync<LoginResponse>();

                Console.WriteLine($"[AuthService] Antwort: success={json?.success}, username={json?.username}, role={json?.role}, error={json?.error}, token={json?.token}");

                if (json != null && json.success)
                    return (true, json.token, json.username, json.role, null);

                // Fehlertext auslesen
                return (false, null, null, null, json?.error ?? "Unbekannter Fehler");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[AuthService] Exception: {ex.Message}");
                return (false, null, null, null, ex.Message);
            }
        }

        private class LoginResponse
        {
            public bool success { get; set; }
            public string? token { get; set; }
            public string? username { get; set; }
            public string? role { get; set; }
            public string? error { get; set; }
        }
    }
}
