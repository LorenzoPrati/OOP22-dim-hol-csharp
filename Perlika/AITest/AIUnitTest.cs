using AI;
using Components;
using Entity;

namespace AITest;

public class BehaviourUtilTest
{
    private Vector2D _playerPosition;
    private Vector2D _enemyPosition;

    [SetUp]
    public void Setup()
    {
        _playerPosition = new Vector2D(0, 0);
        _enemyPosition = new Vector2D(4, 0);
    }

    [Test]
    public void Test1()
    {
        Assert.That(BehaviourUtil.GetPlayerDirection(_playerPosition, _enemyPosition), 
            Is.EqualTo(new Vector2D(-1, 0)));
    }
}

public class ActionsTest
{
    private IEntity _player;
    private IEntity _enemy;
    
    [SetUp]
    public void Setup()
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

    [Test]
    public void TestAIRandomMovement()
    {
        var enemyAi = _enemy.GetComponent(typeof(AIComponent)) as AIComponent;
        var actions = enemyAi!.GetRoutine();
        var followMovAction = actions[0];
        followMovAction.SetPlayer(_player);
        followMovAction.SetEnemy(_enemy);
        Assert.That(followMovAction.CanExecute(), Is.True);
    } 
}