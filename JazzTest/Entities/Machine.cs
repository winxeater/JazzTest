using JazzTest.Enumerators;
using JazzTest.Util;
using System;
using System.Text;

namespace JazzTest.Entities
{
    public sealed class Machine
    {
        //properties
        private int PositionX { get; set; }
        private int PositionY { get; set; }
        public OrientationEnum Orientation { get; private set; }
        public StringBuilder path { get; private set; }

        public Machine()
        {
            PositionX = 0;
            PositionY = 0;
            Orientation = OrientationEnum.Norte;
            path = new StringBuilder();
        }

        //singleton
        private static Machine instance;
        public static Machine Instance => instance ?? (instance = new Machine());

        public void positioning(int x, int y, OrientationEnum o)
        {
            PositionX = x;
            PositionY = y;
            Orientation = o;
        }

        private void validate(int x, int y)
        {
            var grid = Grid.Instance;

            grid.validate(grid.SizeX, grid.SizeY);

            if (x > grid.SizeX || y > grid.SizeY || x < 0 || y < 0)
                throw new Exception("O robô não está no canteiro.");
        }

        private void action(ActionEnum action)
        {
            switch (action)
            {
                case ActionEnum.D:
                    path.Append(ActionEnum.D.toStringDescription());
                    break;
                case ActionEnum.E:
                    path.Append(ActionEnum.E.toStringDescription());
                    break;
                case ActionEnum.M:
                    path.Append(ActionEnum.M.toStringDescription());
                    break;
                case ActionEnum.I:
                    path.Append(ActionEnum.I.toStringDescription());
                    Grid.Instance.nextPlat().setAlreadyDone();
                    break;
                default:
                    break;
            }
        }

        public string GoRobot()
        {
            var grid = Grid.Instance;
            var currentPlat = grid.nextPlat();

            if (currentPlat != null)
            {
                if (PositionX == currentPlat.PositionX && PositionY == currentPlat.PositionY)
                    action(ActionEnum.I);

                switch (Orientation)
                {
                    case OrientationEnum.Norte:
                        if (PositionY < currentPlat.PositionY)
                            action(ActionEnum.M);
                        else if (PositionY > currentPlat.PositionY || PositionX < currentPlat.PositionX)
                            action(ActionEnum.D);
                        else if (PositionX > currentPlat.PositionX)
                            action(ActionEnum.E);
                        break;

                    case OrientationEnum.Sul:
                        break;

                    case OrientationEnum.Leste:
                        break;

                    case OrientationEnum.Oeste:
                        break;

                    default:
                        break;
                }

                GoRobot();
            }
                
            return path.ToString();
        }
    }
}
