using System.Collections.Generic;
using UnityEngine;

namespace mBuildings.Scripts.Game.Settings.Gameplay.Maps
{
    [CreateAssetMenu(fileName = "MapsSettings", menuName = "Game Settings/Maps/New Maps Settings")]
    public class MapsSettings : ScriptableObject
    {
        public List<MapSettings> Maps;
    }
}