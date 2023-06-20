using Components;
using Entity;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test;

[TestClass]
public class Worldtest
{
    private IWorld _world;
    private IEntity _player;
    private IEntity _boss;

    [TestInitialize]
    public void TestInitialize()
    {
        _world = new WorldImpl();
        _player = new EntityBuilder().Add(new PlayerComponent()).Build();
        _boss = new EntityBuilder().Add(new BossComponent()).Build();
    }

    [TestMethod]
    public void TestAddRemove()
    {
        _world.AddEntity(_player);
        Assert.AreEqual(1, _world.Entities.Count);
        _world.RemoveEntity(_boss);
        Assert.AreEqual(1, _world.Entities.Count);
        _world.RemoveEntity(_player);
        Assert.AreEqual(0, _world.Entities.Count);
    }

    [TestMethod]
    public void TestEvents()
    {
        Assert.AreEqual(0, _world.Entities.Count);
        _world.NotifyEvent(new AddEntityEvent(_player));
        _world.Update();
        Assert.AreEqual(1, _world.Entities.Count);
        _world.NotifyEvent(new RemoveEntityEvent(_player));
        _world.Update();
        Assert.AreEqual(0, _world.Entities.Count);
    }

    [TestMethod]
    public void TestGameOver()
    {
        Assert.IsFalse(_world.GameOver);
        _world.AddEntity(_player);
        _world.AddEntity(_boss);
        _world.NotifyEvent(new RemoveEntityEvent(_player));
        _world.Update();
        Assert.IsTrue(_world.GameOver);
        Assert.IsFalse(_world.Win);
    }

}