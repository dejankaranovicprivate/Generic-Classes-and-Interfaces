using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2
{
    class Program
    {
        //static void ConsoleWrite(double data)
        //{
        //    Console.WriteLine(data);
        //}

        static void Main(string[] args)
        {
            //Converter<double, string> converter = d => d.ToString();

            //Action<bool> print = d => Console.WriteLine(d);

            //Func<double, double> square = d => d * d;
            //Func<double, double, double> add = (x, y) => x + y;
            //Predicate<double> isLessThanTen = d => d < 10;

            //print(isLessThanTen(square(add(3, 5))));

            //var buffer = new Buffer<double>();

            var buffer = new CircularBuffer<double>(capacity: 3);
            buffer.ItemDiscarded += ItemDiscarded;

            ProcessInput(buffer);

            //var asDates = buffer.Map(d => new DateTime(2010, 1, 1).AddDays(d));
            //foreach(var date in asDates)
            //{
            //    Console.WriteLine(date);
            //}

            //var consoleOut = new Printer<double>(ConsoleWrite);

            buffer.Dump(d => Console.WriteLine(d));

            //var asInts = buffer.AsEnumerableOf<double, int>();
            //foreach(var item in asInts)
            //{
            //    Console.WriteLine(item);
            //}

            ProcessBuffer(buffer);

            Console.ReadLine();
        }

        private static void ItemDiscarded(object sender, ItemDiscardedEventArgs<double> e)
        {
            Console.WriteLine("Buffer full. Discarding {0} New item is {1}", e.ItemDiscarded, e.NewItem);
        }

        private static void ProcessBuffer(IBuffer<double> buffer)
        {
            var sum = 0.0;
            Console.WriteLine("Buffer: ");
            while(!buffer.IsEmpty)
            {
                sum += buffer.Read();
            }
            Console.WriteLine(sum);
        }

        private static void ProcessInput(IBuffer<double> buffer)
        {
            while(true)
            {
                var value = 0.0;
                var input = Console.ReadLine();

                if(double.TryParse(input, out value))
                {
                    buffer.Write(value);
                    continue;
                }
                break;
            }
        }



    }
}
