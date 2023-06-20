using Microsoft.VisualStudio.TestTools.UnitTesting;
using Factory;
using Entity;
using Components;
using MyComponents;

namespace Test;

[TestClass]
public class ItemFactoryTest
{
    private IEntity _heart;
    private ItemFactory _factory;
    private IEntity _coin;
    private IEntity _player;
    [TestInitialize]
    public void InitializeMethod()
    {
        _factory = new ItemFactory();
        _heart = _factory.CreateHeart(1, 0);
        _coin = _factory.CreateCoin(0, 1);
        _player =  new EntityBuilder()
            .Add(new PositionComponent(new Vector2D(1,1), 1))
            .Add(new HealthComponent(10))
            .Add(new CoinPocketComponent(20))
            .Build();
    }

    [TestMethod]
    public void HeartEffectTest()
    {
        var itemComp = (ItemComponent)_heart.GetComponent(typeof(ItemComponent));
        itemComp.ApplyEffect(_player, new List<Type>{typeof(PositionComponent)});
        //case: effect not usable 
        var healthComp = (HealthComponent)_player.GetComponent(typeof(HealthComponent));
        Assert.AreEqual(healthComp.CurrentHealth,10);
        //case: effect usable
        healthComp.CurrentHealth = 9;
        itemComp.ApplyEffect(_player, new List<Type>{typeof(PositionComponent)});
        Assert.AreEqual(healthComp.CurrentHealth,10);

    }

    [TestMethod]
    public void CoinEffectTest()
    {
        var itemComp = (ItemComponent)_coin.GetComponent(typeof(ItemComponent));
        itemComp.ApplyEffect(_player, new List<Type>{typeof(PositionComponent)});
        var coinComp = (CoinPocketComponent)_player.GetComponent(typeof(CoinPocketComponent));
        Assert.AreEqual(coinComp.Coins,21);
    }
}