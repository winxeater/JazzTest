namespace JazzTest.Entities
{
    public class Plat
    {
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }
        public bool AlreadyDone { get; private set; }

        public Plat(int x, int y)
        {
            PositionX = x;
            PositionY = y;
            AlreadyDone = false;
        }

        public void setAlreadyDone()
        {
            AlreadyDone = true;
        }
    }
}
