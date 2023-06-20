using Components;
using Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test;

[TestClass]
public class Entitytest
{
    private IEntity _entity;

    [TestInitialize]
    public void TestInitialize()
    {
        _entity = new EntityBuilder()
                .Add(new PositionComponent(new Vector2D(1,0), 1))
                .Add(new MovementComponent(new Vector2D(0,-1), 1, true)).Build();
    }

    [TestMethod]
    public void TestComponents()
    {
        Assert.AreEqual(2, _entity.Components.Count);
        Assert.IsTrue(_entity.HasComponent(typeof(PositionComponent)));
        _entity.RemoveComponent(_entity.GetComponent(typeof(MovementComponent)));
        Assert.IsFalse(_entity.HasComponent(typeof(MovementComponent)));
    }

    [TestMethod]
    public void TestFamily()
    {
        ISet<Type> family = new HashSet<Type>();
        family.Add(typeof(PositionComponent));
        family.Add(typeof(MovementComponent));
        Assert.IsTrue(_entity.HasFamily(family));
        _entity.RemoveComponent(_entity.GetComponent(typeof(MovementComponent)));
        Assert.IsFalse(_entity.HasFamily(family));
    }
}