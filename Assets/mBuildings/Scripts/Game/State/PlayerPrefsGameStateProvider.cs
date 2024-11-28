using System.Collections.Generic;
using mBuildings.Scripts.Game.State.Buildings;
using mBuildings.Scripts.Game.State.Root;
using R3;
using UnityEngine;

namespace mBuildings.Scripts.Game.State
{
    public class PlayerPrefsGameStateProvider : IGameStateProvider
    {
        private const string GAME_STATE_KEY = nameof(GAME_STATE_KEY);
        private const string GAME_SETTINGS_STATE_KEY = nameof(GAME_SETTINGS_STATE_KEY);
        
        public GameStateProxy GameState { get; private set; }
        public GameSettingStateProxy GameSettingsState { get; private set; }

        private GameState _gameStateOrigin;
        private GameSettingsState _gameSettingsStateOrigin;
        
        public Observable<GameStateProxy> LoadGameState()
        {
            if (!PlayerPrefs.HasKey(GAME_STATE_KEY))
            {
                GameState = CreateGameStateFromSettings();
                Debug.Log("Game State created from settings: " + JsonUtility.ToJson(_gameStateOrigin, true));

                SaveGameState();
            }
            else
            {
                var json = PlayerPrefs.GetString(GAME_STATE_KEY);
                _gameStateOrigin = JsonUtility.FromJson<GameState>(json);
                GameState = new GameStateProxy(_gameStateOrigin);
                
                Debug.Log("Game State loaded: " + json);
            }

            return Observable.Return(GameState);
        }

        public Observable<GameSettingStateProxy> LoadGameSettingsState()
        {
            if (!PlayerPrefs.HasKey(GAME_SETTINGS_STATE_KEY))
            {
                GameSettingsState = CreateGameSettingsStateFromSettings();
                Debug.Log("Game Setting State created from settings: " + JsonUtility.ToJson(_gameSettingsStateOrigin, true));

                SaveGameSettingsState();
            }
            else
            {
                var json = PlayerPrefs.GetString(GAME_SETTINGS_STATE_KEY);
                _gameSettingsStateOrigin = JsonUtility.FromJson<GameSettingsState>(json);
                GameSettingsState = new GameSettingStateProxy(_gameSettingsStateOrigin);
                
                Debug.Log("Game Settings State loaded: " + json);
            }

            return Observable.Return(GameSettingsState);
        }

        public Observable<bool> SaveGameState()
        {
            var json = JsonUtility.ToJson(_gameStateOrigin, true);
            PlayerPrefs.SetString(GAME_STATE_KEY, json);

            return Observable.Return(true);
        }

        public Observable<bool> SaveGameSettingsState()
        {
            var json = JsonUtility.ToJson(_gameSettingsStateOrigin, true);
            PlayerPrefs.SetString(GAME_SETTINGS_STATE_KEY, json);
            
            return Observable.Return(true);
        }

        public Observable<bool> ResetGameState()
        {
            GameState = CreateGameStateFromSettings();
            SaveGameState();

            return Observable.Return(true);
        }

        public Observable<bool> ResetGameSettingsState()
        {
            GameSettingsState = CreateGameSettingsStateFromSettings();
            SaveGameSettingsState();

            return Observable.Return(true);
        }

        private GameStateProxy CreateGameStateFromSettings()
        {
            _gameStateOrigin = new GameState
            {
                Buildings = new List<BuildingEntity>
                {
                    new()
                    {
                        TypeId = "PRO100"
                    },
                    new()
                    {
                        TypeId = "STARIK"
                    }
                }
            };
            return new GameStateProxy(_gameStateOrigin);
        }
        
        private GameSettingStateProxy CreateGameSettingsStateFromSettings()
        {
            _gameSettingsStateOrigin = new GameSettingsState
            {
                MusicVolume = 8,
                SFXVolume = 8
            };
            return new GameSettingStateProxy(_gameSettingsStateOrigin);
        }
    }
}