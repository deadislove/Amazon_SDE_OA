using Amazon_SDE_OA.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_SDE_OA.Five_Star_Seller
{
    internal class Five_Star_Seller : ISolution
    {
        public void Solution() {

            Console.WriteLine("Five star sellers");

            int thershold = 2;
            int[][] data = new int[][] {
                new int[] {1,2},
                new int[] {3,5},
                new int[] {2,2},
            };

            Console.WriteLine("Example 1");
            var Result = GetRequiredFiveStars(data, thershold);

            Console.WriteLine($"Ans: {Result}");

            // Doesn't correct.
            Console.WriteLine("Example 2");
            data = new int[][] {
                new int[] {2,4},
                new int[] {3,9},
                new int[] {4,5},
                new int[] {2,10}
            };
            thershold = 4;
            Result = GetRequiredFiveStars(data, thershold);

            Console.WriteLine($"Ans: {Result}");
        }

        private double GetRequiredFiveStars(int[][] classes, int extraStudents)
        {
            PriorityQueue<int, double> pq = new PriorityQueue<int, double>(Comparer<double>.Create((x,y) => x.CompareTo(y)));

            for (int i = 0; i < classes.Length; i++)
            {
                if (classes[i][0].Equals(classes[i][1]))
                    continue;

                double effect = -(double)(classes[i][0]) / (double)(classes[i][1]) + (double)(classes[i][0] + 1) / (double)(classes[i][1] + 1);

                pq.Enqueue(i, effect);
            }

            while (pq.Count > 0 && extraStudents-- > 0) {

                _ = pq.Dequeue();
                pq.TryPeek(out int i, out double priority);
                
                ++classes[i][0];
                ++classes[i][1];

                double effect = -(double)(classes[i][0]) / (double)(classes[i][1]) + (double)(classes[i][0] + 1) / (double)(classes[i][1] + 1);

                pq.Enqueue(i, effect);
            }

            double ans = 0;
            
            for (int i = 0; i < classes.Length; i++)
            {
                Console.WriteLine($"{(double)(classes[i][0])}/{(double)(classes[i][1])}");
                double val = (double)(classes[i][0]) / (double)(classes[i][1]);
                ans += val;
            }
            
            return ans / (double)(classes.Length);
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
