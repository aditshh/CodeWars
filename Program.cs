using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(Kata.CreatePhoneNumber(new int[] { 4, 8, 4, 6, 3, 6, 8, 5, 8, 4 }));

            Console.WriteLine($"Oddness : {Kata.Test("1 2 2")}");

            Console.WriteLine($"Number of Years : {Kata.NbYear(1500000, 0.25, 1000, 2000000)}");
            Console.ReadKey();
        }
    }
    public class Kata
    {

        public static string CreatePhoneNumber(int[] numbers)
        {
            return $"{ulong.Parse(string.Concat(numbers)):(000) 000-0000}";
        }

        /// <summary>
        /// Bob is preparing to pass IQ test. The most frequent task in this test is to find out which one of the given numbers differs from the others. Bob observed that one number usually differs from the others in evenness. Help Bob — to check his answers, he needs a program that among the given numbers finds one that is different in evenness, and return a position of this number.
        /// ! Keep in mind that your task is to help Bob solve a real IQ test, which means indexes of the elements start from 1 (not 0)
        /// ##Examples :
        /// IQ.Test("2 4 7 8 10") => 3 // Third number is odd, while the rest of the numbers are even
        /// IQ.Test("1 2 1 1") => 2 // Second number is even, while the rest of the numbers are odd
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static int Test(string numbers)
        {
            //Your code is here...
            int[] number = Array.ConvertAll(numbers.Split(' ').ToArray(), int.Parse);
            int[] even = number.Where(x => x % 2 == 0).ToArray();
            int[] odd = number.Where(x => x % 2 != 0).ToArray();

            if (odd.Count() > even.Count())
            {
                int index = Array.IndexOf(number, even[0]);
                return index + 1;
            }
            else
            {
                int index = Array.IndexOf(number, odd[0]);

                return index + 1;
            }
        }


        /// <summary>
        /// https://www.codewars.com/kata/563b662a59afc2b5120000c6/train/csharp
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="percent"></param>
        /// <param name="aug"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int NbYear(int p0, double percent, int aug, int p)
        {
            int year;
            for (year = 0; p0 < p; year++)
                p0 += (int)(p0 * percent / 100) + aug;
            return year;
        }
    }
}
