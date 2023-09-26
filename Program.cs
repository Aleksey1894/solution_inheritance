using System.Globalization;

namespace Lesson_12_Inheritance_And_Polymorphism
{
    public class Shape
    {
        public Shape(string name)
        {
            _name = name;
        }

        private string _name = string.Empty;
        public string Name => _name;

        public virtual float Perimeter => 0;

        public virtual float Area => 0;

        public virtual void DrawShapeToConsole()
        {
            Console.WriteLine(" * Homework for the smartest ones.");
        }

        public override string ToString()
            => $"{_name} has an area of {Area} sq. units and perimeter of {Perimeter} units";
    }
        public class Triangle : Shape
        {
            public Triangle(float length1, float length2, float length3)
                : base(nameof(Triangle))
            {
                Length1 = length1;
                Length2 = length2;
                Length3 = length3;              
            }
        public float Length1 { get; }
        public float Length2 { get; }
        public float Length3 { get; }
              
        public override float Perimeter => Length1 + Length2 + Length3;

        public float Poluperimetr => Perimeter / 2;

        public override float Area => (float)Math.Sqrt(Poluperimetr * (Poluperimetr - Length1) * (Poluperimetr - Length2) * (Poluperimetr - Length3));
    }


       public class RightTriangle : Triangle
       {
       public RightTriangle(float rightLength1, float rightLength2)
          : base(rightLength1,rightLength2, (float)Math.Sqrt(rightLength1 * rightLength1 + rightLength2 * rightLength2)) {}

       public override float Perimeter => Length1 + Length2 + Length3;

       public override float Area => 0.5f * Length1 * Length2;   
       }
    

    public class EquilateralTriangle : Triangle
    {
        public EquilateralTriangle(float equilateralLength1)
            : base(equilateralLength1, equilateralLength1, equilateralLength1) { }
       
        public override float Perimeter => Length1 * 3;
        public override float Area => (float)(Math.Sqrt(3) / 4) * Length1*Length1;

    }

    public class Circle : Shape
    {
        public Circle(float radius)
            : base(nameof(Circle))
        {
            Radius = radius;
        }

        public float Radius { get; }

        public override float Perimeter => 2 * MathF.PI * Radius;

        public override float Area => MathF.PI * Radius * Radius;
    }

    public class Rectangle : Shape
    {
        public Rectangle(float width, float height)
            : base(nameof(Rectangle))
        {
            Width = width;
            Height = height;
        }

        public float Width { get; }

        public float Height { get; }

        public override float Area => Width * Height;

        public override float Perimeter => 2 * (Width + Height);
    }

    internal class Program
    {
        static void SubTask1()
        {
            Shape some_circle = new Circle(3);
            Shape some_rect = new Rectangle(4, 5);

            Circle circle = (Circle)some_circle; // type casting - приведення типів даних
            Rectangle rect = some_rect as Rectangle;

            if (some_circle is Circle)
            {
                Console.WriteLine("Circle is a circle");
            }

            if (some_circle is Rectangle)
            {
                Console.WriteLine("Circle is a rectangle");
            }

            if (some_circle is DateTime)
            {
                Console.WriteLine("Circle is a datetime");
            }

            if (some_circle is object)
            {
                Console.WriteLine("Circle is 100% object");
            }

            if (some_circle is Shape)
            {
                Console.WriteLine("Circle is definetly a shape");
            }

            Console.WriteLine(circle.Radius);
            Console.WriteLine(rect.Width);
            Console.WriteLine(rect.Height);

            Console.WriteLine($"Circle has a perimeter of {some_circle.Perimeter} and area of {some_circle.Area} sqare unit.");
            Console.WriteLine($"Rectangle has a perimeter of {some_rect.Perimeter} and area of {some_rect.Area} sqare unit.");
        }

        static void Main(string[] args)
        {
            Console.Write("Enter count of shapes: ");
            int count = int.Parse(Console.ReadLine());

            Shape[] shapes = new Shape[count];
            for (int i = 0; i < count; i++)
            {
                shapes[i] = ReadShape();
            }

            float sum_area = 0;
            float sum_perimeters = 0;
            for (int i = 0; i < count; ++i)
            {
                sum_area += shapes[i].Area;
                sum_perimeters += shapes[i].Perimeter;
            }

            Console.WriteLine($"Total perimeter is {sum_perimeters}");
            Console.WriteLine($"Total area is {sum_area}");
        }

        static Shape ReadShape()
        {
            Console.WriteLine("Choose a shape type: ");
            Console.WriteLine("1. Circle");
            Console.WriteLine("2. Rectangle");
            Console.WriteLine("3. Triangle");
            Console.WriteLine("4. RightTriangle");
            Console.WriteLine("5. EquilateralTrianle ");

        Read_Input:
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.Write("Enter circle radius: ");
                    float radius = float.Parse(Console.ReadLine());
                    return new Circle(radius);

                case 2:
                    Console.Write("Enter rectangle width: ");
                    float width = float.Parse(Console.ReadLine());
                    Console.Write("Enter rectangle height: ");
                    float height = float.Parse(Console.ReadLine());
                    return new Rectangle(width, height);
                case 3:
                    Console.Write("Enter triangle length #1: ");
                    float length1 = float.Parse(Console.ReadLine());
                    Console.Write("Enter triangle lenght #2: ");
                    float length2 = float.Parse(Console.ReadLine());
                    Console.Write("Enter triangle length #3: ");
                    float length3 = float.Parse(Console.ReadLine());
                    return new Triangle(length1,length2, length3);

                case 4:
                    Console.Write("Enter right triangle length #1: ");
                    float rightLength1 = float.Parse(Console.ReadLine());
                    Console.Write("Enter right triangle length #2: ");
                    float rightLength2 = float.Parse(Console.ReadLine());
                    return new RightTriangle(rightLength1, rightLength2);
                case 5:
                    Console.Write("Enter equilateral triangle length: ");
                    float equilateralLength1 = float.Parse(Console.ReadLine());
                    return new EquilateralTriangle(equilateralLength1);

                default:
                    Console.Write("Incorrect shape type. Choose again: ");
                    goto Read_Input;
            }
        }
    }
}
