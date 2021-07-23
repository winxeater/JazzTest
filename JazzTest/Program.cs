using JazzTest.Entities;
using JazzTest.Enumerators;
using JazzTest.Util;
using System;

namespace JazzTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = Grid.Instance;
            grid.setSize(4, 5);

            var robot = Machine.Instance;
            robot.positioning(3, 2, OrientationEnum.Norte);

            grid.addPlat(4, 1);
            grid.addPlat(4, 5);
            grid.addPlat(3, 4);

            string resultPath = robot.GoRobot();
            Console.WriteLine($"Caminho: {resultPath}");
            Console.WriteLine($"Orientação final: {robot.Orientation.toStringDescription()}");

            Console.ReadLine();
        }
    }
}
