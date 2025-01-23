using System;
using mBuildings.Scripts.Game.Gameplay.Services;
using mBuildings.Scripts.Game.Gameplay.View.Buildings;
using mBuildings.Scripts.Game.State.GameResources;
using ObservableCollections;
using R3;
using UnityEngine;
using Random = UnityEngine.Random;

namespace mBuildings.Scripts.Game.Gameplay.Root.UI
{
    public class WorldGameplayRootViewModel
    {
        private readonly ResourceService _resourceService;
        public readonly IObservableCollection<BuildingViewModel> AllBuildings;

        public WorldGameplayRootViewModel(BuildingService buildingService, ResourceService resourceService)
        {
            _resourceService = resourceService;
            AllBuildings = buildingService.AllBuildings;
            
            resourceService.ObserveResource(ResourceType.SoftCurrency).Subscribe(newValue => Debug.Log($"SoftCurrency: {newValue}"));
            resourceService.ObserveResource(ResourceType.HardCurrency).Subscribe(newValue => Debug.Log($"HardCurrency: {newValue}"));
        }

        public void HandleTestInput()
        {
            var rResourceType = (ResourceType)Random.Range(0, Enum.GetValues(typeof(ResourceType)).Length);
            var rValue = Random.Range(0, 1000);
            var rOperation = Random.Range(0, 2);

            if (rOperation == 0)
            {
                _resourceService.AddResource(rResourceType, rValue);
                return;
            }
            
            _resourceService.TrySpendResource(rResourceType, rValue);
        }
    }
}