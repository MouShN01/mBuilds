using System;
using mBuildings.Scripts.Game.MVVM.UI;
using UnityEngine;
using UnityEngine.UI;

namespace mBuildings.Scripts.Game.Gameplay.View.UI.ScreenGameplay
{
    public class ScreenGameplayBinder:WindowBinder<ScreenGameplayViewModel>
    {
        [SerializeField] private Button _btnPopupA;
        [SerializeField] private Button _btnPopupB;
        [SerializeField] private Button _btnGoToMenu;
        private void OnEnable()
        {
            _btnPopupA?.onClick.AddListener(OnPopupAClicked);
            _btnPopupB?.onClick.AddListener(OnPopupBClicked);
            _btnGoToMenu?.onClick.AddListener(OnGoToMenuClicked);
        }

        private void OnDisable()
        {
            _btnPopupB?.onClick.RemoveListener(OnPopupBClicked);
            _btnPopupA?.onClick.RemoveListener(OnPopupAClicked);
            _btnGoToMenu?.onClick.RemoveListener(OnGoToMenuClicked);
        }

        private void OnGoToMenuClicked()
        {
            ViewModel.RequestGoToMainMenu();
        }

        private void OnPopupBClicked()
        {
            ViewModel.RequestOpenPopupB();
        }

        private void OnPopupAClicked()
        {
            ViewModel.RequestOpenPopupA();
        }
    }
}