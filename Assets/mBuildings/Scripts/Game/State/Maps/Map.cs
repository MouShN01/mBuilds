using System.Linq;
using mBuildings.Scripts.Game.State.cmd.Entities.Buildings;
using ObservableCollections;
using R3;

namespace mBuildings.Scripts.Game.State.Maps
{
    public class Map
    {
        public int Id => Origin.Id;
        public ObservableList<BuildingEntityProxy> Buildings { get; } = new();
        
        public MapState Origin { get; }

        public Map(MapState mapState)
        {
            Origin = mapState;
            mapState.Buildings.ForEach(b =>Buildings.Add(new BuildingEntityProxy(b)));

            Buildings.ObserveAdd().Subscribe(e =>
            {
                var addedBuildingEntity = e.Value;
                mapState.Buildings.Add(addedBuildingEntity.Origin);
            });

            Buildings.ObserveRemove().Subscribe(e =>
            {
                var removedBuildingEntityProxy = e.Value;
                var removedBuildingEntity =
                    mapState.Buildings.FirstOrDefault(b => b.Id == removedBuildingEntityProxy.Id);
                mapState.Buildings.Remove(removedBuildingEntity);
            });
        }
    }
}