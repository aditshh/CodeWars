using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

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
            //Kata.StripComments("apples, pears # and bananas\ngrapes\nbananas !apples", new[] { "#", "!" });

            // var t1 = Kata.FindMaxConsecutiveOnes(new[] { 1, 1, 0, 1, 1, 1, 0, 1 });
            //var t1 = Kata.SortedSquares(new[] { -4, -1, 0, 3, 10 });
            //Kata.DuplicateZeros(new[] { 1, 0, 2, 3, 0, 4, 5, 0 });
            // nums1 = [1,2,3,0,0,0], m = 3, nums2 = [2,5,6], n = 3

            //Kata.Merge(new[] { 1, 2, 3, 0, 0, 0 }, 3, new[] { 2, 5, 6 }, 3);
            //nums = [3,2,2,3], val = 3
            //Kata.RemoveElement(new[] { 3, 2, 2, 3 }, 3);

            //Kata.MinWindow("ADOBECODEBANC", "ABC");
            //Kata.TwoSums(new[] { 1, 2, 4, 5, 6, 7, 9 }, 8);
            //Kata.BestBuySellStock(new[] { 1, 7, 4, 11 });
            // Kata.VasyaClerk(new int[] { 25, 25, 50 }); // NO
            // Kata.VasyaClerk(new int[] { 25, 100 }); // NO 
            // Kata.VasyaClerk(new int[] { 25, 25, 50, 50, 100 }); // No


            //Console.WriteLine(Kata.CreatePhoneNumber(new int[] { 4, 8, 4, 6, 3, 6, 8, 5, 8, 4 }));

            //Console.WriteLine($"Oddness : {Kata.Test("1 2 2")}");

            //Console.WriteLine($"Number of Years : {Kata.NbYear(1500000, 0.25, 1000, 2000000)}");

            //Console.WriteLine($"Middle Letter : {Kata.GetMiddle("t")}");

            //Kata.ContainsDuplicate(new[] { 1, 2, 3, 4, 1 });
            //Kata.ContainsDuplicate2(new[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 });
            //Kata.MaxProduct(new[] { 2, 3, -2, 4 });
            Kata.FindMin(new[] { 4, 5, 6, 7, 0, 1, 2 });

            Console.ReadKey();
        }
    }
    public class Kata
    {
        /// <summary>
        /// https://leetcode.com/problems/search-in-rotated-sorted-array/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Search(int[] nums, int target)
        {
            /*
             * Input: nums = [4,5,6,7,0,1,2], target = 0
             * Output: 4
             */
            if (nums.Length == 1)
            {
                return nums[0] == target ? 0 : -1;
            }

            int left = 0, right = nums.Length - 1;
            int mid = left + (right - left)

            return -1;
        }

        /// <summary>
        /// https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FindMin(int[] nums)
        {
            // If the list has just one element then return that element.
            if (nums.Length == 1)
            {
                return nums[0];
            }

            // initializing left and right pointers.
            int left = 0, right = nums.Length - 1;

            // if the last element is greater than the first element then there is no rotation.
            // e.g. 1 < 2 < 3 < 4 < 5 < 7. Already sorted array.
            // Hence the smallest element is first element. A[0]
            if (nums[right] > nums[0])
            {
                return nums[0];
            }

            // Binary search way
            while (right >= left)
            {
                // Find the mid element
                int mid = left + (right - left) / 2;

                // if the mid element is greater than its next element then mid+1 element is the smallest
                // This point would be the point of change. From higher to lower value.
                if (nums[mid] > nums[mid + 1])
                {
                    return nums[mid + 1];
                }

                // if the mid element is lesser than its previous element then mid element is the smallest
                if (nums[mid - 1] > nums[mid])
                {
                    return nums[mid];
                }

                // if the mid elements value is greater than the 0th element this means
                // the least value is still somewhere to the right as we are still dealing with elements
                // greater than nums[0]
                if (nums[mid] > nums[0])
                {
                    left = mid + 1;
                }
                else
                {
                    // if nums[0] is greater than the mid value then this means the smallest value is somewhere to
                    // the left
                    right = mid - 1;
                }
            }
            return -1;
        }

        //public static int FindMin(int[] nums)
        //{
        //    /* Input: nums = [4,5,6,7,0,1,2]
        //     * Output: 0
        //     * Explanation: The original array was [0,1,2,4,5,6,7] and it was rotated 4 times.
        //     */

        //    //if (nums.Length == 1) return nums[0];

        //    //int min = int.MaxValue;
        //    //int localMin = int.MaxValue;
        //    //int n = nums.Length;
        //    //for (int i = n-1; i > 0; i--)
        //    //{
        //    //    localMin = Math.Min(nums[i], nums[i - 1]);
        //    //    min = Math.Min(min, localMin);
        //    //}

        //    //return min;



        //}

        /// <summary>
        /// https://leetcode.com/problems/maximum-product-subarray
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int MaxProduct(int[] nums)
        {
            int maxProduct = nums[0];
            int n = nums.Length;
            int leftEndProduct = 1, rightEndProduct = 1;
            for (int i = 0; i < n; i++)
            {
                // reset to 1 when the product becomes zero
                leftEndProduct = (leftEndProduct == 0 ? 1 : leftEndProduct) * nums[i];
                rightEndProduct = (rightEndProduct == 0 ? 1 : rightEndProduct) * nums[n - 1 - i];
                maxProduct = Math.Max(maxProduct, Math.Max(leftEndProduct, rightEndProduct));
            }

            return maxProduct;
        }



        /// <summary>
        /// https://leetcode.com/problems/product-of-array-except-self/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] ProductExceptSelf(int[] nums)
        {
            // Input: nums = [1, 2, 3, 4]
            // Output: [24, 12, 8, 6]
            if (nums == null || nums.Length < 2)
                return nums;

            int[] result = new int[nums.Length];

            int left = 1; // For the array travel from left to right
            for (int i = 0; i < nums.Length; i++)
            {
                result[i] = left; // add left value to result array
                left *= nums[i]; // calculate left value
            }

            int right = 1; // For the array travel from right to left
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                result[i] *= right; // add right value to result array
                right *= nums[i]; // calculate right value
            }

            return result;
        }

        /// <summary>
        /// https://leetcode.com/problems/contains-duplicate/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static bool ContainsDuplicate2(int[] nums)
        {
            var set = new HashSet<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                set.Add(nums[i]);
            }

            return nums.Length != set.Count();
        }

        /// <summary>
        /// https://leetcode.com/problems/contains-duplicate/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static bool ContainsDuplicate(int[] nums)
        {
            var numberDictionary = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                numberDictionary[num] = numberDictionary.ContainsKey(num) ? numberDictionary[num] + 1 : 1;

                if (numberDictionary[num] > 1)
                {
                    return true;
                }
            }
            return false;
        }

        internal static int BestBuySellStock(int[] prices)
        {
            int local_max = 0, global_max = int.MinValue;
            for (int i = 1; i < prices.Length; i++)
            {
                int t1 = local_max + prices[i] - prices[i - 1];
                local_max = Math.Max(0, local_max += prices[i] - prices[i - 1]);
                global_max = Math.Max(local_max, global_max);
            }
            return global_max;
            //int n = prices.Length;
            //int local_max = 0, global_max = int.MinValue;

            //for (int i = 0; i < n; i++)
            //{
            //    local_max = Math.Max(prices[i], prices[i] + local_max);
            //    if (local_max > global_max)
            //    {
            //        global_max = local_max;
            //    }
            //}

            //return global_max;
        }
        public static int[] TwoSums(int[] nums, int target)
        {

            if (nums == null || nums.Length < 2)
                return new int[2];

            Dictionary<int, int> dic = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (dic.ContainsKey(target - nums[i]))
                    return new int[] { i, dic[target - nums[i]] };
                else if (!dic.ContainsKey(nums[i]))
                    dic.Add(nums[i], i);
            }

            return new int[2];
        }
        public static int[] SortedSquares(int[] nums)
        {
            int[] res = new int[nums.Length];
            int start = 0;
            int end = nums.Length - 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (Math.Abs(nums[start]) > Math.Abs(nums[end]))
                {
                    res[i] = nums[start] * nums[start];
                    start++;
                }
                else
                {
                    res[i] = nums[end] * nums[end];
                    end--;
                }

            }
            return res;
        }

        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1;
            int j = n - 1;
            for (int k = nums1.Length - 1; k >= 0; k--)
            {
                var left = i >= 0 ? nums1[i] : int.MinValue;
                var right = j >= 0 ? nums2[j] : int.MinValue;


                if (left >= right)
                    nums1[k] = nums1[i--];
                else
                    nums1[k] = nums2[j--];
            }

        }

        public static string MinWindow(string s, string t)
        {
            var dict = new Dictionary<char, int>();
            foreach (var ch in t)
                dict[ch] = dict.ContainsKey(ch) ? dict[ch] + 1 : 1;

            int curBegin = 0, curEnd = 0, needCharactersCount = t.Length,
                begin = 0, end = int.MaxValue;
            while (curEnd < s.Length)
            {
                if (dict.ContainsKey(s[curEnd]))
                {
                    dict[s[curEnd]]--;
                    if (dict[s[curEnd]] >= 0)
                        needCharactersCount--;
                }

                while (needCharactersCount == 0)
                {
                    if (end - begin > curEnd - curBegin)
                    {
                        begin = curBegin;
                        end = curEnd;
                    }

                    if (dict.ContainsKey(s[curBegin]))
                    {
                        dict[s[curBegin]]++;
                        if (dict[s[curBegin]] > 0)
                            needCharactersCount++;
                    }

                    curBegin++;
                }

                curEnd++;
            }

            return end == int.MaxValue ? "" : s.Substring(begin, end - begin + 1);
        }

        public static int RemoveElement(int[] nums, int val)
        {
            // nums = [3,2,2,3], val = 3
            int count = 0;
            int length = nums.Length;
            for (int i = nums.Length - 1; i > 0; i--)
            {
                if (nums[i] == val)
                {
                    length--;
                    // dellll
                    nums[length--] = nums[i];
                }
            }
            return count;
        }

        public static void DuplicateZeros(int[] arr)
        {
            //  Input: arr = [1, 0, 2, 3, 0, 4, 5, 0]
            //  Output: [1, 0, 0, 2, 3, 0, 0, 4]
            //  index of Zero

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] == 0)
                {
                    // duplicate it!
                    for (int j = arr.Length - 1; j > i; j--)
                    {
                        arr[j] = arr[j - 1];
                    }
                }
            }
        }

        public static int FindNumbers(int[] nums)
        {

            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                var t1 = nums[i].ToString().Length;
                if (t1 % 2 == 0)
                {
                    ++count;
                }
            }
            return count;
        }
        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            int max = 0;
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (nums[i] == 0)    // reset sum to zero when encounters zeros
                    sum = 0;
                else                // keep update max
                    max = Math.Max(max, sum);
            }
            return max;
        }

        public static string sumStrings(string a, string b)
        {
            Double.TryParse(a, out double aD);
            Double.TryParse(b, out double bD);

            Double sum = (aD + bD);
            return sum.ToString();
        }
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
            return String.Join("\n", arr);
        }

        /// <summary>
        /// https://www.codewars.com/kata/587731fda577b3d1b0001196/csharp
        /// </summary>
        public static string CamelCase(string input)
        {
            string[] word = input.Split(' ');
            string final = "";

            foreach (var item in word.Where(x => x != string.Empty))
            {
                if (item.Length > 0)
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
