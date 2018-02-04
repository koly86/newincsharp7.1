using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {

        //async and Task insted of void for methode var c = await TallyAsync(numbers);
        static async Task Main(string[] args)
        {
            int[] numbers = {0b1, 0b10, 0b11, 0b100, 0b101, 0b110}; // 1) Convert to Binary
           object[] numbersObject = { 0b1, 0b10, new object[]{0b11, 0b100, 0b101, 0b110} }; // 1) Convert to Binary

            var t = Tally(numbers);
            Console.WriteLine($"Sum1: {t.Item2} Sum2: {t.Item2} Sum:{t.Item3} bool:{t.Item3}" ); // 5) t.Item1

            var c = await TallyAsync(numbers);

            (int s, int y, bool e) = Tally(numbers); //14
            var (b, _,_) = Tally(numbers); //15

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
        //11 Task
        private static async  Task<(int, int, bool)> TallyAsync(int[] values) 
        {
            return default;
        }
        //12 ValueTask //13 CancellationToken
        private static async ValueTask<(int, int, bool)> TallyAsyncValueTask(int[] values, CancellationToken cancellationToken = default (CancellationToken)) //or default
        {
            return default;
        }

        private static (int, int) TallyLocalFunction(int[] values) 
        {
            var r = (s: 0b0, c: 0b101); 
           
            foreach (var v in values)
            {
                //13 local function
                Add(v,1);
            }
            
            return r;
            void Add(int f, int c) => r = (r.s + f, r.c + c);
            
        }

        private static (int, int) TallyObject(object[] values) 
        {
            var r = (s: 0b0, c: 0b101);

            foreach (var v in values)
            {
                if (v is int i)
                {
                    //14 already checs if i is int
                    Add(i,1);
                }
            }

            return r;
            void Add(int f, int c) => r = (r.s + f, r.c + c);

        }

        private static (int, int) TallyObjectSwitchCase(object[] values)
        {
            var r = (s: 0b0, c: 0b101);

            foreach (var v in values)
            {
                
                switch (v)
                {
                    case int i: 
                        Add(i, 1); // 18 Shift + F12
                        break;
                    case object[] a when a.Length>0: //15 case condition
                        var (sum, count) = TallyObjectSwitchCase(a);
                        Add(sum,count);
                        break;
                    default: // 16 default can be anywhere
                        throw new ArgumentException("Not numbers!", nameof(values));
                    case object[] _:
                    case null:
                        break;
                    case string s when int.TryParse(s, out var i): //17 OUT VAR declaration or int.TryParse(s, out var _):
                        Add(i,1);
                        break;
                       

                }
            }

            return r;
            void Add(int f, int c) => r = (r.s + f, r.c + c);

        }

    }

}

