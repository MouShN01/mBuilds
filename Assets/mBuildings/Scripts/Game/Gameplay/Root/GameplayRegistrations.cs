using BaCon;
using mBuildings.Scripts.Game.Gameplay.Services;
using mBuildings.Scripts.Game.GameRoot.Services;

namespace mBuildings.Scripts.Game.Gameplay.Root
{
    public static class GameplayRegistrations
    {
        public static void Register(DIContainer container, GameplayEnterParams gameplayEnterParams)
        {
            container.RegisterFactory(c => new SomeGameplayService(c.Resolve<SomeProjectService>())).AsSingle();
        }
    }
}