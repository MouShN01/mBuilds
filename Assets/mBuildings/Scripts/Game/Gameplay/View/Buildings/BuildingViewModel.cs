using System.Collections.Generic;
using mBuildings.Scripts.Game.Gameplay.Services;
using mBuildings.Scripts.Game.Settings.Gameplay.Buildings;
using mBuildings.Scripts.Game.State.cmd.Entities.Buildings;
using R3;
using UnityEngine;

namespace mBuildings.Scripts.Game.Gameplay.View.Buildings
{
    public class BuildingViewModel
    {
        private readonly BuildingEntityProxy _buildingEntity;
        private readonly BuildingSettings _buildingSettings;
        private readonly BuildingService _buildingService;
        private readonly Dictionary<int, BuildingLevelSettings> _levelSettingsMap = new();
        
        public readonly int BuildingEntityId;
        public ReadOnlyReactiveProperty<Vector3Int> Position { get; }

        public readonly string TypeId;
        

        public BuildingViewModel(BuildingEntityProxy buildingEntity, BuildingSettings buildingSettings, BuildingService buildingService)
        {
            TypeId = buildingEntity.TypeId;
            BuildingEntityId = buildingEntity.Id;
            
            _buildingEntity = buildingEntity;
            _buildingSettings = buildingSettings;
            _buildingService = buildingService;

            foreach (var buildingLevelSettings in buildingSettings.LevelSettings)
            {
                _levelSettingsMap[buildingLevelSettings.Level] = buildingLevelSettings;
            }
            
            Position = buildingEntity.Position;
        }

        public BuildingLevelSettings GetLevelSettings(int level)
        {
            return _levelSettingsMap[level];
        }
    }
}