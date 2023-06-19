namespace Components
{
    public class HealthComponent
    {
        private int _maxHealth;
        private int _currentHealth;

        public HealthComponent(int maxHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = maxHealth;
        }

        public int GetMaxHealth() => _maxHealth;
        public int GetCurrentHealth() => _currentHealth;
        public void SetCurrentHealth(int newCurrentHealth) => _currentHealth = newCurrentHealth;
        public void SetMaxHealth(int newMaxHealth) => _maxHealth = newMaxHealth;
    }
}