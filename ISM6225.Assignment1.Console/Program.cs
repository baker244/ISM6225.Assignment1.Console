using System.Collections.Generic;

namespace ISM6225.Assignment1.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var marks = new int[] { 5, 6, 6, 9, 9, 12 };
            var target = 9;

            var result = TargetRange(marks, target);

            if (result[0] == -1 && result[1] == -1)
                System.Console.WriteLine("Target does not exist: [-1, -1]");
            else
                System.Console.WriteLine("Target exists: [" + string.Join(", ", result) + "]");
        }

        /// <summary>
        /// Question 1. Find the initial and final index of a given target point’s value
        /// </summary>
        /// <param name="marks"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TargetRange(int[] marks, int target)
        {
            var result = new List<int>();

            for (var i = 0; i < marks.Length; i++)
            {
                if (marks[i] == target)
                    result.Add(i);
            }

            if (result.Count == 0)
            {
                result.Add(-1);
                result.Add(-1);
            }

            return result.ToArray();
        }
    }
}
