namespace Itspecialist.Presentation
{
    public partial class MainViewModel : ObservableObject
    {
        private IAuthenticationService _authentication;

        private INavigator _navigator;

        [ObservableProperty]
        private string? name;

        public MainViewModel(
            IStringLocalizer localizer,
            IOptions<AppConfig> appInfo,
            IAuthenticationService authentication,
            INavigator navigator)
        {
            _navigator = navigator;
            _authentication = authentication;
            Title = "Main";
            Title += $" - {localizer["ApplicationName"]}";
            Title += $" - {appInfo?.Value?.Environment}";
            GoToSecond = new AsyncRelayCommand(GoToSecondView);
            Logout = new AsyncRelayCommand(DoLogout);
        }
        public string? Title { get; }

        public ICommand GoToSecond { get; }

        public ICommand Logout { get; }

        private async Task GoToSecondView()
        {
            await _navigator.NavigateViewModelAsync<SecondViewModel>(this, data: new Entity(Name!));
        }

        public async Task DoLogout(CancellationToken token)
        {
            var test = await _authentication.LoginAsync(new Dictionary<string, string> { { "Logout", "true" } });
            await _authentication.LogoutAsync(token);
        }
    }
}
