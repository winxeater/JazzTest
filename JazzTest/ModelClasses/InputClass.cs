using JazzTest.Entities;
using JazzTest.Enumerators;
using System;
using System.Text.RegularExpressions;

namespace JazzTest.ModelClasses
{
    public static class InputClass
    {
        private static Regex regex = new Regex(@"[\d],[\d]");
        private static string input;
        private static string initialOrientation;
        public static string[] GridSize;
        public static string[] InitialPosition;
        public static string[] NewPlats;

        public static string Input
        {
            get
            {
                return input;
            }
            set
            {
                input = string.Empty;

                if (regex.IsMatch(value))
                    input = value;
                else
                    throw new Exception("=> O valor deve ser 2 números separados por vírgula.");
            }
        }

        public static string InitialOrientation
        {
            get
            {
                return initialOrientation;
            }
            set
            {
                initialOrientation = string.Empty;

                if (Enum.IsDefined(typeof(OrientationEnum), value))
                    initialOrientation = value;
                else
                    throw new Exception("=> Ei, se oriente!!! N para norte, L para leste, O para oeste ou S para sul... ;)");
            }
        }

        public static void inputGrid()
        {
            try
            {
                Console.WriteLine("Informe o tamanho da horta (ex: 4,5):");
                Input = Console.ReadLine();
                GridSize = Input.Split(',');
                Grid.Instance.setSize(int.Parse(GridSize[0]), int.Parse(GridSize[1]));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                inputGrid();
            }
        }

        public static void inputRobotPosition()
        {
            try
            {
                Console.WriteLine("Informe a posição inicial do robô (ex: 3,2):");
                Input = Console.ReadLine();
                InitialPosition = Input.Split(',');
                validRobotPosition();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                inputRobotPosition();
            }
        }

        private static void validRobotPosition()
        {
            if (int.Parse(InitialPosition[0]) > int.Parse(GridSize[0]) || int.Parse(InitialPosition[0]) < 0 || int.Parse(InitialPosition[1]) > int.Parse(GridSize[1]) || int.Parse(InitialPosition[1]) < 0)
                throw new Exception("=> O robô não pode ser posicionado fora da horta.");
        }

        private static void validPlatPosition()
        {
            if (int.Parse(NewPlats[0]) > int.Parse(GridSize[0]) || int.Parse(NewPlats[0]) < 0 || int.Parse(NewPlats[1]) > int.Parse(GridSize[1]) || int.Parse(NewPlats[1]) < 0)
                throw new Exception("=> O robô não pode ser posicionado fora da horta.");
        }

        public static void inputRobotOrientation()
        {
            try
            {
                Console.WriteLine("Orientação inicial do robô (ex: N):");
                InitialOrientation = Console.ReadLine().ToUpper();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                inputRobotOrientation();
            }
        }

        public static void createRobot()
        {
            try
            {
                Machine.Instance.positioning(int.Parse(InitialPosition[0]), int.Parse(InitialPosition[1]), (OrientationEnum)Enum.Parse(typeof(OrientationEnum), InitialOrientation));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static bool inputPlat()
        {
            try
            {
                Console.WriteLine("Informe o canteiro a irrigar (ex: 4,1 ou aperte Enter para ligar o robô):");
                string _input = Console.ReadLine();

                if (string.IsNullOrEmpty(_input))
                    return false;
                else
                {
                    Input = _input;
                    NewPlats = Input.Split(',');
                    validPlatPosition();
                    Grid.Instance.addPlat(int.Parse(NewPlats[0]), int.Parse(NewPlats[1]));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                inputPlat();
            }

            return true;
        }

    }
}
