using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2
{
    //public delegate void Printer<T>(T data);

    public static class BufferExtensions
    {
        public static void Dump<T>(this IBuffer<T> buffer, Action<T> print)
        {
            foreach(var item in buffer)
            {
                print(item);
            }
        }

        //public static IEnumerable<TOutput> AsEnumerableOf<T, TOutput>(this IBuffer<T> buffer)
        //{
        //    var converter = TypeDescriptor.GetConverter(typeof(T));
        //    foreach (var item in buffer)
        //    {
        //        var result = (TOutput)converter.ConvertTo(item, typeof(TOutput));
        //        yield return result;
        //    }
        //}

        public static IEnumerable<TOutput> Map<T, TOutput>(this IBuffer<T> buffer, Converter<T, TOutput> converter)
        {
            return buffer.Select(i => converter(i));
        }

    }
}
