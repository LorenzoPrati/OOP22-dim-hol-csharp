using Entity;

namespace Core
{
    public class AddEntityEvent : IWorldEvent
    {
        private readonly IEntity _entity;

        public AddEntityEvent(IEntity entity)
        {
            _entity = new EntityImpl(entity);
        }

        public void Execute(IWorld world)
        {
            world.AddEntity(_entity);
        }
    }
}