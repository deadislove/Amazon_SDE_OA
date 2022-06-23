using Amazon_SDE_OA.Interface;

namespace Amazon_SDE_OA.Two_Sum_Unique_Pairs
{
    internal class Two_Sum_Unique_Pairs : ISolution
    {
        public void Solution() {
            Console.WriteLine("Two Sum Unique Pairs");
            
            Console.WriteLine("Example 1");
            var Result = getUniquePairsOpti(new int[] { 1, 1, 2, 45, 46, 46 }, 47);
            Console.WriteLine($"Ans: {Result}");

            Console.WriteLine("Example 2");
            Result = getUniquePairsOpti(new int[] { 1, 1 }, 2);
            Console.WriteLine($"Ans: {Result}");

            Console.WriteLine("Example 3");
            Result = getUniquePairsOpti(new int[] { 1, 5, 1, 5 }, 6);
            Console.WriteLine($"Ans: {Result}");
        }

        public static int getUniquePairsOpti(int[] nums, int target)
        {
            int count = 0;

            if (nums == null || nums.Length == 0)
            {
                return count;
            }

            HashSet<int> foundPairs = new HashSet<int>();
            HashSet<int> seen = new HashSet<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (seen.Contains(target - nums[i]) && !foundPairs.Contains(nums[i]))
                {
                    foundPairs.Add(nums[i]);
                    foundPairs.Add(target - nums[i]);
                    count++;
                }
                seen.Add(nums[i]);
            }

            return count;

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
