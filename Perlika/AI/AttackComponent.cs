using Entity;

namespace AI;

public class AttackComponent
{
    private readonly int _damage;
    private readonly Predicate<IEntity> _predicate;
    
    public AttackComponent(int damage, Predicate<IEntity> predicate) {
        _damage = damage;
        _predicate = predicate;
    }
    
    public int GetDamage() => _damage;
    
    public Predicate<IEntity> GetPredicate() => _predicate;
}