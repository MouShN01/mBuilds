using System.Linq;
using mBuildings.Scripts.Game.State.Buildings;
using ObservableCollections;
using R3;

namespace mBuildings.Scripts.Game.State.Root
{
    public class GameStateProxy
    {
        public ObservableList<BuildingEntityProxy> Buildings { get; } = new();

        public GameStateProxy(GameState gameState)
        {
            gameState.Buildings.ForEach(b =>Buildings.Add(new BuildingEntityProxy(b)));

            Buildings.ObserveAdd().Subscribe(e =>
            {
                var addedBuildingEntity = e.Value;
                gameState.Buildings.Add(new BuildingEntity
                {
                    Id = addedBuildingEntity.Id,
                    TypeId = addedBuildingEntity.TypeId,
                    Position = addedBuildingEntity.Position.Value,
                    Level = addedBuildingEntity.Level.Value
                });
            });

            Buildings.ObserveRemove().Subscribe(e =>
            {
                var removedBuildingEntityProxy = e.Value;
                var removedBuildingEntity =
                    gameState.Buildings.FirstOrDefault(b => b.Id == removedBuildingEntityProxy.Id);
                gameState.Buildings.Remove(removedBuildingEntity);
            });
        }
    }
}