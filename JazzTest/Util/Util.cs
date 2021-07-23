using System;
using System.ComponentModel;

namespace JazzTest.Util
{
    public static class Util
    {
        /// <summary>
        /// Retorna uma string com a descrição setada para o Enum em questão.
        /// </summary>
        /// <param name="val">Enum</param>
        /// <returns>Descrição do Enum
        /// </returns>
        public static string getDescription(this Enum val)
        {
            if (!Enum.IsDefined(val.GetType(), val))
                return string.Empty;

            DescriptionAttribute[] attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
