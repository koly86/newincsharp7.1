using System;
using System.Linq;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = {0b1, 0b10, 0b11, 0b100, 0b101, 0b110}; // 1) Convert to Binary
            var t = Tally(numbers);
            Console.WriteLine($"Sum1: {t.Item2} Sum2: {t.Item2} Sum:{t.Item3} bool:{t.Item3}" ); // 5) t.Item1

            Console.WriteLine();
            Console.ReadKey();

        }

        /*Tools->Options->TextEditor->C#->UserDerictives enable all +
         in VS on the left side of the name of name method press install last version */
        /* => 2) default; /*or (0,0)*/
      //  static (int sum, int count, bool b) Tally(int[] values) => default; // 11) ->  Console.WriteLine($"Sum1: {t.count} Sum2: {t.sum} Sum:{t.Item1} bool:{t.b}" );

        private static (int, int, bool) Tally(int[] values) // 8) => (0, 0, true);
        {
            var r = (s: 0b0, c: 0b101); // 9) (s: 0, c: 1);
            var g = (values: values, r:r, x:0b110111);

            var loop = (a:1, b:2, c:"df");
            foreach (var v in values)
            {
                loop = (loop.b + v, loop.b + v, loop.c+v);
            }

            // 2) default((int, int, true));
             return default;
            // 4) return (0, 0, true);
            // 10) return r  var r = (s: 0b0, c: 0b101); // 9) (s: 0, c: 1);
            // return values.Aggregate(r, (current, v) => (current.s + v, current.c + 0b1));
        }
    }

}

