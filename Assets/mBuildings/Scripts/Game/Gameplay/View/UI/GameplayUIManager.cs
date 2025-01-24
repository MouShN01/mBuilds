using BaCon;
using mBuildings.Scripts.Game.Common;
using mBuildings.Scripts.Game.Gameplay.View.UI.PopupA;
using mBuildings.Scripts.Game.Gameplay.View.UI.PopupB;
using mBuildings.Scripts.Game.Gameplay.View.UI.ScreenGameplay;
using mBuildings.Scripts.Game.MVVM.UI;
using R3;

namespace mBuildings.Scripts.Game.Gameplay.View.UI
{
    public class GameplayUIManager:UIManager
    {
        private readonly Subject<Unit> _exitSceneRequest;

        public GameplayUIManager(DIContainer container) : base(container)
        {
            _exitSceneRequest = container.Resolve<Subject<Unit>>(AppConstants.EXIT_SCENE_REQUEST_TAG);
        }

        public ScreenGameplayViewModel OpenScreenGameplay()
        {
            var viewModel = new ScreenGameplayViewModel(this, _exitSceneRequest);
            var rootUI = Container.Resolve<UIGameplayRootViewModel>();
            
            rootUI.OpenScreen(viewModel);

            return viewModel;
        }

        public PopupAViewModel OpenPopupA()
        {
            var a = new PopupAViewModel();
            var rootUI = Container.Resolve<UIGameplayRootViewModel>();
            
            rootUI.OpenPopup(a);
            return a;
        }
        
        public PopupBViewModel OpenPopupB()
        {
            var b = new PopupBViewModel();
            var rootUI = Container.Resolve<UIGameplayRootViewModel>();
            
            rootUI.OpenPopup(b);
            return b;
        }
    }
}