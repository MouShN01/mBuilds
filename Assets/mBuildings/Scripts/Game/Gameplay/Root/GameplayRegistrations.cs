using System;
using System.Linq;
using BaCon;
using mBuildings.Scripts.Game.Gameplay.Commands;
using mBuildings.Scripts.Game.Gameplay.Services;
using mBuildings.Scripts.Game.Settings;
using mBuildings.Scripts.Game.State;
using mBuildings.Scripts.Game.State.cmd;

namespace mBuildings.Scripts.Game.Gameplay.Root
{
    public static class GameplayRegistrations
    {
        public static void Register(DIContainer container, GameplayEnterParams gameplayEnterParams)
        {
            var gameStateProvider = container.Resolve<IGameStateProvider>();
            var gameState = gameStateProvider.GameState;
            var settingsProvider = container.Resolve<ISettingsProvider>();
            var gameSettings = settingsProvider.GameSettings;
            
            var cmd = new CommandProcessor(gameStateProvider);
            cmd.RegisterHandler(new CmdPlaceBuildingHandler(gameState));
            cmd.RegisterHandler(new CmdCreateMapStateHandler(gameState, gameSettings));
            container.RegisterInstance<ICommandProcessor>(cmd);

            var loadingMapId = gameplayEnterParams.MapId;
            var loadingMap = gameState.Maps.FirstOrDefault(m => m.Id == loadingMapId);
            if (loadingMap == null)
            {
                var command = new CmdCreateMapState(loadingMapId);
                var success = cmd.Process(command);
                if (!success)
                {
                    throw new Exception($"Failed to create map with id:{loadingMapId}");
                }
                
                loadingMap = gameState.Maps.First(m => m.Id == loadingMapId);
            }

            container.RegisterFactory(_ => new BuildingService(loadingMap.Buildings, gameSettings.BuildingsSettings, cmd)).AsSingle();
        }
    }
}