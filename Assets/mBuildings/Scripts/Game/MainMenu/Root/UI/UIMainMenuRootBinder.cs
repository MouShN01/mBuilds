using System;
using UnityEngine;

namespace mBuildings.Scripts.Game.MainMenu.Root.UI
{
    public class UIMainMenuRootBinder : MonoBehaviour
    {
        public event Action GoToGameplayButtonClicked;

        public void HandleGoToGameplayButtonClicked()
        {
            GoToGameplayButtonClicked?.Invoke();
        }
    }
}