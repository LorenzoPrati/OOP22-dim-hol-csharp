using Components;

namespace Entity
{
    public class EntityBuilder
    {
        private readonly ISet<IComponent> _components;

        public EntityBuilder()
        {
            _components = new HashSet<IComponent>();
        }

        public EntityBuilder Add(IComponent component)
        {
            _components.Add(component);
            return this;
        }

        public IEntity Build() => new EntityImpl(_components);
        
    }
}