using Entity;
using Components;

namespace MyComponents
{
    public class ItemComponent : IComponent
    {
        private Func<IEntity, List<Type>, Boolean> _effect; 

        public ItemComponent(Func<IEntity, List<Type>, Boolean> effect)
        {
            _effect = effect;
        }

        public bool ApplyEffect(IEntity entity, List<Type> components)
        {
            return _effect(entity, components);
        }
    }
}