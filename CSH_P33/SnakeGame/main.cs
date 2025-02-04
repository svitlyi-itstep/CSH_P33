using System.Text;
using System.Drawing;

namespace CSH_P33.SnakeGame
{
    class SnakeGame
    {
        public static void Main(string[] args)
        {
            Point point = new Point();
            List<Point> segments = new List<Point>();

            segments.Add(point);
            segments.Insert(0, point);
            segments.RemoveAt(segments.Count - 1);
        }
    }
}
