namespace percuro_mitarbeiterverwaltung.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase _currentViewModel;
    public ViewModelBase CurrentViewModel
    {
        get => _currentViewModel;
        set => SetProperty(ref _currentViewModel, value);
    }

    public MainWindowViewModel()
    {
        _currentViewModel = new LandingViewModel(() => CurrentViewModel = new LoginViewModel());
    }

    public string Greeting { get; } = "Welcome to Avalonia!";
}
