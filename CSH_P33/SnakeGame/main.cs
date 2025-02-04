using System.Text;
using System.Drawing;

namespace CSH_P33.SnakeGame
{
    class SnakeGame
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            Console.InputEncoding = UTF8Encoding.UTF8;
            Console.CursorVisible = false;
            Game game = new Game();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Escape) { break; }
                    else if (key == ConsoleKey.W || key == ConsoleKey.UpArrow)
                        game.ChangeSnakeDirection(Direction.UP);
                    else if (key == ConsoleKey.S || key == ConsoleKey.DownArrow)
                        game.ChangeSnakeDirection(Direction.DOWN);
                    else if (key == ConsoleKey.A || key == ConsoleKey.LeftArrow)
                        game.ChangeSnakeDirection(Direction.LEFT);
                    else if (key == ConsoleKey.D || key == ConsoleKey.RightArrow)
                        game.ChangeSnakeDirection(Direction.RIGHT);
                }

                game.Update();
                game.Draw();
                if (game.IsGameOver) { break; }
            }
        }
    }
}


/*
    Point point = new Point();
    List<Point> segments = new List<Point>();

    segments.Add(point);
    segments.Insert(0, point);
    segments.RemoveAt(segments.Count - 1);
*/