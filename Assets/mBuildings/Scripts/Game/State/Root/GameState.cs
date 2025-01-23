using System;
using System.Collections.Generic;
using mBuildings.Scripts.Game.State.GameResources;
using mBuildings.Scripts.Game.State.Maps;

namespace mBuildings.Scripts.Game.State.Root
{
    [Serializable]
    public class GameState
    {
        public int GlobalEntityId;
        public int CurrentMapId;
        public List<MapState> Maps;
        public List<ResourceData> Resources;

        public int CreateEntityId()
        {
            return GlobalEntityId++;
        }
    }
}