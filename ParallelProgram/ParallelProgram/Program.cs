using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgram
{
    internal static class Program
    {
        public static void write(char c)
        {
            int i = 1000;
            while (i --> 0)
            {
                Console.Write(c);
            }
        }

        public static void write(object o)
        {
            int i = 1000;
            while (i-- > 0)
            {
                Console.Write(o);
            }
        }

        public static int TextLength(object o)
        {
            Console.WriteLine($"\nTask with Id {Task.CurrentId} processing object {o}...");
            return o.ToString().Length;
        }

        public static void GenericReturn()
        {
            string text1 = "Testing", text2 = "this";
            var task1 = new Task<int>(TextLength, text1);
            task1.Start();

            Task<int> task = Task.Factory.StartNew(TextLength, text2);

            Console.WriteLine($"Length of {text1} is {task1.Result}");
            Console.WriteLine($"Length of {text2} is {task.Result}");
        }

        //Cancellation of Task

        public static void Cancel()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            Task.Factory.StartNew(() =>
            {
                int i = 0;
                while (true)
                {
                    if(cts.IsCancellationRequested)
                        break;
                    else
                    Console.WriteLine(i++);
                }

                
            },token);

            Console.ReadKey();
            cts.Cancel();
        }
       public static void Main(string[] args)
       {
          
//           Task t = new Task(write,"hello");
//           t.Start();
//           Task.Factory.StartNew(write, 1233223);

//           Task.Factory.StartNew(() => write('.'));
//           var t = new Task(()=>write('?'));
//           t.Start();
//           write('*');
           Cancel();
           Console.ReadKey();
           
       }
    }
}
