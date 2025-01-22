using BaCon;
using mBuildings.Scripts.Game.Gameplay.Root;
using mBuildings.Scripts.Game.GameRoot;
using mBuildings.Scripts.Game.MainMenu.Root.UI;
using R3;
using UnityEngine;
using Random = UnityEngine.Random;

namespace mBuildings.Scripts.Game.MainMenu.Root
{
    public class MainMenuEntryPoint : MonoBehaviour
    {
        [SerializeField] private UIMainMenuRootBinder _sceneUIRootPrefab;

        public Observable<MainMenuExitParams> Run(DIContainer mainMenuContainer, MainMenuEnterParams enterParams)
        {
            MainMenuRegistrations.Register(mainMenuContainer, enterParams);
            var mainMenuViewModelContainer = new DIContainer(mainMenuContainer);
            MainMenuViewModelRegistrations.Register(mainMenuViewModelContainer);
            
            //For test
            mainMenuViewModelContainer.Resolve<UIMainMenuRootViewModel>();
            
            var uiRoot = mainMenuContainer.Resolve<UIRootView>();
            var uiScene = Instantiate(_sceneUIRootPrefab);
            uiRoot.AttachSceneUI(uiScene.gameObject);

            var exitSignalSubj = new Subject<Unit>(); // subject that will be send to UIMainMenu
            uiScene.Bind(exitSignalSubj);
            
            Debug.Log($"MAIN MENU ENTRY POINT: Run main menu scene. Results: {enterParams?.Result}");

            var saveFileName = "save1.save";
            var levelNumber = Random.Range(0, 300);
            var gameplayEnterParams = new GameplayEnterParams(0);
            var mainMenuExitParams = new MainMenuExitParams(gameplayEnterParams);
            var exitToGameplaySceneSignal = exitSignalSubj.Select(_=>mainMenuExitParams);

            return exitToGameplaySceneSignal;
        }
    }
}