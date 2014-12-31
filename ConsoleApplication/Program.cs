using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DOUFizzBuzz;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var fb = new FizzBuzzer();
            var fbList = fb.GetAll();

            foreach (var line in fbList)
            {
                Console.WriteLine(line);
            }

            Console.ReadKey();
        }
    }
}
