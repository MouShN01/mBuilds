using System;
using System.Collections.Generic;
using mBuildings.Scripts.Game.State.cmd.Entities.Buildings;
using UnityEngine.Serialization;

namespace mBuildings.Scripts.Game.State.Root
{
    [Serializable]
    public class GameState
    {
        public int GlobalEntityId;
        public List<BuildingEntity> Buildings;
    }
}