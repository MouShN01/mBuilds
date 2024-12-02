using mBuildings.Scripts.Game.Gameplay.Services;
using mBuildings.Scripts.Game.Gameplay.View.Buildings;
using ObservableCollections;

namespace mBuildings.Scripts.Game.Gameplay.Root.UI
{
    public class WorldGameplayRootViewModel
    {
        public readonly IObservableCollection<BuildingViewModel> AllBuildings;

        public WorldGameplayRootViewModel(BuildingService buildingService)
        {
            AllBuildings = buildingService.AllBuildings;
        }
    }
}