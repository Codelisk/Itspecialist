using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Itspecialist.Api.Repositories;
using Itspecialist.Api.Services.Auth;
using Prism.Commands;
using Uno.Extensions;
using Uno.Extensions.Authentication;
using IAuthenticationService = Itspecialist.Api.Services.Auth.IAuthenticationService;

namespace ModuleAccount.Contracts.ViewModels
{
    public class DistrictSelectionViewModel
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IDistrictRepository _districtRepository;

        public DistrictSelectionViewModel(IAuthenticationService authenticationService, IDistrictRepository districtRepository)
        {
            _authenticationService = authenticationService;
            _districtRepository = districtRepository;
        }
        public List<string> Districts { get; set; } = new List<string>() { "Gmunden", "Bad Ischl" };
        public ICommand AuthCommand => new AsyncDelegateCommand(OnAuthAsync);
        private async Task OnAuthAsync()
        {
            await _authenticationService.AuthenticateAndCacheTokenAsync(new Foundation.Api.Models.AuthPayload() { email = "user@test.at", password = "Test1234!" });
            var test = await _districtRepository.GetAll();
        }
    }
}
