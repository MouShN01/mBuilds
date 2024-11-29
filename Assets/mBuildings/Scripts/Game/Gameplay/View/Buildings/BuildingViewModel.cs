using mBuildings.Scripts.Game.Gameplay.Services;
using mBuildings.Scripts.Game.State.cmd.Entities.Buildings;

namespace mBuildings.Scripts.Game.Gameplay.View.Buildings
{
    public class BuildingViewModel
    {
        private readonly BuildingEntityProxy _buildingEntity;
        private readonly BuildingService _buildingService;

        public BuildingViewModel(BuildingEntityProxy buildingEntity, BuildingService buildingService)
        {
            _buildingEntity = buildingEntity;
            _buildingService = buildingService;
        }
    }
}