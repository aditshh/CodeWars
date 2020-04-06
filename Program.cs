using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{
    class Program
    {
        static void Main(string[] args)
        {

            //Kata.PigIt("Pig latin is cool"); // igPay atinlay siay oolcay
            //Kata.PigIt("Hello world !");     // elloHay orldway !

            //Kata.SongDecoder("WUBWEWUBAREWUBWUBTHEWUBCHAMPIONSWUBMYWUBFRIENDWUB");
            //Kata.PlayingWithDigits(89, 1);
            //Kata.PlayingWithDigits(46288, 3);

            //Kata.DetectPangram("tt");
            //Kata.FindTheOddInt(new[] { 20, 1, -1, 2, -2, 3, 3, 5, 5, 1, 2, 4, 20, 4, -1, -2, 5 });
            //Kata.Tribonnaci(new double[] { 1, 1, 1 }, 10);
            //Kata.Tribonnaci(new double[] { 0, 0, 1 }, 10);

            //Kata.CamelCase("MY Name Is Shawn");
            Kata.StripComments("apples, pears # and bananas\ngrapes\nbananas !apples", new[] { "#", "!" });

            // Kata.VasyaClerk(new int[] { 25, 25, 50 }); // NO
            // Kata.VasyaClerk(new int[] { 25, 100 }); // NO 
            // Kata.VasyaClerk(new int[] { 25, 25, 50, 50, 100 }); // No


            //Console.WriteLine(Kata.CreatePhoneNumber(new int[] { 4, 8, 4, 6, 3, 6, 8, 5, 8, 4 }));

            //Console.WriteLine($"Oddness : {Kata.Test("1 2 2")}");

            //Console.WriteLine($"Number of Years : {Kata.NbYear(1500000, 0.25, 1000, 2000000)}");

            //Console.WriteLine($"Middle Letter : {Kata.GetMiddle("t")}");
            Console.ReadKey();
        }
    }
    public class Kata
    {
        /// <summary>
        /// https://www.codewars.com/kata/51c8e37cee245da6b40000bd/csharp
        /// </summary>
        /// <param name="input"></param>
        /// <param name="spliter"></param>
        /// <returns></returns>
        public static string StripComments(string input, string[] spliter)
        {
            // "apples, pears # and bananas\ngrapes\nbananas !apples", new [] { "#", "!" }
            string[] arr = input.Split('\n');
            for (int i = 0; i < arr.Count(); i++)
            {
                foreach (var split in spliter)
                {
                    if (arr[i].Contains(split))
                    {
                        arr[i] = arr[i].Substring(0, arr[i].IndexOf(split));
                    }
                    arr[i] = arr[i].TrimEnd();
                }
            }
            return String.Join("\n",arr);
        }

        /// <summary>
        /// https://www.codewars.com/kata/587731fda577b3d1b0001196/csharp
        /// </summary>
        public static string CamelCase(string input)
        {
            string[] word = input.Split(' ');
            string final = "";
            
            foreach (var item in word.Where(x=>x!= string.Empty))
            {
                if (item.Length>0)
                {
                    final += Char.ToUpper(item[0]) + item.Substring(1).ToLower();
                }
                else
                {
                    final += Char.ToUpper(item[0]);
                }
            }
            return final;
        }

        /// <summary>
        /// https://www.codewars.com/kata/556deca17c58da83c00002db/csharp
        /// </summary>
        /// <param name="seq"></param>
        public static double[] Tribonnaci(double[] signature, int n)
        {
            List<double> signList = signature.ToList();
            if (n == 0)
            {
                // return empty array
                return new double[] { };
            }

            for (int i = 0; i < n; i++)
            {
                int index = signList.Count() - 1;
                double nextNumb = signList[index - 2] + signList[index - 1] + signList[index];
                signList.Add(nextNumb);
            }
            return signList.Take(n).ToArray();
        }

        /// <summary>
        /// https://www.codewars.com/kata/545cedaa9943f7fe7b000048/csharp
        /// </summary>
        /// <returns></returns>
        public static bool DetectPangram(string input)
        {
            int index = 0;
            bool[] mark = new bool[26];
            for (int i = 0; i < input.Length; i++)
            {
                if ('A' <= input[i] && input[i] <= 'Z')
                    index = input[i] - 'A';
                else if ('a' <= input[i] && input[i] <= 'z')
                    index = input[i] - 'a';
                else
                    continue;

                mark[index] = true;
            }
            foreach (var b in mark)
            {
                if (b == false)
                {
                    return false;
                }
            }
            //65 to 90
            return true;

            // Second solution: 
            //     return str.Where(ch => Char.IsLetter(ch)).Select(ch => Char.ToLower(ch)).Distinct().Count() == 26;

        }


        /// <summary>
        /// https://www.codewars.com/kata/54da5a58ea159efa38000836/csharp
        /// </summary>
        /// <param name="input"></param>
        public static void FindTheOddInt(int[] input)
        {
            var tGroupBy = input.GroupBy(x => x).Distinct();

            var t = tGroupBy.Where(x => x.Count() % 2 != 0).OrderByDescending(x => x.Count()).ToList();

            if (t.FirstOrDefault() != null)
            {
                int max = t.FirstOrDefault().Key;
            }

            //int max = seq.GroupBy(x => x).Single(g => g.Count() % 2 == 1).Key;
        }

        /// <summary>
        /// https://www.codewars.com/kata/555615a77ebc7c2c8a0000b8/csharp
        /// </summary>
        /// <param name="peopleInLine"></param>
        /// <returns></returns>
        public static string VasyaClerk(int[] peopleInLine)
        {
            //    int m25 = 0, m50 = 0;
            //    for (int i = 0; i < p.Length & m25 >= 0; i++)
            //    {
            //        m25 += (p[i] == 25 ? 25 : p[i] == 50 ? -25 : m50 < 50 ? -75 : -25);
            //        m50 += (p[i] == 25 ? 0 : p[i] == 50 ? 50 : m50 < 50 ? 0 : -50);
            //    }
            //    return m25 < 0 ? "NO" : "YES";

            string final = "";
            int twentyFives = 0, fifties = 0;

            foreach (var bill in peopleInLine)
            {
                switch (bill)
                {
                    case 25:
                        ++twentyFives;
                        break;
                    case 50:
                        --twentyFives;
                        ++fifties;
                        break;
                    case 100:
                        if (fifties == 0)
                        {
                            twentyFives -= 3;
                        }
                        else
                        {
                            --twentyFives;
                            --fifties;
                        }
                        break;
                }

                if (twentyFives < 0 || fifties < 0)
                {
                    return "NO";
                }
            }

            return "YES";
        }

        /// <summary>
        /// https://www.codewars.com/kata/5552101f47fc5178b1000050/csharp
        /// </summary>
        /// <param name="n"></param>
        /// <param name="p"></param>
        public static void PlayingWithDigits(int n, int p)
        {

            //digPow(89, 1) should return 1 since 8¹ + 9² = 89 = 89 * 1
            int t = 0;
            int compareWith = n * p;

            char[] ts = n.ToString().ToCharArray();

            // 46288, 3 = 4^3, 6^4, 2^5, 8^6, 8^7

            for (int i = 0; i < n.ToString().Length; i++)
            {
                int o = Convert.ToInt32(ts[i] - '0');
                int power = i + p;
                int sq = (int)Math.Pow(o, power);
                t += sq;
            }

            if (t % n == 0)
            {
                // find k
                long k = compareWith / n;
            }
            else
            {
                long t3 = -1;
            }
        }

        /// <summary>
        /// https://www.codewars.com/kata/551dc350bf4e526099000ae5/csharp
        /// </summary>
        /// <param name="songString"></param>
        public static void SongDecoder(string input)
        {
            // WUBWEWUBAREWUBWUBTHEWUBCHAMPIONSWUBMYWUBFRIENDWUB
            input = "WUBWWUBUWUBWUBB";
            string[] t1 = input.Replace("WUB", " ").Trim().Split(' ');
            string final = String.Join(" ", t1.Where(x => !String.IsNullOrWhiteSpace(x)));
        }

        /// <summary>
        /// https://www.codewars.com/kata/520b9d2ad5c005041100000f/train/csharp
        /// </summary>
        /// <param name="text"></param>
        public static void PigIt(string text)
        {
            string[] words = text.Split(' ');
            string finalString = "";
            foreach (var word in words)
            {
                if (word.Length > 1)
                {
                    // Pig ==> igPay
                    string reFormat = $"{word.Substring(1)}{word.ToCharArray()[0]}ay";
                    finalString += reFormat + " ";
                }
            }
            var t = finalString;
            Console.WriteLine(finalString);
        }

        /// <summary>
        /// https://www.codewars.com/kata/56747fd5cb988479af000028/train/csharp
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string GetMiddle(string s)
        {
            return s.Length % 2 == 0 ? s.Substring((s.Length / 2) - 1, 2) : s.Substring((s.Length / 2), 1);
        }

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
