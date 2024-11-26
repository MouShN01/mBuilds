using System;
using BaCon;
using mBuildings.Scripts.Game.Gameplay.Root.UI;
using mBuildings.Scripts.Game.GameRoot;
using mBuildings.Scripts.Game.MainMenu.Root;
using R3;
using UnityEngine;

namespace mBuildings.Scripts.Game.Gameplay.Root
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private UIGameplayRootBinder _sceneUIRootPrefab;

        public Observable<GameplayExitParams> Run(DIContainer gameplayContainer, GameplayEnterParams enterParams)
        {
            GameplayRegistrations.Register(gameplayContainer, enterParams);
            var gameplayViewModelContainer = new DIContainer(gameplayContainer);
            GameplayViewModelRegistrations.Register(gameplayViewModelContainer);
            
            //For test
            gameplayViewModelContainer.Resolve<UIGameplayRootViewModel>();
            gameplayViewModelContainer.Resolve<WorldGameplayRootViewModel>();
            
            var uiRoot = gameplayContainer.Resolve<UIRootView>();
            var uiScene = Instantiate(_sceneUIRootPrefab);
            uiRoot.AttachSceneUI(uiScene.gameObject);

            var exitSceneSignalSubj = new Subject<Unit>(); // subject that will be send to UIGameplay
            uiScene.Bind(exitSceneSignalSubj);
            
            Debug.Log($"GAMEPLAY ENTRY POINT: save file name = {enterParams.SaveFileName}, level to load = {enterParams.LevelNumber}");

            var mainMenuEnterParams = new MainMenuEnterParams("Complete");
            var exitParams = new GameplayExitParams(mainMenuEnterParams);
            var exitToMainMenuSceneSignal = exitSceneSignalSubj.Select(_ => exitParams);

            return exitToMainMenuSceneSignal;
        }
    }
}