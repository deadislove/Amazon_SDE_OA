using Amazon_SDE_OA.Interface;

namespace Amazon_SDE_OA.Number_Game
{
    internal class Number_Game : ISolution
    {
        private int[] map;
        private int[,] dp;

        public void Solution()
        {
            int[] Input;

            var Result = 0;
            Console.WriteLine("Number Game");
            Console.WriteLine("Example 1");
            Input = new int[] { 1, 2 };
            Result = maxScore(Input);
            Console.WriteLine($"Ans: {Result} \n");

            Console.WriteLine("Example 2");
            Input = new int[] { 3, 4, 6, 8 };
            Result = maxScore(Input);
            Console.WriteLine($"Ans: {Result} \n");

            Console.WriteLine("Example 3");
            Input = new int[] { 1, 2, 3, 4, 5, 6};
            Result = maxScore(Input);
            Console.WriteLine($"Ans: {Result} \n");
        }

        public int maxScore(int[] nums)
        {
            map = new int[16384];
            Array.Fill(map, -1);
            dp = new int[nums.Length,nums.Length];
            
            for (int i = 0; i < dp.Length; i++) {
                for (int j = i + 1; j < dp.GetLength(0); j++) { 
                    dp[i,j] = gcd(nums[i], nums[j]);
                }
            }

            return find(nums, 0, 1);
        }

        private int gcd(int a, int b)
        {
            if (b.Equals(0)) return a;

            return gcd(b, a % b);
        }

        private int find(int[] nums, int mask, int idx) {
            if (map[mask] != -1) return map[mask];

            int ans = 0;

            for (int i = 0; i < nums.Length; i++) {
                for (int j = i + 1; j < nums.Length; j++) {
                    int a = (1 << i) + (1 << j);

                    if ((mask & a) == 0) { 
                        ans = Math.Max(ans, idx * dp[i,j] + find(nums, mask|a, idx +1));
                    }
                }
            }

            map[mask] = ans;

            return ans;
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
