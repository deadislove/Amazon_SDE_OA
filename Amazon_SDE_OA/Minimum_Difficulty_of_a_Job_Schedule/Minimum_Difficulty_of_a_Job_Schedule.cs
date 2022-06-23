using Amazon_SDE_OA.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_SDE_OA.Minimum_Difficulty_of_a_Job_Schedule
{
    internal class Minimum_Difficulty_of_a_Job_Schedule : ISolution
    {
        public void Solution() {
            Console.WriteLine("Minimum Difficulty of a Job Schedule");
            Console.WriteLine("Example 1");
            var Result = MinDifficulty(new int[] { 6, 5, 4, 3, 2,1 }, 2);
            Console.WriteLine($"Ans: {Result}");

            Console.WriteLine("Example 2");
            Result = MinDifficulty(new int[] { 9,9,9 }, 4);
            Console.WriteLine($"Ans: {Result}");

            Console.WriteLine("Example 3");
            Result = MinDifficulty(new int[] { 1, 1, 1 }, 3);
            Console.WriteLine($"Ans: {Result}");

            Console.WriteLine("Example 4");
            Result = MinDifficulty(new int[] { 7, 1, 7, 1, 7, 1 }, 3);
            Console.WriteLine($"Ans: {Result}");
        }

        public int MinDifficulty(int[] jobDifficulty, int d)
        {
            int len = jobDifficulty.Length;
            if (len < d) return -1;
            int[][] data = new int[len][];
            int[][] max = new int[len][];
            for (int i = 0; i < len; i++)
            {
                data[i] = new int[d];
                max[i] = new int[len];
                max[i][i] = jobDifficulty[i];
                for (int j = i + 1; j < len; j++)
                {
                    max[i][j] = Math.Max(max[i][j - 1], jobDifficulty[j]);
                }
                data[i][0] = max[i][len - 1];
            }
            for (int i = 1; i < d; i++)
            {
                for (int j = len - i - 1; j >= 0; j--)
                {
                    int t = int.MaxValue;
                    for (int k = j; k < len - i; k++)
                    {
                        t = Math.Min(t, max[j][k] + data[k + 1][i - 1]);
                    }
                    data[j][i] = t;
                }
            }
            return data[0][d - 1];
        }

        #region Dispose mechanism
        /// <summary>
        /// Dispose mechanism.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
