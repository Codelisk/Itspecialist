using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BasePagesBackendModule.PageViewModels;
using BaseServicesModule.Services.Vms;
using Itspecialist.Api.Repositories;
using Itspecialist.Api.Services.Auth;
using Itspecialist.Foundation.Dtos.Account;
using Prism.Commands;
using ReactiveUI;
using IAuthenticationService = Itspecialist.Api.Services.Auth.IAuthenticationService;

namespace ModuleAccount.Contracts.ViewModels
{
    public class DistrictSelectionViewModel : RegionBaseViewModel
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IDistrictRepository _districtRepository;

        public DistrictSelectionViewModel(IAuthenticationService authenticationService, IDistrictRepository districtRepository, VmServices vmServices) : base(vmServices)
        {
            _authenticationService = authenticationService;
            _districtRepository = districtRepository;
        }
        public override async void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);

            await _authenticationService.AuthenticateAndCacheTokenAsync(new Foundation.Api.Models.AuthPayload() { email = "user@test.at", password = "Test1234!" });
            Districts = await _districtRepository.GetAll();
            this.RaisePropertyChanged(nameof(Districts));
        }
        public DistrictDto SelectedDistrict { get; set; }
        public List<DistrictDto> Districts { get; set; }
        public ICommand AuthCommand => new AsyncDelegateCommand(OnAuthAsync);
        private async Task OnAuthAsync()
        {
            
        }
    }
}