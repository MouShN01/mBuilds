using BaCon;
using mBuildings.Scripts.Game.Gameplay.Services;
using mBuildings.Scripts.Game.Gameplay.View.UI;

namespace mBuildings.Scripts.Game.Gameplay.Root.UI
{
    public static class GameplayViewModelRegistrations
    {
        public static void Register(DIContainer container)
        {
            container.RegisterFactory(c => new GameplayUIManager(container)).AsSingle();
            container.RegisterFactory(c => new UIGameplayRootViewModel()).AsSingle();
            container.RegisterFactory(c => new WorldGameplayRootViewModel(c.Resolve<BuildingService>(), c.Resolve<ResourceService>())).AsSingle();
        }
    }
}