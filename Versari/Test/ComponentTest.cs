using MyComponents;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test;
[TestClass]
public class ComponentTest
{
    private static int MaxHealth = 10;
    private static int NewMaxHealth = 20;
    private static int NewCurrentHealth = 8;
    private static int InitialCoinAmount = 30;
    private static int NewCoinAmount = 25;
    
    [TestMethod]
    public void HealthComponentTest()
    {
        var healthComp = new HealthComponent(MaxHealth);
        Assert.AreEqual(healthComp.CurrentHealth, MaxHealth);
        Assert.AreEqual(healthComp.MaxHealth, MaxHealth);
        healthComp.MaxHealth = NewMaxHealth;
        Assert.AreEqual(healthComp.MaxHealth, NewMaxHealth);
        healthComp.CurrentHealth = NewCurrentHealth;
        Assert.AreEqual(healthComp.CurrentHealth, NewCurrentHealth);
    }

    [TestMethod]
    public void CoinPocketComponentTest()
    {
        var coinComp = new CoinPocketComponent(InitialCoinAmount);
        Assert.AreEqual(coinComp.Coins, InitialCoinAmount);
        coinComp.Coins = NewCoinAmount;
        Assert.AreEqual(coinComp.Coins, NewCoinAmount);
    }
}
