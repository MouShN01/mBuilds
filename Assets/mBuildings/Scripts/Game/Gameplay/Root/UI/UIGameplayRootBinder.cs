using System;
using UnityEngine;

namespace mBuildings.Scripts.Game.Gameplay.Root.UI
{
    public class UIGameplayRootBinder : MonoBehaviour
    {
        public event Action GoToMainMenuButtonClicked;

        public void HandleGoToMainMenuButtonClicked()
        {
            GoToMainMenuButtonClicked?.Invoke();
        }
    }
}
