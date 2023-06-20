using AI;
using Components;
using Entity;

namespace AITest;

[TestClass]
public class BehaviourUtilTest
{
    private Vector2D _playerPosition;
    private Vector2D _enemyPosition;

    [TestInitialize]
    public void TestInitialize()
    {
        _playerPosition = new Vector2D(0, 0);
        _enemyPosition = new Vector2D(4, 0);
    }

    [TestMethod]
    public void TestGetPlayerDirection()
    {
        Assert.AreEqual(BehaviourUtil.GetPlayerDirection(_playerPosition, _enemyPosition), 
            new Vector2D(-1, 0));
    }
    
}

[TestClass]
public class ActionsTest
{
    private IEntity _player;
    private IEntity _enemy;

    [TestInitialize]
    public void TestInitialize()
    {
        var actions = new List<IAction>
        {
            new FollowMovementAction(20),
            new RandomMovementAction(0)
        };
        _enemy = new EntityBuilder()
            .Add(new AIComponent(actions))
            .Add(new PositionComponent(new Vector2D(0, 0), 0))
            .Add(new MovementComponent(new Vector2D(1, 0), 1, true))
            .Build();
        _player = new EntityBuilder()
            .Add(new PositionComponent(new Vector2D(10, 10), 10))
            .Build();
    }

    [TestMethod]
    public void TestAction()
    {
        var enemyAi = _enemy.GetComponent(typeof(AIComponent)) as AIComponent;
        var actions = enemyAi!.GetRoutine();
        var followMovAction = actions[0];
        followMovAction.SetPlayer(_player);
        followMovAction.SetEnemy(_enemy);
        Assert.AreEqual(followMovAction.CanExecute(), true);
    }
    
}