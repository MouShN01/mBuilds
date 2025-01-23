using mBuildings.Scripts.Game.State.cmd;
using mBuildings.Scripts.Game.State.GameResources;

namespace mBuildings.Scripts.Game.Gameplay.Commands
{
    public class CmdSpendResource : ICommand
    {
        public ResourceType ResourceType;
        public int Amount;

        public CmdSpendResource(ResourceType resourceType, int amount)
        {
            ResourceType = resourceType;
            Amount = amount;
        }
    }
}