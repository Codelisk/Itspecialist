using System.Diagnostics;
using ModuleAccount.Contracts.Services.AccountProvider;
using Prism.Dialogs;

namespace Itspecialist.Presentation
{
    public class ShellViewModel : BindableBase, IActiveAware
    {
        private readonly IRegionManager _regionManager;
        private readonly Func<IAccountProvider> _accountProvider;
        private readonly Func<ITokenCache> _tokenCache;
        private readonly Func<IAuthenticationService> _auth;
        private readonly Func<IDispatcher> _dispatcher;
        private readonly Func<IDialogService> _dialogs;
        private bool _isInitialized;

        public DelegateCommand NavigateCommand { get; }
        public ShellViewModel(
            IRegionManager regionManager,
            Func<IAccountProvider> accountProvider,
            Func<ITokenCache> tokenCache,
            Func<IAuthenticationService> auth,
            Func<IDispatcher> dispatcher,
            Func<IDialogService> dialogs)
        {
            _regionManager = regionManager;
            _accountProvider = accountProvider;
            _tokenCache = tokenCache;
            _auth = auth;
            _dispatcher = dispatcher;
            _dialogs = dialogs;
            NavigateCommand = new DelegateCommand(()=>ExecuteNavigateCommand());
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
                //var jnkdf = await _auth().LoginAsync(_dispatcher(), new Dictionary<string, string> { { "email", "d.hufnagl@codelisk.com" },{"password","Test1234!" } });
                //await _auth().RefreshAsync();

                _regionManager.RequestNavigate("ShellRegion", "ShellHeader");
            }
            catch(Exception ex)
            {

            }
        }
        private async void ExecuteNavigateCommand()
        {
            var sdf = await _tokenCache().HasTokenAsync(CancellationToken.None);
            Debug.WriteLine("TESTXXXXXXXXXXX");
            //var test = _resolveAuthService();
           // _regionManager.RequestNavigate("ContentRegion", viewName);
        }
    }
}
