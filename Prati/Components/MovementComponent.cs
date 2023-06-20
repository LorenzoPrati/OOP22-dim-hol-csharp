namespace Components
{
    public class MovementComponent : IComponent
    {
        public Vector2D Dir { get; set; }
        public double Speed { get; set; }
        public bool Enabled { get; set; }

        public MovementComponent(Vector2D dir, double speed, bool enabled)
        {
            Dir = dir;
            Speed = speed;
            Enabled = enabled;
        }
    }
    

}