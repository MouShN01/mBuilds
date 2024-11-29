using mBuildings.Scripts.Game.State.cmd;
using mBuildings.Scripts.Game.State.cmd.Entities.Buildings;
using mBuildings.Scripts.Game.State.Root;

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
            var entityId = _gameState.GetEntityId();
            var newBuildingEntity = new BuildingEntity()
            {
                Id = entityId,
                Position = command.Position,
                TypeId = command.BuildingTypeId
            };

            var newBuildingEntityProxy = new BuildingEntityProxy(newBuildingEntity);
            _gameState.Buildings.Add(newBuildingEntityProxy);

            return true;
        }
    }
}