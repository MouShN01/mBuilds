using System;
using System.Collections.Generic;
using mBuildings.Scripts.Game.State.cmd.Entities.Buildings;
using mBuildings.Scripts.Game.State.Maps;
using UnityEngine.Serialization;

namespace mBuildings.Scripts.Game.State.Root
{
    [Serializable]
    public class GameState
    {
        public int GlobalEntityId;
        public int CurrentMapId;
        public List<MapState> Maps;

        public int CreateEntityId()
        {
            return GlobalEntityId++;
        }
    }
}