using System;

namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {
            User.CreateYourGraph();
            Console.WriteLine("按任意键退出...");
            Console.ReadKey();
        }
    }

    class User
    {
        static public Graph CreateYourGraph()
        {
            Console.Write("请输入你要创建的图形名字：");
            Graph aGraph = GraphFactory.CreateGraph(Console.ReadLine());
            if (aGraph == null)
            {
                CreateYourGraph();
            }
            else
            {
                aGraph.InputDate();
                aGraph.ShowArea();
            }

            return aGraph;
        }
    }

    class GraphFactory
    {
        static public Graph CreateGraph(string graphName)
        {
            Graph aGraph = null;

            if (graphName.Equals("三角形"))
            {
                aGraph = new Triangle();
            }
            else if (graphName.Equals("矩形") || graphName.Equals("长方形"))
            {
                aGraph = new Rectangle();
            }
            else if (graphName.Equals("正方形"))
            {
                aGraph = new Square();
            }
            else if (graphName.Equals("圆形"))
            {
                aGraph = new Circle();
            }
            else
            {
                Console.WriteLine("没有你想要创建的图形，请重新创建。\n");
                return null;
            }
            return aGraph;
        }
    }

    abstract class Graph
    {
        public abstract void InputDate();

        public abstract double Area
        {
            get;
        }

        public abstract void ShowArea();
    }

    class Triangle : Graph
    {
        private double height;
        private double bottomLenth;

        public override void InputDate()
        {
            try
            {
                Console.Write("请输入三角形的高度：");
                this.height = double.Parse(Console.ReadLine());
                Console.Write("请输入三角形的底边长度：");
                this.bottomLenth = double.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("输入有误，请重新输入。\n");
                InputDate();
            }
        }

        public override double Area
        {
            get
            {
                return height * bottomLenth / 2;
            }
        }

        public override void ShowArea()
        {
            Console.WriteLine("三角形的面积为：" + Area);
        }
    }

    class Rectangle : Graph
    {
        private double width;
        private double lenth;

        public override void InputDate()
        {
            try
            {
                Console.Write("请输入矩形的长度：");
                this.lenth = double.Parse(Console.ReadLine());
                Console.Write("请输入矩形的宽度：");
                this.width = double.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("输入有误，请重新输入。\n");
                InputDate();
            }
        }

        public override double Area
        {
            get
            {
                return lenth * width;
            }
        }

        public override void ShowArea()
        {
            Console.WriteLine("矩形的面积为：" + Area);
        }
    }

    class Square : Graph
    {
        private double sideLenth;

        public override void InputDate()
        {
            try
            {
                Console.Write("请输入正方形的边长：");
                this.sideLenth = double.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("输入有误，请重新输入。\n");
                InputDate();
            }
        }

        public override double Area
        {
            get
            {
                return sideLenth * sideLenth;
            }
        }

        public override void ShowArea()
        {
            Console.WriteLine("正方形的面积为：" + Area);
        }
    }

    class Circle : Graph
    {
        private double radius;

        public override void InputDate()
        {
            try
            {
                Console.Write("请输入圆形的半径：");
                this.radius = double.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("输入有误，请重新输入。\n");
                InputDate();
            }
        }

        public override double Area
        {
            get
            {
                return 3.14 * radius * radius;
            }
        }

        public override void ShowArea()
        {
            Console.WriteLine("圆形的面积为：" + Area);
        }
    }
}