using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyComponents;
namespace Test;

[TestClass]
public class AnimationComponentTest
{
    private readonly Dictionary<string, List<int>> _testMap = new Dictionary<string, List<int>>();
    AnimationComponent animComp;

    public AnimationComponentTest()
    {
        _testMap.Add("idle", new List<int>{1, 4, 0});
        _testMap.Add("attacking_left", new List<int>{2, 8, 1});
        _testMap.Add("attacking_right", new List<int>{3, 8, 1});
        _testMap.Add("walking_up", new List<int>{4, 6, 0});
        _testMap.Add("walking_down", new List<int>{5, 6, 0});
        animComp = new AnimationComponent(_testMap, "walking_up");
    }

    [TestMethod]
    public void TestStateAndLastState()
    {
       Assert.AreEqual(animComp.State, "walking_up");
       Assert.AreEqual(animComp.LastState, "walking_up");
    }

    [TestMethod]
    public void TestMaxIndex()
    {
        Assert.AreEqual(animComp.GetMaxIndex(), 4);
    }

    [TestMethod]
    public void TestImageNumber()
    {
        Assert.AreEqual(animComp.GetImageNumber(), 6);
    }

    [TestMethod]
    public void TestIsBlocking()
    {
        Assert.IsFalse(animComp.IsBlocking());
    }

    [TestMethod]
    public void TestCounterAndIndex()
    {
        animComp.Counter = 3;
        animComp.Index = 6; 
        Assert.AreEqual(animComp.Counter, 3);
        Assert.AreEqual(animComp.Index, 6);
    }
}