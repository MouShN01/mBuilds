using BaCon;
using mBuildings.Scripts.Game.Gameplay.Services;

namespace mBuildings.Scripts.Game.Gameplay.Root.UI
{
    public static class GameplayViewModelRegistrations
    {
        public static void Register(DIContainer container)
        {
            container.RegisterFactory(c => new UIGameplayRootViewModel()).AsSingle();
            container.RegisterFactory(c => new WorldGameplayRootViewModel(c.Resolve<BuildingService>())).AsSingle();
        }
    }
}