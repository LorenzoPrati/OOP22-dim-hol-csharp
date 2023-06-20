using Components;

namespace MyComponents
{
    public class CoinPocketComponent : IComponent
    {
        public int Coins { get; set; }

        public CoinPocketComponent(int newAmount)
        {
            Coins = newAmount;
        }
    }
}