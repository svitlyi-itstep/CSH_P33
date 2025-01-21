using System.Drawing;
using System.Text;
using ConsoleGame.Game;

namespace ConsoleGame
{
    class Program
    {
        static Random random = new Random();

        static int Distanse(Point p1, Point p2)
        {
            return (int)Math.Sqrt(
                Math.Pow(p1.X - p2.X, 2) + 
                Math.Pow(p1.Y - p2.Y, 2)
                );
        }

        public static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            Console.InputEncoding = UTF8Encoding.UTF8;
            Console.CursorVisible = false;

            Point playerPosition = new Point(3, 3);
            string playerSymbol = "X";
            List<Point> coinList = new List<Point>();

            for(int i = 0; i < 5; i++)
                coinList.Add(new Point(random.Next(0, 20), random.Next(0, 20)));


            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if(key == ConsoleKey.Escape) { return; }
                else if(key == ConsoleKey.D) { playerPosition.X += 1; }
                else if(key == ConsoleKey.A) { playerPosition.X -= 1; }

                Console.Clear();
                foreach (var coin in coinList.ToList())
                {
                    if (Distanse(playerPosition, coin) <= 1) { coinList.Remove(coin); }
                    else
                    {
                        Console.SetCursorPosition(coin.X, coin.Y);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("🟡");
                        Console.ResetColor();
                    }
                }
                Console.SetCursorPosition(playerPosition.X, playerPosition.Y);
                Console.Write(playerSymbol);
            }

        }
    }
}
