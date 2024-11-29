using BaCon;
using mBuildings.Scripts.Game.Gameplay.Commands;
using mBuildings.Scripts.Game.Gameplay.Root.UI;
using mBuildings.Scripts.Game.GameRoot;
using mBuildings.Scripts.Game.MainMenu.Root;
using mBuildings.Scripts.Game.State;
using mBuildings.Scripts.Game.State.cmd;
using ObservableCollections;
using R3;
using UnityEditor;
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
            
            var gameStateProvider = gameplayContainer.Resolve<IGameStateProvider>();
            
            //

            gameStateProvider.GameState.Buildings.ObserveAdd().Subscribe(e =>
            {
                var building = e.Value;
                Debug.Log($"Building placed. Type id: {building.TypeId}; Id: {building.Id}; Position: {building.Position}");
            });
            
            //
            
            var cmd = new CommandProcessor(gameStateProvider);
            
            cmd.RegisterHandler(new CmdPlaceBuildingHandler(gameStateProvider.GameState));
            
            //

            cmd.Process(new CmdPlaceBuilding("Hospital", GetRandomPosition()));
            cmd.Process(new CmdPlaceBuilding("Armory", GetRandomPosition()));
            cmd.Process(new CmdPlaceBuilding("House", GetRandomPosition()));
            
            
            //
            
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

        private Vector3Int GetRandomPosition()
        {
            var rX = Random.Range(-10, 10);
            var rY = Random.Range(-10, 10);
            var rPosition = new Vector3Int(rX, rY, 0);

            return rPosition;
        }
    }
}