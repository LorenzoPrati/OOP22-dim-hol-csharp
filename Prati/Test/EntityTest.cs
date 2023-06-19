using Components;
using Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test;

[TestClass]
public class Entitytest
{

    [TestMethod]
    public void TestMethod1()
    {
        // Entity builder test
        var components = new HashSet<IComponent>();
        var pos = new PositionComponent(new Vector2D(0,0),1);
        var mov = new MovementComponent(new Vector2D(0,0),3,true);
        components.Add(pos);
        components.Add(mov);
        var entity = new EntityBuilder().Add(pos).Add(mov).Build();

        Assert.AreEqual(components.Count, entity.Components.Count);
        Assert.AreEqual(true, entity.HasComponent(mov.GetType()));
        entity.RemoveComponent(mov);
        Assert.AreEqual(false, entity.HasComponent(mov.GetType()));

        var c = (PositionComponent) entity.GetComponent(pos.GetType());
        Assert.AreEqual(0, c.Pos.X);
        
        // Family test
        ISet<Type> family = new HashSet<Type>();
        family.Add(pos.GetType());
        Assert.AreEqual(true, entity.HasFamily(family));
        family.Add(mov.GetType());
        entity.AddComponent(mov);
        Assert.AreEqual(true, entity.HasFamily(family));
    }
}