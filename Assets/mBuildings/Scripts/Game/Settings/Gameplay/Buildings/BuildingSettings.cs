using System.Collections.Generic;
using UnityEngine;

namespace mBuildings.Scripts.Game.Settings.Gameplay.Buildings
{
    [CreateAssetMenu(fileName = "BuildingSettings", menuName = "Game Settings/Buildings/New Building Settings")]
    public class BuildingSettings:ScriptableObject
    {
        public string TypeId;
        public string TitleLId;
        public string DescriptionLId;
        public List<BuildingLevelSettings> LevelSettings;
    }
}