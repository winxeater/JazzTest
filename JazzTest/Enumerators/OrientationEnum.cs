using System.ComponentModel;

namespace JazzTest.Enumerators
{
    public enum OrientationEnum
    {
        [Description("N")]
        Norte = 0,
        [Description("S")]
        Sul = 1,
        [Description("L")]
        Leste = 2,
        [Description("O")]
        Oeste = 3,
    }
}
