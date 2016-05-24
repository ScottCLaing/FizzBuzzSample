using FizzBuzzLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzCaller
{
    class Program
    {
        static void Main(string[] args)
        {
            var fizzBuzzLib = new FizzBuzz();
            var specialCases = new Dictionary<int, string>();
            specialCases[3] = " Fizz";
            specialCases[5] = " Buzz";
            specialCases[7] = " Hello";
            specialCases[11] = " Goodbye";
            var results = fizzBuzzLib.GetFizzBuzz(specialCases);
            Console.Write(results);
        }
    }
}
