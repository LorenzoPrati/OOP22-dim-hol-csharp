namespace Components
{
    public class MovementComponent : IComponent
    {
        private Vector2D Dir { get; set; }
        private double Speed { get; set; }
        private bool Enalbed { get; set; }

        public MovementComponent(Vector2D dir, double speed, bool enabled)
        {
            Dir = dir;
            Speed = speed;
            Enalbed = enabled;
        }
    }
    

}