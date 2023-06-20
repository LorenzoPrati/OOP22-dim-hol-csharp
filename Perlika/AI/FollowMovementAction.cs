using Core;

namespace AI;

public class FollowMovementAction : AbstractAction
{
    public FollowMovementAction(double followMovementAggro)
    {
        setAggroRay(followMovementAggro);
    }

    public override List<IWorldEvent>? Execute()
    {
        GetMovComp().Enabled = true;
        var newDirection = BehaviourUtil.GetPlayerDirection(GetPlayerPos(), GetEnemyPos());
        GetMovComp().Dir = newDirection;
        return null;
    }
}