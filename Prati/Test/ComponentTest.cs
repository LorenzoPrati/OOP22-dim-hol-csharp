using Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test;

[TestClass]
public class ComponentTest
{
    [TestMethod]
    public void TestMethod1()
    {
        var pos = new PositionComponent(new Vector2D(3,4),0);
        Assert.AreEqual(new Vector2D(3,4), pos.Pos);
        pos.UpdateLastPos();
        Assert.AreEqual(new Vector2D(3,4), pos.LastPos);
        pos.Pos = new Vector2D(9,8);
        pos.ResetToLastPos();
        Assert.AreEqual(new Vector2D(3,4), pos.Pos);
    }
}