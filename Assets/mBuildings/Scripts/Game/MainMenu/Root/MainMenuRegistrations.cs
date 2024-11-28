using BaCon;
using mBuildings.Scripts.Game.GameRoot.Services;
using mBuildings.Scripts.Game.MainMenu.Services;

namespace mBuildings.Scripts.Game.MainMenu.Root
{
    public static class MainMenuRegistrations
    {
        public static void Register(DIContainer container, MainMenuEnterParams mainMenuEnterParams)
        {
            container.RegisterFactory(c => new SomeMainMenuService(c.Resolve<SomeProjectService>())).AsSingle();
        }
    }
}