using System;

namespace Laba2
{
    abstract class Figure
    {
        abstract public double Area(); 
    }
    class Rectangle : Figure , IPrint
    {
        public int _width { get; set; }
        public int _height { get; set; }
        public Rectangle(int width, int height)
        {
            this._width = width;
            this._height = height;
        }
        public override double Area()
        {
            double S;
            S = _width * _height;
            return S;
        }
         public override string ToString()
        {
            return "Ширина и высота прямоугольника: " + this._width +" " + this._height + " " + "Площадь прямоугольника: " + this.Area();
        }
        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
    class Quadrate : Rectangle, IPrint
    {
        public Quadrate(int width): base(width, width)
        {
            this._width = width;
        }
        public override string ToString()
        {
            return "Сторона квадрата: " + this._width + " " + "Площадь квадрата: " + this.Area();
        }
    }
    class Circle: Figure, IPrint
    {
        public int property { get; set; }
        public Circle(int radius)
        {
            this.property = radius;
        }
        public override double Area()
        {
            double S;
            S = Math.PI * property * property;
            return S;
        }
        public override string ToString()
        {
            return "Радиус круга: " + this.property + " " + "Площадь круга: " + this.Area();
        }
        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
    interface IPrint
    {
        void Print();
    }
    class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            Console.WriteLine("Введите ширину прямоугольника:");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите высоту прямоугольника:");
            b = Convert.ToInt32(Console.ReadLine());
            Rectangle A = new Rectangle(a, b);
            A.Print();
            Console.WriteLine("Введите сторону квадрата:");
            a = Convert.ToInt32(Console.ReadLine());
            Quadrate B = new Quadrate(a);
            B.Print();
            Console.WriteLine("Введите радиус круга:");
            a = Convert.ToInt32(Console.ReadLine());
            Circle C= new Circle(a);
            C.Print();
            
        }
    }
}
