﻿using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISM6225.Assignment1.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Call Question 1 - TargetRange
            var marks = new int[] { 5, 9, 6, 9, 9, 12 };
            var target = 5;

            var q1Result = TargetRange(marks, target);

            System.Console.WriteLine("Question 1:");
            if (q1Result[0] == -1 && q1Result[1] == -1)
                System.Console.WriteLine("Target does not exist: [-1, -1]");
            else
                System.Console.WriteLine("Target exists: [" + string.Join(", ", q1Result) + "]");
            #endregion

            #region Call Question 2 - StringReverse
            var q2Input = "University of South Florida";

            var q2Result = StringReverse(q2Input);

            System.Console.WriteLine("Question 2:");
            System.Console.WriteLine(q2Result);
            #endregion

            #region Call Question 3 - MinSum
            var q3Input = new int[] { 2, 2, 3, 5, 6 };

            var q3Result = MinSum(q3Input);

            System.Console.WriteLine("Question 3:");
            System.Console.WriteLine(q3Result);
            #endregion

            #region Call Question 4 - FreqSort
            var q4Input = "Dell";

            var q4Result = FreqSort(q4Input);

            System.Console.WriteLine("Question 4:");
            System.Console.WriteLine(q4Result);
            #endregion

            #region Call Question 5 - Intersect1
            var nums1 = new int[] { 3, 6, 2 };
            var nums2 = new int[] { 6, 3, 6, 7, 3 };

            var q5Result = Intersect1(nums1, nums2);

            System.Console.WriteLine("Question 5:");
            System.Console.WriteLine(q5Result);
            #endregion

            #region Call Question 6 - ContainsDuplicate
            var arr = new char[] { 'a', 'g', 'h', 'a' };
            var k = 2;

            var q6Result = ContainsDuplicate(arr, k);

            System.Console.WriteLine("Question 6:");
            System.Console.WriteLine(q6Result);
            #endregion
        }

        /// <summary>
        /// Question 1: Find the initial and final index of a given target point’s value.
        /// </summary>
        /// <param name="marks"></param>
        /// <param name="target"></param>
        /// <returns>inital and final indices</returns>
        public static int[] TargetRange(int[] marks, int target)
        {
            var result = new List<int>();

            for (var i = 0; i < marks.Length; i++)
            {
                if (marks[i] == target)
                    result.Add(i);
            }

            // If the target wasn't found, include -1, -1
            if (result.Count == 0)
            {
                result.Add(-1);
                result.Add(-1);
            }
            // If the target was only found once, include the same index again as the final index
            else if (result.Count == 1)
                result.Add(result[0]);
            // If the target was found more than two times, use RemoveRange to include the initial and final only
            else if (result.Count > 2)
                result.RemoveRange(1, result.Count - 2);

            return result.ToArray();
        }

        /// <summary>
        /// Question 2: Reverse the order of characters in each word within a sentence while 
        /// still preserving whitespace and initial word order.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Reversed string</returns>
        public static string StringReverse(string input)
        {
            var words = input.Split(" ");
            var sb = new StringBuilder();

            foreach (var word in words)
            {
                for (var i = word.Length - 1; i > -1; i--)
                    sb.Append(word[i]);

                sb.Append(" ");
            }

            return sb.ToString().Trim();
        }

        /// <summary>
        /// Question 3: Makes the array elements distinct by increasing each value as needed, 
        /// while minimizing the array sum.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int MinSum(int[] input)
        {
            for (var i = 0; i < input.Length; i++)
            {
                for (var a = i + 1; a < input.Length; a++)
                {
                    if (input[i] == input[a])
                        input[a] += 1;
                }
            }

            return input.Sum();
        }

        /// <summary>
        /// Question 4: Sort the given string in decreasing order of frequency of occurence of each character.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string FreqSort(string s)
        {
            var dictionary = new Dictionary<char, int>();
            var sb = new StringBuilder();
            
            foreach (var character in s)
            {
                if (dictionary.ContainsKey(character))
                    dictionary[character]++;
                else
                    dictionary.Add(character, 1);
            }

            foreach (var item in dictionary.OrderByDescending(key => key.Value))
            {
                var i = 0;
                
                while (i < item.Value)
                {
                    sb.Append(item.Key);
                    i++;
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Question 5. Computes the intersection of two sets. 
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public static int[] Intersect1(int[] nums1, int[] nums2)
        {
            var intersects = new List<int>();

            foreach (var num1 in nums1)
            {
                foreach (var num2 in nums2)
                {
                    if (num1 == num2)
                    {
                        intersects.Add(num1);
                        break;
                    }
                }
            }

            return intersects.ToArray();
        }

        /// <summary>
        /// Question 6.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static bool ContainsDuplicate(char[] arr, int k)
        {
            return false;
        }
    }
}
