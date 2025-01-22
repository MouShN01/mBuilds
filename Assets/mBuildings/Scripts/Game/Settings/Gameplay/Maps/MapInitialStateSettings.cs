using System;
using System.Collections.Generic;
using mBuildings.Scripts.Game.Settings.Gameplay.Buildings;

namespace mBuildings.Scripts.Game.Settings.Gameplay.Maps
{
    [Serializable]
    public class MapInitialStateSettings
    {
        public List<BuildingInitialStateSettings> Buildings;
        
    }
}