using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BasePagesBackendModule.PageViewModels;
using BaseServicesModule.Services.Vms;
using BaseSharedModule.Constants;
using Itspecialist.Api.Repositories;
using Itspecialist.Api.Services.Auth;
using Itspecialist.Foundation.Dtos.Account;
using ModuleAccount.Contracts.Services.AccountSetup;
using Prism.Commands;
using ReactiveUI;
using IAuthenticationService = Itspecialist.Api.Services.Auth.IAuthenticationService;

namespace ModuleAccount.Contracts.ViewModels
{
    public class DistrictSelectionViewModel : RegionBaseViewModel
    {
        private readonly IAccountSetupProvider _accountSetupProvider;
        private readonly IAuthenticationService _authenticationService;
        private readonly IDistrictRepository _districtRepository;

        public DistrictSelectionViewModel(
            IAccountSetupProvider accountSetupProvider,
            IAuthenticationService authenticationService,
            IDistrictRepository districtRepository,
            VmServices vmServices) : base(vmServices)
        {
            _accountSetupProvider = accountSetupProvider;
            _authenticationService = authenticationService;
            _districtRepository = districtRepository;
        }
        public override async void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);

            //await _authenticationService.AuthenticateAndCacheTokenAsync(new Foundation.Api.Models.AuthPayload() { email = "user@test.at", password = "Test1234!" });
            //Districts = new ObservableCollection<DistrictDto>( await _districtRepository.GetAll());
            this.RaisePropertyChanged(nameof(Districts));
        }

        private DistrictDto selectedDistrict;
        public DistrictDto SelectedDistrict
        {
            get { return selectedDistrict; }
            set { this.RaiseAndSetIfChanged(ref selectedDistrict, value); }
        }
        public ObservableCollection<DistrictDto> Districts { get; set; }
        public ICommand AuthCommand => new AsyncDelegateCommand(OnAuthAsync);
        private async Task OnAuthAsync()
        {
            Console.WriteLine("WWWWWWWWWWWW");
            //_accountSetupProvider.District = Districts.First();
            //this.ChangeCurrentRegion("ChooseSkills");
        }
    }
}
