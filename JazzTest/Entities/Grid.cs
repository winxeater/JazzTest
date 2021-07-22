using JazzTest.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JazzTest.Entities
{
    public sealed class Grid
    {
        //properties
        public int SizeX { get; private set; }
        public int SizeY { get; private set; }
        private List<Plat> Plats { get; set; }

        public Grid()
        {
            SizeX = 0;
            SizeY = 0;
        }

        //singleton
        private static Grid instance;
        public static Grid Instance => instance ?? (instance = new Grid());

        public void setSize(int x, int y)
        {
            validate(x, y);

            SizeX = x;
            SizeY = y;
        }

        public void validate(int x, int y)
        {
            if (x <= 0 || y <= 0)
                throw new Exception("Tamanho do canteiro inválido.");
        }

        public void addPlat(int x, int y)
        {
            Plats.Add(new Plat(x, y));
        }

        public Plat nextPlat() => Plats.Where(o => !o.AlreadyDone).Select(o => o).FirstOrDefault();
    }
}
