using System;
using System.Collections.Generic;
using mBuildings.Scripts.Game.State.cmd.Entities.Buildings;
using UnityEngine;

namespace mBuildings.Scripts.Game.State.Maps
{
    [Serializable]
    public class MapState
    {
        public int Id;
        public List<BuildingEntity> Buildings;
    }
}

