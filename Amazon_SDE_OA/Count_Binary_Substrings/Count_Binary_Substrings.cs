using Amazon_SDE_OA.Interface;

namespace Amazon_SDE_OA.Count_Binary_Substrings
{
    internal class Count_Binary_Substrings : ISolution
    {
        public void Solution() {
            Console.WriteLine("Count Binary Substrings");
            var Input = "00110011";
            var Output = CountBinarySubstrings(Input);
            Console.WriteLine("Example 1");
            Console.WriteLine($"Ans: {Output}");
            Console.WriteLine("Example 2");
            Input = "10101";
            Output = CountBinarySubstrings(Input);
            Console.WriteLine($"Ans: {Output}");
        }

        public int CountBinarySubstrings(string s)
        {
            if (s.Length < 2) // edge case
                return 0;

            int numSubstrings = 0;
            int prev = 0;
            int curr = 1;

            for (int i = 0; i < s.Length - 1; i++) // go from first to second-to-last char, comparing current digit with next
            {
                if (s[i] == s[i + 1])
                {
                    curr++;
                }
                else
                {
                    (prev, curr) = (curr, 1); // reset at boundary between different digits
                }
                if (prev >= curr)
                    numSubstrings++;
            }
            return numSubstrings;
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
