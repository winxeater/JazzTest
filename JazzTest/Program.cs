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
            string input;
            string initialOrientation;
            string[] gridSize;
            string[] initialPosition;
            string[] newPlats;

            var robot = Machine.Instance;
            var grid = Grid.Instance;

            Console.WriteLine("Por favor, insira os dados para programar nosso robô..");

            Console.WriteLine("Informe o tamanho da horta (ex: 4,5):");
            gridSize = Console.ReadLine().Split(',');

            grid.setSize(int.Parse(gridSize[0]), int.Parse(gridSize[1]));

            Console.WriteLine("Informe a posição inicial do robô (ex: 3,2):");
            initialPosition = Console.ReadLine().Split(',');

            Console.WriteLine("Orientação inicial do robô (ex: N):");
            initialOrientation = Console.ReadLine().ToUpper();

            robot.positioning(int.Parse(initialPosition[0]), int.Parse(initialPosition[1]), (OrientationEnum)Enum.Parse(typeof(OrientationEnum), initialOrientation));

            for (; ;)
            {
                Console.WriteLine("Informe o canteiro a irrigar (ex: 4,1 ou aperte Enter para ligar o robô):");
                input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                    break;
                else
                {
                    newPlats = input.Split(',');
                    grid.addPlat(int.Parse(newPlats[0]), int.Parse(newPlats[1]));
                }
            }

            string resultPath = robot.GoRobot();
            Console.WriteLine($"Caminho: {resultPath}");
            Console.WriteLine($"Orientação final: {robot.Orientation.getDescription()}");

            Console.ReadLine();
        }
    }
}
