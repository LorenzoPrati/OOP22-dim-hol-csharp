namespace Components
{
    public class CoinPocketComponent : IComponent
    {
        public int Coins { get; set; }

        public HealthComponent(int newAmount)
        {
            Coins = newAmount;
        }
    }
}