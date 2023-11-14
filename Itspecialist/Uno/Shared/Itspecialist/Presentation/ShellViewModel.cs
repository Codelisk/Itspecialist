namespace Itspecialist.Presentation
{
    public class ShellViewModel : BindableBase, IActiveAware
    {
        private readonly IRegionManager _regionManager;
        private bool _isInitialized;
        private readonly Func<IAuthenticationService> _resolveAuthService;

        public DelegateCommand<string> NavigateCommand { get; }
        public ShellViewModel(
            IRegionManager regionManager, Func<IAuthenticationService> resolveAuthService)
        {
            _regionManager = regionManager;
            _resolveAuthService = resolveAuthService;
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
        private void Initialize()
        {
            _isInitialized = true;

            try
            {
                var authService = _resolveAuthService();
            }
            catch(Exception ex)
            {

            }
        }
        private void ExecuteNavigateCommand(string viewName)
        {
            //var test = _resolveAuthService();
            _regionManager.RequestNavigate("ContentRegion", viewName);
        }
    }
}
