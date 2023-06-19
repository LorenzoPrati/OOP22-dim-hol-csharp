using Components;

namespace Entity
{
    public class EntityImpl : IEntity
    {

        private readonly ISet<IComponent> _components;
        private readonly Guid _id;
        public ISet<IComponent> Components
        {
            get { return new HashSet<IComponent>(_components); }
        }

        public EntityImpl(ISet<IComponent> components)
        {
            _components = new HashSet<IComponent>(components);
            _id = System.Guid.NewGuid();
        }

        public void AddComponent(IComponent component)
        {
            _components.Add(component);
        }

        public void RemoveComponent(IComponent component)
        {
            _components.Remove(component);
        }

        public IComponent GetComponent(Type compType)
        {
            return null;
        }

        public bool HasComponent(Type compType)
        {
            return false;
        }

        public bool HasFamily(ISet<Type> family)
        {
            return family.IsSubsetOf(_components);
        }
        
    }
}