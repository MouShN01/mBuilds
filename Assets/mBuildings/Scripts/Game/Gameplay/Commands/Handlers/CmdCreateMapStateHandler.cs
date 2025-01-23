using System.Collections.Generic;
using System.Linq;
using mBuildings.Scripts.Game.Settings;
using mBuildings.Scripts.Game.State.cmd;
using mBuildings.Scripts.Game.State.cmd.Entities.Buildings;
using mBuildings.Scripts.Game.State.Maps;
using mBuildings.Scripts.Game.State.Root;
using UnityEngine;

namespace mBuildings.Scripts.Game.Gameplay.Commands
{
    public class CmdCreateMapStateHandler:ICommandHandler<CmdCreateMapState>
    {
        private readonly GameStateProxy _gameState;
        private readonly GameSettings _gameSettings;

        public CmdCreateMapStateHandler(GameStateProxy gameState, GameSettings gameSettings)
        {
            _gameState = gameState;
            _gameSettings = gameSettings;
        }

        public bool Handle(CmdCreateMapState command)
        {
            var isMapAlreadyExisted = _gameState.Maps.Any(m => m.Id == command.MapId);

            if (isMapAlreadyExisted)
            {
                Debug.Log($"Map {command.MapId} already exists");
                return false;
            }

            var newMapSettings = _gameSettings.MapsSettings.Maps.First(m => m.MapId == command.MapId);
            var newMapInitialStateSettings = newMapSettings.mapInitialStateSettings;

            var initialBuildings = new List<BuildingEntity>();
            foreach (var buildingSettings in newMapInitialStateSettings.Buildings)
            {
                var initialBuilding = new BuildingEntity
                {
                    Id = command.MapId,
                    TypeId = buildingSettings.TypeId,
                    Position = buildingSettings.Position,
                    Level = buildingSettings.Level
                };
                initialBuildings.Add(initialBuilding);
            }

            var newMapState = new MapState
            {
                Id = command.MapId,
                Buildings = initialBuildings,
            };

            var newMapStateProxy = new Map(newMapState);
            
            _gameState.Maps.Add(newMapStateProxy);

            return true;
        }
    }
}