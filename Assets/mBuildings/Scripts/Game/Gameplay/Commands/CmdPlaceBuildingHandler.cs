using System.Linq;
using mBuildings.Scripts.Game.State.cmd;
using mBuildings.Scripts.Game.State.cmd.Entities.Buildings;
using mBuildings.Scripts.Game.State.Root;
using UnityEngine;

namespace mBuildings.Scripts.Game.Gameplay.Commands
{
    public class CmdPlaceBuildingHandler : ICommandHandler<CmdPlaceBuilding>
    {
        private readonly GameStateProxy _gameState;

        public CmdPlaceBuildingHandler(GameStateProxy gameState)
        {
            _gameState = gameState;
        }

        public bool Handle(CmdPlaceBuilding command)
        {
            var currentMap = _gameState.Maps.FirstOrDefault(m =>m.Id == _gameState.CurrentMapId.CurrentValue);
            if (currentMap == null)
            {
                Debug.LogError($"No map found with id {_gameState.CurrentMapId.CurrentValue}");
                return false;
            }
            
            var entityId = _gameState.CreateEntityId();
            var newBuildingEntity = new BuildingEntity()
            {
                Id = entityId,
                Position = command.Position,
                TypeId = command.BuildingTypeId
            };

            var newBuildingEntityProxy = new BuildingEntityProxy(newBuildingEntity);
            currentMap.Buildings.Add(newBuildingEntityProxy);

            return true;
        }
    }
}