using System;
using System.Linq;
using mBuildings.Scripts.Game.GameRoot.Services;
using mBuildings.Scripts.Game.State.Buildings;
using mBuildings.Scripts.Game.State.Root;
using ObservableCollections;
using R3;
using UnityEngine;

namespace mBuildings.Scripts.Game.Gameplay.Services
{
    public class SomeGameplayService : IDisposable
    {
        private readonly GameStateProxy _gameState;
        private readonly SomeProjectService _someProjectService;

        public SomeGameplayService(GameStateProxy gameState, SomeProjectService someProjectService)
        {
            _gameState = gameState;
            _someProjectService = someProjectService;
            Debug.Log(GetType().Name + "has been created");
            
            gameState.Buildings.ForEach(b=>Debug.Log($"Building: {b.TypeId}"));
            gameState.Buildings.ObserveAdd().Subscribe(e => Debug.Log($"Building added: {e.Value.TypeId}"));
            gameState.Buildings.ObserveRemove().Subscribe(e => Debug.Log($"Building removed: {e.Value.TypeId}"));
            
            AddBuilding("Tower");
            AddBuilding("Armory");
            AddBuilding("Hospital");
            
            RemoveBuilding("Hospital");
        }

        public void Dispose()
        {
            Debug.Log("Calculate all subscriptions");
        }

        private void AddBuilding(string buildingTypeId)
        {
            var building = new BuildingEntity
            {
                TypeId = buildingTypeId
            };
            var buildingProxy = new BuildingEntityProxy(building);
            _gameState.Buildings.Add(buildingProxy);
        }

        private void RemoveBuilding(string buildingTypeId)
        {
            var buildingEntity = _gameState.Buildings.FirstOrDefault(b => b.TypeId == buildingTypeId);

            if (buildingEntity != null)
            {
                _gameState.Buildings.Remove(buildingEntity);
            }
        }
    }
}