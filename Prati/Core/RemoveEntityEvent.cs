using Entity;
using Components;

namespace Core
{
    public class RemoveEntityEvent : IWorldEvent
    {
        private readonly Guid _id;

        public RemoveEntityEvent(IEntity entity)
        {
            _id = entity.Id;
        }

        public void Execute(IWorld world)
        {
            foreach (var e in world.Entities)
            {
                if (e.Id.Equals(_id))
                {
                    if (e.HasComponent(typeof(PlayerComponent)))
                    {
                        world.Win = false;
                    }
                    if (e.HasComponent(typeof(BossComponent)))
                    {
                        world.Win = true;
                    }
                    world.RemoveEntity(e);
                }
            }
        }
    }

}