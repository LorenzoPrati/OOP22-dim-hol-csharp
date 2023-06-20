namespace Components
{
    public class Vector2D 
    {
        public double X { get; set;}
        public double Y { get; set;}

        public Vector2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals (object obj)
        {
            return Equals (obj as Vector2D);
        }

        public bool Equals (Vector2D obj)
        {
            return obj != null && obj.X == X && obj.Y == Y;
        }

    }
}