using System.Collections.Generic;

namespace ISM6225.Assignment1.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Call Question 1
            var marks = new int[] { 5, 9, 6, 9, 9, 12 };
            var target = 5;

            var result = TargetRange(marks, target);

            if (result[0] == -1 && result[1] == -1)
                System.Console.WriteLine("Target does not exist: [-1, -1]");
            else
                System.Console.WriteLine("Target exists: [" + string.Join(", ", result) + "]");
            #endregion
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
    }
}
