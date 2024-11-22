using UnityEngine;

namespace mBuildings.Scripts.Game.Gameplay
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private GameObject _sceneBootBinder;

        public void Run()
        {
            Debug.Log("Gameplay scene loaded.");
        }
    }
}