using Components;
using Core;

namespace AI;

public class RandomMovementAction : AbstractAction
{
    public RandomMovementAction(double changeDirectionTime)
    {
        SetWaitingTime(changeDirectionTime);
    }
    
    public bool CanExecute() {
        return true;
    }

    public override List<IWorldEvent>? Execute()
    {
        GetMovComp().Enabled = true;
        Vector2D[] directions = {new(0, 1), new(0, -1), new(1, 0), new(-1, 0)};
        if (reloadTimePassed())
        {
            var rand = new Random();
            var i = rand.Next(1, directions.Length + 1);
            GetMovComp().Dir = directions[i];
        }
        return null;
    }
}