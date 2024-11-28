using mBuildings.Scripts.Game.State.Root;
using R3;

namespace mBuildings.Scripts.Game.State
{
    public interface IGameStateProvider
    {
        public GameStateProxy GameState { get; }
        public GameSettingStateProxy GameSettingsState { get; }

        public Observable<GameStateProxy> LoadGameState();
        public Observable<GameSettingStateProxy> LoadGameSettingsState();
        public Observable<bool> SaveGameState();
        public Observable<bool> SaveGameSettingsState();
        public Observable<bool> ResetGameState();
        public Observable<bool> ResetGameSettingsState();
    }
}