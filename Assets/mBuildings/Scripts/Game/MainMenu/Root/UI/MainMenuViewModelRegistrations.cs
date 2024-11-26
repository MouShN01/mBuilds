using BaCon;

namespace mBuildings.Scripts.Game.MainMenu.Root.UI
{
    public static class MainMenuViewModelRegistrations
    {
        public static void Register(DIContainer container)
        {
            container.RegisterFactory(c => new UIMainMenuRootViewModel()).AsSingle();
        }
    }
}