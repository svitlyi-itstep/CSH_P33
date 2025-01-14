using System.Text;

interface IDrawable
{
    void Draw();
}

abstract class Shape
{
    public abstract double GetArea();
}

class Square : Shape, IDrawable
{
    double side;
    public Square(double side) { this.side = side; }
    public override double GetArea() { return Math.Pow(side, 2); }
    public override string ToString() { return $"{base.ToString()}(side={this.side})"; }
    public void Draw()
    {
        for (int i = 0; i < this.side; i++)
        {
            for (int j = 0; j < this.side; j++)
                Console.Write("* ");
            Console.WriteLine();
        }
    }
}

class Rectangle : Shape
{
    double a, b;
    public Rectangle(double a, double b) { this.a = a; this.b = b; }
    public override double GetArea() { return a * b; }
    public override string ToString() { return $"{base.ToString()}(a={this.a},b={this.b})"; }
}


class Program
{
    public static void ShowOnScreen(IDrawable shape, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        shape.Draw();
        Console.ResetColor();
    }

    public static void Main(string[] args)
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;
        Console.InputEncoding = UTF8Encoding.UTF8;

        Square s = new Square(4);
        ShowOnScreen(s, ConsoleColor.Red);

        Shape[] shapes = { new Square(4), new Square(9), new Rectangle(4, 7),
            new Rectangle(2, 5) };
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Площа фігури {shape} дорівнює {shape.GetArea()}");
        }
    }
}