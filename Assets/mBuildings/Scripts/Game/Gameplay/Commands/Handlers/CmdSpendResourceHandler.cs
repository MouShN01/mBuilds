using System.Linq;
using mBuildings.Scripts.Game.State.cmd;
using mBuildings.Scripts.Game.State.Root;
using UnityEngine;

namespace mBuildings.Scripts.Game.Gameplay.Commands
{
    public class CmdSpendResourceHandler : ICommandHandler<CmdSpendResource>
    {
        private readonly GameStateProxy _gameState;

        public CmdSpendResourceHandler(GameStateProxy gameState)
        {
            _gameState = gameState;
        }
        
        public bool Handle(CmdSpendResource command)
        {
            var requiredResourceType = command.ResourceType;
            var requiredResource = _gameState.Resources.FirstOrDefault(r => r.ResourceType == requiredResourceType);
            
            if (requiredResource == null)
            {
                Debug.Log($"Resource of type {requiredResourceType} cant be removed, because it doesn't exist");
                return false;
            }

            if (requiredResource.Amount.Value < command.Amount)
            {
                Debug.Log($"Cannot spend resource {requiredResourceType} because it is out of range");
                return false;
            }
            
            requiredResource.Amount.Value -= command.Amount;
            
            return true;
        }
    }
}