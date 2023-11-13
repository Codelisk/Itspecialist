using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ModuleAccount.Contracts.ViewModels
{
    public class DistrictSelectionViewModel
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IDispatcher _dispatcher;

        public DistrictSelectionViewModel(IAuthenticationService authenticationService=null)
        {
            //_authenticationService = authenticationService;
            //_dispatcher = dispatcher;
        }

        public ICommand AuthCommand => new AsyncDelegateCommand(OnAuthAsync);
        private async Task OnAuthAsync()
        {
            await _authenticationService.LoginAsync(_dispatcher);
        }
    }
}
