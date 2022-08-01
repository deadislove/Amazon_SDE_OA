using Amazon_SDE_Phone_Interview.Interface;

namespace Amazon_SDE_Phone_Interview.Binary
{
    internal class Count_Binary_Substrings : ISolution
    {
        private bool disposedValue;

        public void Solution()
        {
            Console.WriteLine("Count Binary Substrings");
            string Input = "00110011";
            int Result = CountBinarySubstrings(Input);

            Console.WriteLine($"Input: s = {Input}");
            Console.WriteLine($"Result: {Result}");

            Input = "10101";
            Result = CountBinarySubstrings(Input);

            Console.WriteLine($"Input: s = {Input}");
            Console.WriteLine($"Result: {Result}");
        }

        #region Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~Count_Binary_Substrings()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion

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
    }
}
