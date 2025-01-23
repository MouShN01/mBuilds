using System.Linq;
using mBuildings.Scripts.Game.State.cmd;
using mBuildings.Scripts.Game.State.GameResources;
using mBuildings.Scripts.Game.State.Root;

namespace mBuildings.Scripts.Game.Gameplay.Commands
{
    public class CmdAddResourceHandler : ICommandHandler<CmdAddResource>
    {
        private readonly GameStateProxy _gameState;

        public CmdAddResourceHandler(GameStateProxy gameState)
        {
            _gameState = gameState;
        }
        
        public bool Handle(CmdAddResource command)
        {
            var requiredResourceType = command.ResourceType;
            var requiredResource = _gameState.Resources.FirstOrDefault(r => r.ResourceType == requiredResourceType);
            if (requiredResource == null)
            {
                requiredResource = CreateNewResource(requiredResourceType);
            }
            
            requiredResource.Amount.Value += command.Amount;
            
            return true;
        }

        private Resource CreateNewResource(ResourceType requiredResourceType)
        {
            var newResourceData = new ResourceData
            {
                ResourceType = requiredResourceType,
                Amount = 0
            };
            
            var newResource = new Resource(newResourceData);
            _gameState.Resources.Add(newResource);
            
            return newResource;
        }
    }
}