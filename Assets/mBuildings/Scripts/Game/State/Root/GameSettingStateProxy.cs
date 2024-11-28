using R3;

namespace mBuildings.Scripts.Game.State.Root
{
    public class GameSettingStateProxy
    {
        public ReactiveProperty<int> MusicVolume;
        public ReactiveProperty<int> SFXVolume;

        public GameSettingStateProxy(GameSettingsState gameSettingsState)
        {
            MusicVolume = new ReactiveProperty<int>(gameSettingsState.MusicVolume);
            SFXVolume = new ReactiveProperty<int>(gameSettingsState.SFXVolume);

            MusicVolume.Skip(1).Subscribe(value => gameSettingsState.MusicVolume = value);
            SFXVolume.Skip(1).Subscribe(value => gameSettingsState.SFXVolume = value);
        }
    }
}