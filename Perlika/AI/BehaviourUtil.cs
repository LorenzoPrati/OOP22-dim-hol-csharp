using Components;

namespace AI;

public class BehaviourUtil
{
    private const int Angle = 45;
    
    private const int FlatAngle = 180;
    
    public static Vector2D GetPlayerDirection(Vector2D playerCentralPos, Vector2D enemyCentralPos)
    {
        double y1 = playerCentralPos.Y;
        double y2 = enemyCentralPos.Y;
        double x1 = playerCentralPos.X;
        double x2 = enemyCentralPos.X;
        var m = (y1 - y2) / (x1 - x2);
        var angle = Math.Atan(m) * FlatAngle / Math.PI;
        if (angle is > -Angle and < Angle)
        {
            if (playerCentralPos.X > enemyCentralPos.X) {
                // right
                return new Vector2D(1, 0);
            }
            //left
            return new Vector2D(-1, 0);
        }
        if (playerCentralPos.Y > enemyCentralPos.Y) {
            //down
            return new Vector2D(0, 1);
        }
        //up
        return new Vector2D(0, -1);
    }
}