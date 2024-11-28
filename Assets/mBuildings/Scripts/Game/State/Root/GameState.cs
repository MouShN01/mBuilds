using System;
using System.Collections.Generic;
using mBuildings.Scripts.Game.State.Buildings;
using UnityEngine.Serialization;

namespace mBuildings.Scripts.Game.State.Root
{
    [Serializable]
    public class GameState
    {
        [FormerlySerializedAs("Building")] public List<BuildingEntity> Buildings;
    }
}