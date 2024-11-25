using System;
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

        public Observable<GameplayExitParams> Run(UIRootView uiRoot, GameplayEnterParams enterParams)
        {
            var uiScene = Instantiate(_sceneUIRootPrefab);
            uiRoot.AttachSceneUI(uiScene.gameObject);

            var exitSceneSignalSubj = new Subject<Unit>();
            uiScene.Bind(exitSceneSignalSubj);
            
            Debug.Log($"GAMEPLAY ENTRY POINT: save file name = {enterParams.SaveFileName}, level to load = {enterParams.LevelNumber}");

            var mainMenuEnterParams = new MainMenuEnterParams("Complete");
            var exitParams = new GameplayExitParams(mainMenuEnterParams);
            var exitToMainMenuSceneSignal = exitSceneSignalSubj.Select(_ => exitParams);

            return exitToMainMenuSceneSignal;
        }
    }
}