using R3;
using UnityEngine;

namespace mBuildings.Scripts.Game.MainMenu.Root.UI
{
    public class UIMainMenuRootBinder : MonoBehaviour
    {
        private Subject<Unit> _exitSceneSignalSubj;
        
        public void HandleGoToGameplayButtonClicked()
        {
            _exitSceneSignalSubj?.OnNext(Unit.Default); // Send signal
        }

        public void Bind(Subject<Unit> exitSceneSignalSubj)
        {
            _exitSceneSignalSubj = exitSceneSignalSubj;
        }
    }
}