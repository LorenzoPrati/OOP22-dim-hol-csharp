using Components;
namespace MyComponents
{
    public class HealthComponent : IComponent
    {
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }

        public HealthComponent(int maxHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
        }
    }
}