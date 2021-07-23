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

        private void action(ActionEnum action, OrientationEnum orientation)
        {
            switch (action)
            {
                case ActionEnum.D:
                    path.Append(ActionEnum.D.ToString());
                    break;
                case ActionEnum.E:
                    path.Append(ActionEnum.E.ToString());
                    break;
                case ActionEnum.M:
                    goStraight();
                    break;
                case ActionEnum.I:
                    path.Append(ActionEnum.I.ToString());
                    Grid.Instance.nextPlat().setAlreadyDone();
                    break;
                default:
                    break;
            }

            Orientation = orientation;
        }

        public void goStraight()
        {
            path.Append(ActionEnum.M.ToString());

            switch (Orientation)
            {
                case OrientationEnum.Norte:
                    PositionY++;
                    break;
                case OrientationEnum.Sul:
                    PositionY--;
                    break;
                case OrientationEnum.Leste:
                    PositionX++;
                    break;
                case OrientationEnum.Oeste:
                    PositionX--;
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
                    action(ActionEnum.I, Orientation);

                switch (Orientation)
                {
                    case OrientationEnum.Norte:
                        if (PositionY < currentPlat.PositionY)
                            action(ActionEnum.M, Orientation);
                        else if (PositionY > currentPlat.PositionY || PositionX > currentPlat.PositionX)
                            action(ActionEnum.E, OrientationEnum.Oeste);
                        else if (PositionX < currentPlat.PositionX)
                            action(ActionEnum.D, OrientationEnum.Leste);
                        break;

                    case OrientationEnum.Sul:
                        if (PositionY > currentPlat.PositionY)
                            action(ActionEnum.M, Orientation);
                        else if (PositionY < currentPlat.PositionY || PositionX < currentPlat.PositionX)
                            action(ActionEnum.E, OrientationEnum.Leste);
                        else if (PositionX > currentPlat.PositionX)
                            action(ActionEnum.D, OrientationEnum.Oeste);
                        break;

                    case OrientationEnum.Leste:
                        if (PositionX < currentPlat.PositionX)
                            action(ActionEnum.M, Orientation);
                        else if (PositionX > currentPlat.PositionX || PositionY < currentPlat.PositionY)
                            action(ActionEnum.E, OrientationEnum.Norte);
                        else if (PositionY > currentPlat.PositionY)
                            action(ActionEnum.D, OrientationEnum.Sul);
                        break;

                    case OrientationEnum.Oeste:
                        if (PositionX > currentPlat.PositionX)
                            action(ActionEnum.M, Orientation);
                        else if (PositionX < currentPlat.PositionX || PositionY > currentPlat.PositionY)
                            action(ActionEnum.E, OrientationEnum.Sul);
                        else if (PositionY < currentPlat.PositionY)
                            action(ActionEnum.D, OrientationEnum.Norte);
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
