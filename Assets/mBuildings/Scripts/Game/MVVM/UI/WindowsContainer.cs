using System.Collections.Generic;
using UnityEngine;

namespace mBuildings.Scripts.Game.MVVM.UI
{
    public class WindowsContainer : MonoBehaviour
    {
        [SerializeField] private Transform _screensContainer;
        [SerializeField] private Transform _popupsContainer;

        private Dictionary<WindowViewModel, IWindowBinder> _openedPopupsBinders = new();
        private IWindowBinder _openedScreenBinder;

        public void OpenPopup(WindowViewModel viewModel)
        {
            var prefabPath = GetPrefabPath(viewModel);
            var prefab = Resources.Load<GameObject>(prefabPath);
            var createdPopup = Instantiate(prefab, _popupsContainer);
            var binder = createdPopup.GetComponent<IWindowBinder>();
            
            binder.Bind(viewModel);
            _openedPopupsBinders.Add(viewModel, binder);
        }

        public void ClosePopup(WindowViewModel viewModel)
        {
            var binder = _openedPopupsBinders[viewModel];
            binder?.Close();
            
            _openedPopupsBinders.Remove(viewModel);
        }

        public void OpenScreen(WindowViewModel viewModel)
        {
            if (viewModel == null)
            {
                return;
            }
            
            _openedScreenBinder?.Close();
            
            var openedPath = GetPrefabPath(viewModel);
            var prefab = Resources.Load<GameObject>(openedPath);
            var createdScreen = Instantiate(prefab, _screensContainer);
            var binder = createdScreen.GetComponent<IWindowBinder>();
            
            binder.Bind(viewModel);
            _openedScreenBinder = binder;
        }

        private string GetPrefabPath(WindowViewModel viewModel)
        {
            return $"Prefabs/UI/{viewModel.Id}";
        }
    }
}