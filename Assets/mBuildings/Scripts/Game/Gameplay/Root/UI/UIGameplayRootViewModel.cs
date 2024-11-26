using mBuildings.Scripts.Game.Gameplay.Services;

namespace mBuildings.Scripts.Game.Gameplay.Root.UI
{
    public class UIGameplayRootViewModel
    {
        private readonly SomeGameplayService _someGameplayService;

        public UIGameplayRootViewModel(SomeGameplayService someGameplayService)
        {
            _someGameplayService = someGameplayService;
        }
    }
}