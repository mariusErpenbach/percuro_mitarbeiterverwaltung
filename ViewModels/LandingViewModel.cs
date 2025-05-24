using CommunityToolkit.Mvvm.Input;

namespace percuro_mitarbeiterverwaltung.ViewModels
{
    public class LandingViewModel : ViewModelBase
    {
        public string WelcomeMessage => "Willkommen zur Mitarbeiterverwaltung!";

        public IRelayCommand GoToLoginCommand { get; }

        public LandingViewModel(System.Action goToLoginAction)
        {
            GoToLoginCommand = new RelayCommand(() => goToLoginAction());
        }
    }
}
