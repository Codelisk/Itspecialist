using System.Diagnostics;

namespace Itspecialist.Presentation
{
    public class ShellViewModel : BindableBase, IActiveAware
    {
        private readonly IRegionManager _regionManager;
        private bool _isInitialized;

        public DelegateCommand<string> NavigateCommand { get; }
        public ShellViewModel(
            IRegionManager regionManager)
        {
            _regionManager = regionManager;
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
            _regionManager.RequestNavigate("ShellRegion", "ShellHeader");
        }
        private void ExecuteNavigateCommand(string viewName)
        {
            Debug.WriteLine("TESTXXXXXXXXXXX");
            //var test = _resolveAuthService();
            _regionManager.RequestNavigate("ContentRegion", viewName);
        }
    }
}
