using System;
using System.Collections.Generic;
using mBuildings.Scripts.Game.Gameplay.Commands;
using mBuildings.Scripts.Game.Gameplay.View.GameResources;
using mBuildings.Scripts.Game.State.cmd;
using mBuildings.Scripts.Game.State.GameResources;
using ObservableCollections;
using R3;

namespace mBuildings.Scripts.Game.Gameplay.Services
{
    public class ResourceService
    {
        public readonly ObservableList<ResourceViewModel> Resources = new ();
        
        private readonly Dictionary<ResourceType, ResourceViewModel> _resourcesMap = new();
        private readonly ICommandProcessor _cmd;

        public ResourceService(ObservableList<Resource> resources, ICommandProcessor cmd)
        {
            _cmd = cmd;
            
            resources.ForEach(CreateResourceViewModel);
            resources.ObserveAdd().Subscribe(e => CreateResourceViewModel(e.Value));
            resources.ObserveRemove().Subscribe(e=>RemoveResourceViewModel(e.Value));
        }

        public bool AddResource(ResourceType resourceType, int amount)
        {
            var command = new CmdAddResource(resourceType, amount);
            
            return _cmd.Process(command);
        }
        
        public bool TrySpendResource(ResourceType resourceType, int amount)
        {
            var command = new CmdSpendResource(resourceType, amount);
            
            return _cmd.Process(command);
        }

        public bool IsEnoughResources(ResourceType resourceType, int amount)
        {
            if (_resourcesMap.TryGetValue(resourceType, out var resourceViewModel))
            {
                return resourceViewModel.Amount.CurrentValue >= amount;
            }
            return false;
        }

        public Observable<int> ObserveResource(ResourceType resourceType)
        {
            if (_resourcesMap.TryGetValue(resourceType, out var resourceViewModel))
            {
                return resourceViewModel.Amount;
            }
            throw new Exception($"Resource of type {resourceType} doesn't exist");
        }

        private void CreateResourceViewModel(Resource resource)
        {
            var resourceViewModel = new ResourceViewModel(resource);
            _resourcesMap[resource.ResourceType] = resourceViewModel;
            
            Resources.Add(resourceViewModel);
        }
        
        private void RemoveResourceViewModel(Resource resource)
        {
            if (_resourcesMap.TryGetValue(resource.ResourceType, out var resourceViewModel))
            {
                Resources.Remove(resourceViewModel);
                _resourcesMap.Remove(resource.ResourceType);
            }
        }
    }
}