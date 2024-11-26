using System;
using mBuildings.Scripts.Game.GameRoot.Services;
using UnityEngine;

namespace mBuildings.Scripts.Game.MainMenu.Root.Services
{
    public class SomeMainMenuService : IDisposable
    {
        private readonly SomeProjectService _someProjectService;

        public SomeMainMenuService(SomeProjectService someProjectService)
        {
            _someProjectService = someProjectService;
            Debug.Log(GetType().Name + "has been created");
        }

        public void Dispose()
        {
            Debug.Log("Delete subscriptions");
        }
    }
}