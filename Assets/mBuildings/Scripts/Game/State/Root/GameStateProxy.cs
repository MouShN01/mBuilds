using System.Linq;
using mBuildings.Scripts.Game.State.cmd.Entities.Buildings;
using mBuildings.Scripts.Game.State.GameResources;
using mBuildings.Scripts.Game.State.Maps;
using ObservableCollections;
using R3;

namespace mBuildings.Scripts.Game.State.Root
{
    public class GameStateProxy
    {
        private readonly GameState _gameState;

        public ReactiveProperty<int> CurrentMapId = new();
        public ObservableList<Map> Maps { get; } = new();
        public ObservableList<Resource> Resources { get; } = new();

        public GameStateProxy(GameState gameState)
        {
            _gameState = gameState;
            
            InitMaps(gameState);
            InitResources(gameState);
            
            CurrentMapId.Subscribe(newValue => gameState.CurrentMapId = newValue);
        }

        public int CreateEntityId()
        {
            return _gameState.CreateEntityId();
        }

        public void InitMaps(GameState gameState)
        {
            gameState.Maps.ForEach(m =>Maps.Add(new Map(m)));

            Maps.ObserveAdd().Subscribe(e =>
            {
                var addedMap = e.Value;
                gameState.Maps.Add(addedMap.Origin);
            });

            Maps.ObserveRemove().Subscribe(e =>
            {
                var removedMap = e.Value;
                var removedMapState =
                    gameState.Maps.FirstOrDefault(b => b.Id == removedMap.Id);
                gameState.Maps.Remove(removedMapState);
            });
        }
        
        public void InitResources(GameState gameState)
        {
            gameState.Resources.ForEach(resourceData =>Resources.Add(new Resource(resourceData)));

            Resources.ObserveAdd().Subscribe(e =>
            {
                var addedResource = e.Value;
                gameState.Resources.Add(addedResource.Origin);
            });

            Resources.ObserveRemove().Subscribe(e =>
            {
                var removedResource = e.Value;
                var removedResourceData =
                    gameState.Resources.FirstOrDefault(b => b.ResourceType == removedResource.ResourceType);
                gameState.Resources.Remove(removedResourceData);
            });
        }
    }
}