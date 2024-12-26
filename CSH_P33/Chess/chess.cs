using System.Drawing;

namespace Chess
{
    enum Player { Black, White }

    abstract class Chessmen
    {
        protected Point position = new Point(1, 1);
        protected Player team = Player.White;
        public Chessmen(Point position, Player team)
        {
            this.position = position;
            this.team = team;
        }
        public Chessmen(int x, int y) : this(new Point(x, y), Player.White) { }

        public abstract List<Point> PossibleMoves();
        public abstract bool IsCanMove(Point position);
    }

    class Knight : Chessmen
    {
        public Knight(Point position, Player team) : base(position, team) { }
        public Knight(int x, int y) : base(x, y) { }
        public override List<Point> PossibleMoves()
        {
            List<Point> possibleMoves = new List<Point>();
            possibleMoves.Add(new Point(this.position.X + 1, this.position.Y + 2));
            possibleMoves.Add(new Point(this.position.X + 2, this.position.Y + 1));
            possibleMoves.Add(new Point(this.position.X + 2, this.position.Y - 1));
            possibleMoves.Add(new Point(this.position.X + 1, this.position.Y - 2));
            possibleMoves.Add(new Point(this.position.X - 1, this.position.Y - 2));
            possibleMoves.Add(new Point(this.position.X - 2, this.position.Y - 1));
            possibleMoves.Add(new Point(this.position.X - 2, this.position.Y + 1));
            possibleMoves.Add(new Point(this.position.X - 1, this.position.Y + 2));
            List<Point> result = new List<Point>();
            foreach (Point p in possibleMoves)
            {
                if ((p.X >= 1 && p.X <= 8) && (p.Y >= 1 && p.Y <= 8))
                { result.Add(p); }
            }
            return result;
        }
        public override bool IsCanMove(Point position)
        {
            return PossibleMoves().FindAll(p => p.Equals(position)).Count > 0;
        }
    }
}
