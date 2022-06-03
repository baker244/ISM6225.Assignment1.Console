using System.Collections.Generic;
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

            /// Christopher Tate - If we want User Input
            /// target = Convert.ToInt32(Console.ReadLine());
            var q1Result = TargetRange(marks, target);

            System.Console.WriteLine("Question 1:");
            if (q1Result[0] == -1 && q1Result[1] == -1)
                System.Console.WriteLine("Target does not exist: [-1, -1]");
            else
                System.Console.WriteLine("Target exists: [" + string.Join(", ", q1Result) + "]");
            #endregion

            #region Call Question 2 - StringReverse
            var q2Input = "University of South Florida";
            /// Christopher Tate - If we want to reverse User Input
            /// q2Input = Console.ReadLine();

            var q2Result = StringReverse(q2Input);

            System.Console.WriteLine("Question 2:");
            System.Console.WriteLine("University of South Florida");
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
            System.Console.WriteLine(q4Input);
            System.Console.WriteLine(q4Result);
            #endregion

            #region Call Question 5 - Intersect1
            var nums1 = new int[] { 3, 6, 2 };
            var nums2 = new int[] { 6, 3, 6, 7, 3 };

            var q5Result = Intersect1(nums1, nums2);

            System.Console.WriteLine("Question 5:");
            System.Console.WriteLine("Array 1 - " + string.Join(", ", nums1));
            System.Console.WriteLine("Array 2 - " + string.Join(", ", nums2));
            System.Console.WriteLine("[" + string.Join(", ", q5Result) + "]");
            #endregion

            #region Call Question 6 - ContainsDuplicate
            var arr = new char[] { 'a', 'b', 'c', 'a', 'b', 'c' };
            var k = 2;

            var q6Result = ContainsDuplicate(arr, k);

            System.Console.WriteLine("Question 6:");
            /// Christopher Tate
            System.Console.WriteLine("Array - " + string.Join(", ", arr));
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
            var words = input.Split(" "); //Trenton Scribe/learning Comments - splitting the phrase into an array with every word being a index position
            var sb = new StringBuilder();

            foreach (var word in words) //storing each value in an index position as a word; words itself is the array
            {
                for (var i = word.Length - 1; i > -1; i--) //First sequence stores word as an array of chars since arrays always start with 0 instead of 1, the -1 is added to the length; second sequence tells the code block to stop executing once the loop gets to index position 0 (for example, the letter "U" for "University"; The third sequence iterates in reverse on every char of a word
                    sb.Append(word[i]); //after the index 0 char is ran through the code block the word is added to the stringbuilder

                sb.Append(" "); //a space is added to the string builder after each word every time the word is ran through the for loop
            }

            return sb.ToString().Trim(); //after each word is passed through the foreach loop, the results are added to a string. The ".Trim()" isn't necessary but it's best practice in case there are any leading white spaces
        }

        /// <summary>
        /// Question 3: Makes the array elements distinct by increasing each value as needed, 
        /// while minimizing the array sum.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int MinSum(int[] input)
        {
            for (var i = 0; i < input.Length; i++) //Trenton Scribe/learning Comments - basic for loop statement that increments at position 0, stops the loop once the iteration has executed on the last index position
            {
                for (var a = i + 1; a < input.Length; a++) //a loop within the above loop statement that says if another value in the array equals i+1 then the if statement should be executed 
                {
                    if (input[i] == input[a])//if two values in the array equal each other, the one on the right will have 1 added to it
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

            foreach (var num1 in nums1) //Trenton Scribe/learning comments - looking at each specific int in an array one at atime
            {
                foreach (var num2 in nums2) //Looking at each specific int in an array at one time at the same time as it is being done in nums1 array
                {
                    if (num1 == num2) //if a specific int in the nums1 array is equal to a specific int in nums2 array, execute the below code block
                    {
                        intersects.Add(num1); //adds the matching value between the two arrays to the intersects list
                        break; //break used instead of ++ or -- because when comparing arrays of two sizes you need to iterate to the end of the longest one
                    }
                }
            }

            return intersects.ToArray(); 
        }

        /// <summary>
        /// Question 6. A an array of characters and an integer k, and are required to find out whether 
        /// there are two distinct indices i and j in the array such that arr[i]=arr[j] and the absolute
        /// difference between i and j is at most k.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static bool ContainsDuplicate(char[] arr, int k)
        {
            var text = new string(arr);
            var condition = false;

            foreach (var letter in arr)
            {
                var last = text.LastIndexOf(letter);
                var first = text.IndexOf(letter);

                if ((last - first) <= k)
                {
                    condition = true;
                }
            }

            return condition;
        }
    }
}
