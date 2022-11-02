using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse
{
    public class Program 
    {
        static void Main(string[] args) 
        {
            ReverseString("Hello World");
            Console.WriteLine(ReverseInt(6834));
            Palindrome("Dhruv");
            Palindrome("Racecar");
            Palindrome("anna");
            Console.WriteLine(IntToRoman(15));
        }

        //Reverse string
        public static void ReverseString(string str) 
        {
            string reversed = "";
            int length;

            length = str.Length - 1;
            
            while(length >= 0)
            {
                reversed = reversed + str[length];
                length--;
            }
            Console.WriteLine(reversed.ToLower());

        }

        //Palindrome string
        public static void Palindrome(string str)
        {
            string reversed = "";
            int length;

            length = str.Length - 1;

            while (length >= 0)
            {
                reversed = reversed + str[length];
                length--;
            }
            if (reversed.ToLower() == str.ToLower())
            {
                Console.WriteLine("Palindrome");
            }
            else
            {
                Console.WriteLine("Not Palindrome");
            }
        }

        //two sum dictionary
        public static int[] TwoSumDictionary(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (dict.ContainsKey(complement))
                {
                    return new int[] { dict[complement], i };
                }
                dict.TryAdd(nums[i], i);
            }
            return new int[0];
        }

        //int to roman
        public static string IntToRoman(int num)
        {
            string[] thousands = new string[] { "", "M", "MM", "MMM" };
            string[] hundreds = new string[] { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            string[] tens = new string[] { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] ones = new string[] { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

            return thousands[num / 1000] + hundreds[num % 1000 / 100] + tens[num % 100 / 10] + ones[num % 10];
        }

        //median of two sorted arrays
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int[] nums3 = new int[nums1.Length + nums2.Length];
            int i = 0, j = 0, k = 0;
            while (i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] < nums2[j])
                {
                    nums3[k] = nums1[i];
                    i++;
                }
                else
                {
                    nums3[k] = nums2[j];
                    j++;
                }
                k++;
            }
            while (i < nums1.Length)
            {
                nums3[k] = nums1[i];
                i++;
                k++;
            }
            while (j < nums2.Length)
            {
                nums3[k] = nums2[j];
                j++;
                k++;
            }
            if (nums3.Length % 2 == 0)
            {
                return (nums3[nums3.Length / 2] + nums3[nums3.Length / 2 - 1]) / 2.0;
            }
            else
            {
                return nums3[nums3.Length / 2];
            }
        }

        //Reverse Int
        public static int ReverseInt(int x)
        {
            int reverse = 0;
            while (x != 0)
            {
                int pop = x % 10;
                x /= 10;
                if (reverse > int.MaxValue / 10 || (reverse == int.MaxValue / 10 && pop > 7)) return 0;
                if (reverse < int.MinValue / 10 || (reverse == int.MinValue / 10 && pop < -8)) return 0;
                reverse = reverse * 10 + pop;
            }
            return reverse;
        }

        //Zigzag conversion
        public static string ZigZagConversion(string s, int numRows)
        {
            if (numRows == 1) return s;

            List<StringBuilder> rows = new List<StringBuilder>();
            for (int i = 0; i < Math.Min(numRows, s.Length); i++)
                rows.Add(new StringBuilder());

            int curRow = 0;
            bool goingDown = false;

            foreach (char c in s)
            {
                rows[curRow].Append(c);
                if (curRow == 0 || curRow == numRows - 1) goingDown = !goingDown;
                curRow += goingDown ? 1 : -1;
            }

            StringBuilder ret = new StringBuilder();
            foreach (StringBuilder row in rows) ret.Append(row);
            return ret.ToString();
        }

    }
}