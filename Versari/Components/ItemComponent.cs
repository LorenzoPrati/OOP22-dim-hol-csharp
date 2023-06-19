namespace Components
{
    public class ItemComponent
    {
        private Func<Entity, List<Type<IEnumerable<Components>>>, Boolean> effect; 

        public ItemComponent(Func<Entity, List<IEnumerable<Components>>, Boolean> effect)
        {
            _effect = effect;
        }

        public Boolean ApplyEffect(Entity entity, List<Type<IEnumerable<Components>>> components)
        {
            return _effect(entity, components);
        }
    }
}