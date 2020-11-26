using System;
using System.Collections.Generic;
using System.Text;

namespace LINQConsole
{
    public static class StringExtensions
    {

        public static IEnumerable<T> Where<T>(this IEnumerable<T> data, string property, string propertyValue)
        {
            var results = new List<T>();

            foreach (T value in data)
                //if (condizione(value))
                results.Add(value);

            return results as IEnumerable<T>;
        }

        public static double ToDouble(this string value) //vuol dire che ho esteso stringa senza modificare la classe string
        {
            double.TryParse(value, out double convertedValue);
            return convertedValue;
        }

        public static string WithPrefix(this string value, string prefix)
        {
            //string interpolation
            return $"{prefix}-{value}";
            //oppure
            //return prefix + "-" + value;
    }
}
