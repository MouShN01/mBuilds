using mBuildings.Scripts.Game.GameRoot;

namespace mBuildings.Scripts.Game.Gameplay.Root
{
    public class GameplayEnterParams : SceneEnterParams
    {
        public string SaveFileName { get; }
        public int MapId { get; }
        
        public GameplayEnterParams(int mapId) : base(Scenes.GAMEPLAY)
        {
            MapId = mapId;
        }
    }
}