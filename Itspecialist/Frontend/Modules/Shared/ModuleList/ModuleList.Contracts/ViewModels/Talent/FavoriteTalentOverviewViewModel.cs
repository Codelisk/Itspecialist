using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasePagesBackendModule.PageViewModels;
using BaseServicesModule.Services.Vms;
using Itspecialist.Api;
using ReactiveUI;

namespace ModuleList.Contracts.ViewModels.Talent
{
    public partial class FavoriteTalentOverviewViewModel : RegionBaseViewModel
    {
        private readonly IFavoriteTalentRepository _favoriteTalentRepository;
        private readonly IFavoriteOpportunityRepository _favoriteOpportunityRepository;

        public FavoriteTalentOverviewViewModel(VmServices vmServices, IFavoriteTalentRepository favoriteTalentRepository, IFavoriteOpportunityRepository favoriteOpportunityRepository) : base(vmServices)
        {
            _favoriteTalentRepository = favoriteTalentRepository;
            _favoriteOpportunityRepository = favoriteOpportunityRepository;
        }

        public List<FavoriteTalentFull> FavoriteTalents { get; set; }
        public override async void Initialize(NavigationContext navigationContext)
        {
            base.Initialize(navigationContext);

            FavoriteTalents = await _favoriteTalentRepository.GetAllFull();
            this.RaisePropertyChanged(nameof(FavoriteTalents));
        }
    }
}
