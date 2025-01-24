namespace mBuildings.Scripts.Game.MVVM.UI
{
    public interface IWindowBinder
    {
        void Bind(WindowViewModel viewModel);
        void Close();
    }
}