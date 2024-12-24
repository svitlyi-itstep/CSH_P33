//using System.Text;

//abstract class Shape
//{
//    public abstract double GetArea();
//}

//class Square : Shape
//{
//    double side;
//    public Square(double side) { this.side = side; }
//    public override double GetArea() { return Math.Pow(side, 2); }
//    public override string ToString() { return $"{base.ToString()}(side={this.side})"; }
//}

//class Rectangle : Shape
//{
//    double a, b;
//    public Rectangle(double a, double b) { this.a = a; this.b = b; }
//    public override double GetArea() { return a * b; }
//    public override string ToString() { return $"{base.ToString()}(a={this.a},b={this.b})"; }
//}

//class Program
//{
//    public static void Main(string[] args)
//    {
//        Console.OutputEncoding = UTF8Encoding.UTF8;
//        Console.InputEncoding = UTF8Encoding.UTF8;

//        Shape[] shapes = { new Square(4), new Square(9), new Rectangle(4, 7), 
//            new Rectangle(2, 5) };
//        foreach (Shape shape in shapes)
//        {
//            Console.WriteLine($"Площа фігури {shape} дорівнює {shape.GetArea()}");
//        }
//    }
//}