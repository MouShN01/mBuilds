using mBuildings.Scripts.Game.Gameplay.Services;
using mBuildings.Scripts.Game.State.cmd.Entities.Buildings;
using R3;
using UnityEngine;

namespace mBuildings.Scripts.Game.Gameplay.View.Buildings
{
    public class BuildingViewModel
    {
        private readonly BuildingEntityProxy _buildingEntity;
        private readonly BuildingService _buildingService;
        
        public readonly int BuildingEntityId;
        public ReadOnlyReactiveProperty<Vector3Int> Position { get; }
        

        public BuildingViewModel(BuildingEntityProxy buildingEntity, BuildingService buildingService)
        {
            BuildingEntityId = buildingEntity.Id;
            
            _buildingEntity = buildingEntity;
            _buildingService = buildingService;
            
            Position = buildingEntity.Position;
        }
    }
}