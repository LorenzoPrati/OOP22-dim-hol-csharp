using Components;

namespace Entity
{
    public interface IEntity
    {
        Guid Id { get; }
        
        ISet<IComponent> Components { get; }

        void AddComponent(IComponent component);

        void RemoveComponent(IComponent component);

        IComponent GetComponent(Type compType);

        bool HasComponent(Type compType);

        bool HasFamily(ISet<Type> family);
    }
}
