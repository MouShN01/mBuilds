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
            container.RegisterInstance<ICommandProcessor>(cmd);
            
            container.RegisterFactory(_ => new BuildingService(gameState.Buildings, gameSettings.BuildingsSettings, cmd)).AsSingle();
        }
    }
}