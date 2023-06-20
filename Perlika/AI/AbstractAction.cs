using Components;
using Core;
using Entity;

namespace AI;

public abstract class AbstractAction : IAction
{
    private static readonly int Divisor = 2;

    private double _aggroRay = Double.MaxValue;
    private double _waitingTime = Double.NaN;
    private Vector2D _playerPos;
    private Vector2D _enemyPos;
    private IEntity _enemy;
    private AIComponent _ai;
    private MovementComponent _movComp;
    
    public bool CanExecute()
    {
        double x1 = _playerPos.X;
        double y1 = _playerPos.Y;
        double x2 = _enemyPos.X;
        double y2 = _enemyPos.Y;
        var distance= Math.Sqrt(Math.Pow(x2 - x1, Divisor) + Math.Pow(y2 - y1, Divisor));
        return distance < _aggroRay;
    }

    public abstract List<IWorldEvent>? Execute();

    public void SetPlayer(IEntity player)
    {
        PositionComponent playerPosComp = (PositionComponent) player.GetComponent(typeof(PositionComponent));
        _playerPos = playerPosComp.Pos;
    }

    public void SetEnemy(IEntity enemy)
    {
        _enemy = new EntityImpl(enemy);
        PositionComponent enemyPosComp = (PositionComponent) enemy.GetComponent(typeof(PositionComponent));
        _enemyPos = enemyPosComp.Pos;
        _ai = (AIComponent) enemy.GetComponent(typeof(AIComponent));
        _movComp = (MovementComponent) enemy.GetComponent(typeof(MovementComponent));
    }

    protected Vector2D GetPlayerPos() => _playerPos;

    protected Vector2D GetEnemyPos() => _enemyPos;

    protected void setAggroRay(double aggroRay) => _aggroRay = aggroRay;

    protected void SetWaitingTime(double waitingTime) => _waitingTime = waitingTime;

    protected AIComponent getAi() => _ai;

    protected MovementComponent GetMovComp() => _movComp;
    
    protected IEntity getEnemy() => _enemy;
    
    public double getWaitingTime() => _waitingTime;

    public double getAggroRay() => _aggroRay;

    protected bool reloadTimePassed() {
        if (getAi().GetCurrentTime() - getAi().GetPrevTime() >= getWaitingTime()) {
            getAi().SetPrevTime(getAi().GetCurrentTime());
            return true;
        }
        return false;
    }
}