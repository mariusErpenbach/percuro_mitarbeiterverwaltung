using CommunityToolkit.Mvvm.Input;
using percuro_mitarbeiterverwaltung.Services;
using System.Threading.Tasks;
using System;

namespace percuro_mitarbeiterverwaltung.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public string? Username { get; set; }
        public string? Password { get; set; }

        public IAsyncRelayCommand LoginCommand { get; }
        public string? ErrorMessage { get; set; }

        private readonly AuthService _authService = new();

        public LoginViewModel()
        {
            LoginCommand = new AsyncRelayCommand(LoginAsync);
        }

        private async Task LoginAsync()
        {
            var result = await _authService.LoginAsync(Username ?? string.Empty, Password ?? string.Empty);
            Console.WriteLine($"Login attempt: user={Username}, success={result.Success}, error={result.Error}");
            if (!result.Success)
            {
                ErrorMessage = result.Error;
                OnPropertyChanged(nameof(ErrorMessage));
            }
            // Bei Erfolg: Token, Username, Role weiterverarbeiten
        }
    }
}
