using Components;

namespace Entity
{
    public class EntityImpl : IEntity
    {

        private readonly ISet<IComponent> _components;
        public Guid Id { get; private set; }
        public ISet<IComponent> Components
        {
            get { return new HashSet<IComponent>(_components); }
        }

        public EntityImpl(ISet<IComponent> components)
        {
            _components = new HashSet<IComponent>(components);
            Id = System.Guid.NewGuid();
        }

        public EntityImpl(IEntity other)
        {
            _components = other.Components;
            Id = other.Id;
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
            return _components.First(c => c.GetType().Equals(compType));
        }

        public bool HasComponent(Type compType)
        {
            return _components.Any(c => c.GetType().Equals(compType));
        }

        public bool HasFamily(ISet<Type> family)
        {
            return _components.Where(c => family.Contains(c.GetType()))
                    .Count()
                    .Equals(family.Count);
        }
    }
}