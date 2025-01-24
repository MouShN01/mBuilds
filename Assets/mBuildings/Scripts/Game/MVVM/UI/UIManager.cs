using BaCon;

namespace mBuildings.Scripts.Game.MVVM.UI
{
    public abstract class UIManager
    {
        protected readonly DIContainer Container;

        public UIManager(DIContainer container)
        {
            Container = container;
        }
    }
}