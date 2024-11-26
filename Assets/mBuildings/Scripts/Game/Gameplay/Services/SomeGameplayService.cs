using System;
using mBuildings.Scripts.Game.GameRoot.Services;
using UnityEngine;

namespace mBuildings.Scripts.Game.Gameplay.Services
{
    public class SomeGameplayService : IDisposable
    {
        private readonly SomeProjectService _someProjectService;

        public SomeGameplayService(SomeProjectService someProjectService)
        {
            _someProjectService = someProjectService;
            Debug.Log(GetType().Name + "has been created");
        }

        public void Dispose()
        {
            Debug.Log("Calculate all subscriptions");
        }
    }
}