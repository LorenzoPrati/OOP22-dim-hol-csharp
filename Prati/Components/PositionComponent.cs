namespace Components
{
    public class PositionComponent : IComponent
    {
        public Vector2D Pos { get; set; }
        public int Z { get; private set; }

        public Vector2D LastPos { get; set; }

        public PositionComponent(Vector2D pos, int z)
        {
            Pos = pos;
            Z = z;
        }

        public void UpdateLastPos() => LastPos = Pos;

        public void ResetToLastPos()
        {
            if (LastPos != null)
            {
                Pos = LastPos;
            }
        }
        
    }
}