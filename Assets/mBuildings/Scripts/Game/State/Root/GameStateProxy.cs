using System.Linq;
using mBuildings.Scripts.Game.State.cmd.Entities.Buildings;
using ObservableCollections;
using R3;

namespace mBuildings.Scripts.Game.State.Root
{
    public class GameStateProxy
    {
        private readonly GameState _gameState;
        public ObservableList<BuildingEntityProxy> Buildings { get; } = new();

        public GameStateProxy(GameState gameState)
        {
            _gameState = gameState;
            gameState.Buildings.ForEach(b =>Buildings.Add(new BuildingEntityProxy(b)));

            Buildings.ObserveAdd().Subscribe(e =>
            {
                var addedBuildingEntity = e.Value;
                gameState.Buildings.Add(addedBuildingEntity.Origin);
            });

            Buildings.ObserveRemove().Subscribe(e =>
            {
                var removedBuildingEntityProxy = e.Value;
                var removedBuildingEntity =
                    gameState.Buildings.FirstOrDefault(b => b.Id == removedBuildingEntityProxy.Id);
                gameState.Buildings.Remove(removedBuildingEntity);
            });
        }

        public int GetEntityId()
        {
            return _gameState.GlobalEntityId++;
        }
    }
}