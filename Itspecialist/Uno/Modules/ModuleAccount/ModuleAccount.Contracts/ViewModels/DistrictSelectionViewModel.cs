using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Itspecialist.Api.Repositories;
using Prism.Commands;
using Uno.Extensions;
using Uno.Extensions.Authentication;

namespace ModuleAccount.Contracts.ViewModels
{
    public class DistrictSelectionViewModel
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IDispatcher _dispatcher;
        private readonly IAuthRepository _authRepository;

        public DistrictSelectionViewModel(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
            //_authenticationService = authenticationService;
            //_dispatcher = dispatcher;
        }

        public ICommand AuthCommand => new AsyncDelegateCommand(OnAuthAsync);
        private async Task OnAuthAsync()
        {
            var test = await _authRepository.LoginAsync(new Foundation.Api.Models.AuthPayload() { email = "user@test.at", password = "Test1234!" });
            await _authenticationService.LoginAsync(_dispatcher);
        }
    }
}
