using Amazon_SDE_OA.Interface;

namespace Amazon_SDE_OA.Shipment_Imbalance
{
    internal class Shipment_Imbalance : ISolution
    {
        public void Solution() {
            Console.WriteLine("Shipment Imbalance");

            var Input = new int[] { 1, 2, 3 };
            var Output = SubArrayRanges(Input);
            Console.WriteLine("Example 1");
            Console.WriteLine($"Ans:{Output}");
            Console.WriteLine("Example 2");
            Input = new int[] { 1, 3, 3 };
            Output = SubArrayRanges(Input);
            Console.WriteLine($"Ans: {Output}");
        }

        public long SubArrayRanges(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            // Sum of subarray ranges = Sum of subarry max - Sum of subarry min

            long res = 0;
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i <= nums.Length; i++)
            {
                while (stack.Count > 0 && nums[stack.Peek()] > (i == nums.Length ? Int32.MinValue : nums[i]))
                {
                    int midIdx = stack.Pop();
                    int leftBoundary = stack.Count == 0 ? -1 : stack.Peek();
                    int rightBoundary = i;

                    res -= (long)nums[midIdx] * (midIdx - leftBoundary) * (rightBoundary - midIdx);
                }

                stack.Push(i);
            }

            stack.Clear();
            for (int i = 0; i <= nums.Length; i++)
            {
                while (stack.Count > 0 && nums[stack.Peek()] < (i == nums.Length ? Int32.MaxValue : nums[i]))
                {
                    int midIdx = stack.Pop();
                    int leftBoundary = stack.Count == 0 ? -1 : stack.Peek();
                    int rightBoundary = i;

                    res += (long)nums[midIdx] * (midIdx - leftBoundary) * (rightBoundary - midIdx);
                }

                stack.Push(i);
            }

            return res;
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
