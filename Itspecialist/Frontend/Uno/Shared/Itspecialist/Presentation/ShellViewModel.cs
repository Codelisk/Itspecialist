using System.Diagnostics;
using ModuleAccount.Contracts.Services.AccountProvider;

namespace Itspecialist.Presentation
{
    public class ShellViewModel : BindableBase, IActiveAware
    {
        private readonly IRegionManager _regionManager;
        private readonly Func<IAccountProvider> _accountProvider;
        private bool _isInitialized;

        public DelegateCommand<string> NavigateCommand { get; }
        public ShellViewModel(
            IRegionManager regionManager,
            Func<IAccountProvider> accountProvider)
        {
            _regionManager = regionManager;
            _accountProvider = accountProvider;
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
