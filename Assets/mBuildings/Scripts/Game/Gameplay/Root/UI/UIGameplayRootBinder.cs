using R3;
using UnityEngine;

namespace mBuildings.Scripts.Game.Gameplay.Root.UI
{
    public class UIGameplayRootBinder : MonoBehaviour
    {
        private Subject<Unit> _exitSceneSignalSubj;

        public void HandleGoToMainMenuButtonClicked()
        {
            _exitSceneSignalSubj?.OnNext(Unit.Default);
        }

        public void Bind(Subject<Unit> exitSceneSignalSubj)
        {
            _exitSceneSignalSubj = exitSceneSignalSubj;
        }
    }
}
