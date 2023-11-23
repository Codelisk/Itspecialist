using System.Diagnostics;
using ModuleAccount.Contracts.Services.AccountProvider;

namespace Itspecialist.Presentation
{
    public class ShellViewModel : BindableBase, IActiveAware
    {
        private readonly IRegionManager _regionManager;
        private readonly Func<IAccountProvider> _accountProvider;
        private readonly Func<IAuthenticationService> _auth;
        private readonly Func<IDispatcher> _dispatcher;
        private bool _isInitialized;

        public DelegateCommand<string> NavigateCommand { get; }
        public ShellViewModel(
            IRegionManager regionManager,
            Func<IAccountProvider> accountProvider,
            Func<IAuthenticationService> auth,
            Func<IDispatcher> dispatcher)
        {
            _regionManager = regionManager;
            _accountProvider = accountProvider;
            _auth = auth;
            _dispatcher = dispatcher;
            NavigateCommand = new DelegateCommand<string>(ExecuteNavigateCommand);
        }
        private bool _isActive;
        public event EventHandler IsActiveChanged;
        public bool IsActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
                if (!_isInitialized) Initialize();
            }
        }
        private async void Initialize()
        {
            _isInitialized = true;
            try
            {
                var jnkdf = await _auth().LoginAsync(_dispatcher(), new Dictionary<string, string> { { "email", "d.hufnagl@codelisk.com" },{"password","Test1234!" } });
                await _auth().RefreshAsync();
                await _accountProvider().SetAccountAsync();
                _regionManager.RequestNavigate("ContentRegion", "DistrictSelection");
                _regionManager.RequestNavigate("ShellRegion", "ShellHeader");
            }
            catch(Exception ex)
            {

            }
        }
        private void ExecuteNavigateCommand(string viewName)
        {
            Debug.WriteLine("TESTXXXXXXXXXXX");
            //var test = _resolveAuthService();
            _regionManager.RequestNavigate("ContentRegion", viewName);
        }
    }
}
