using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace TOSA
{
    public static class Helpers
    {

        public static IEnumerable<T> ExtractValues<T>(this TextReader reader, char separator = ' ')
        {
            var line = reader.ReadLine();
            return line.ExtractValues<T>(separator);
        }

        public static T Convert<T>(this string input)
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            return (T)converter.ConvertFromString(input);
        }

        public static IEnumerable<T> ExtractValues<T>(this string input, char separator = ' ')
        {
            var splited = input.Split(separator);
            if (typeof (T) == typeof (string)) return splited as IEnumerable<T>;
            var result = splited.Select(Convert<T>);
            return result;
        }

        #region simple linq extension

        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (T item in enumeration) { action(item); }
        }
        
        #endregion
    }
}
