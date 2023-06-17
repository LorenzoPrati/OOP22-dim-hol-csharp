namespace Components
{
    public class PositionComponent
    {
        private int _x;
        private int _y;

        public PositionComponent(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int GetX => _x;
        public int GetY => _y;
    }
}