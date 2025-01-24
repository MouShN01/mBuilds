using BaCon;
using mBuildings.Scripts.Game.Common;
using mBuildings.Scripts.Game.Gameplay.Root.UI;
using mBuildings.Scripts.Game.Gameplay.View.UI;
using mBuildings.Scripts.Game.GameRoot;
using mBuildings.Scripts.Game.MainMenu.Root;
using mBuildings.Scripts.Game.MVVM.UI;
using R3;
using UnityEngine;

namespace mBuildings.Scripts.Game.Gameplay.Root
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private UIGameplayRootBinder _sceneUIRootPrefab;
        [SerializeField] private WorldGameplayRootBinder _worldRootBinder;
 
        public Observable<GameplayExitParams> Run(DIContainer gameplayContainer, GameplayEnterParams enterParams)
        {
            GameplayRegistrations.Register(gameplayContainer, enterParams);
            var gameplayViewModelContainer = new DIContainer(gameplayContainer);
            GameplayViewModelRegistrations.Register(gameplayViewModelContainer);
            
            //For test
            InitWorld(gameplayViewModelContainer);
            InitUI(gameplayViewModelContainer);
            
            gameplayViewModelContainer.Resolve<UIGameplayRootViewModel>();

            var exitSceneSignalSubj = new Subject<Unit>(); // subject that will be send to UIGameplay
            
            Debug.Log($"GAMEPLAY ENTRY POINT: level to load = {enterParams.MapId}");

            var mainMenuEnterParams = new MainMenuEnterParams("Complete");
            var exitParams = new GameplayExitParams(mainMenuEnterParams);
            var exitSceneRequest = gameplayContainer.Resolve<Subject<Unit>>(AppConstants.EXIT_SCENE_REQUEST_TAG);
            var exitToMainMenuSceneSignal = exitSceneRequest.Select(_ => exitParams);

            return exitToMainMenuSceneSignal;
        }

        private void InitWorld(DIContainer viewsContainer)
        {
            _worldRootBinder.Bind(viewsContainer.Resolve<WorldGameplayRootViewModel>());
        }

        private void InitUI(DIContainer viewsContainer)
        {
            var uiRoot = viewsContainer.Resolve<UIRootView>();
            var uiSceneBootBinder = Instantiate(_sceneUIRootPrefab);
            uiRoot.AttachSceneUI(uiSceneBootBinder.gameObject);

            var uiSceneRootViewModel = viewsContainer.Resolve<UIGameplayRootViewModel>();
            uiSceneBootBinder.Bind(uiSceneRootViewModel);
            
            var uiManager = viewsContainer.Resolve<GameplayUIManager>();
            uiManager.OpenScreenGameplay();
        }
    }
}