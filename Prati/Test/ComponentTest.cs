using Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test;

[TestClass]
public class ComponentTest
{
    [TestMethod]
    public void PositionComponentTest()
    {
        var pos = new PositionComponent(new Vector2D(0, 1), 0);
        Assert.AreEqual(new Vector2D(0, 1), pos.Pos);
        pos.UpdateLastPos();
        Assert.AreEqual(new Vector2D(0, 1), pos.LastPos);
        pos.Pos = new Vector2D(1,-1);
        pos.ResetToLastPos();
        Assert.AreEqual(new Vector2D(0, 1), pos.Pos);
    }

    [TestMethod]
    public void MovementComponentTest()
    {
        var mov = new MovementComponent(new Vector2D(-1, 0), 1, false);
        Assert.IsFalse(mov.Enabled);
        Assert.AreEqual(new Vector2D(-1, 0), mov.Dir);
        Assert.AreEqual(1, mov.Speed);
        mov.Enabled = true;
        mov.Dir = new Vector2D(0, -1);
        Assert.IsTrue(mov.Enabled);
        Assert.AreEqual(new Vector2D(0, -1), mov.Dir);
    }
}