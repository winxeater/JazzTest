using JazzTest.Entities;
using JazzTest.ModelClasses;
using System;

namespace JazzTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Por favor, insira os dados para programar nosso robô..");
            InputClass.inputGrid();
            InputClass.inputRobotPosition();
            InputClass.inputRobotOrientation();
            InputClass.createRobot();

            while (InputClass.inputPlat());

            Console.WriteLine($"Caminho: {Machine.Instance.GoRobot()}");
            Console.WriteLine($"Orientação final: {Machine.Instance.Orientation}");
            Console.WriteLine($"Yes, irrigação concluída com sucesso! :D");

            Console.ReadLine();
        }
    }
}
