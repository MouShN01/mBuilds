using BaCon;

namespace mBuildings.Scripts.Game.Gameplay.Root.UI
{
    public static class GameplayViewModelRegistrations
    {
        public static void Register(DIContainer container)
        {
            container.RegisterFactory(c => new UIGameplayRootViewModel()).AsSingle();
            container.RegisterFactory(c => new WorldGameplayRootViewModel()).AsSingle();
        }
    }
}