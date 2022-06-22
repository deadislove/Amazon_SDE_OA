using Amazon_SDE_OA.Interface;

namespace Amazon_SDE_OA.Music_Pairs
{
    internal class Music_Pairs : ISolution
    {
        public void Solution() {

            Console.WriteLine("Music Pairs");
            var Input = new int[] { 30, 20, 150, 100, 40 };
            var Output = NumPairsDivisibleBy60(Input);
            Console.WriteLine($"Ans: {Output}");

            Dispose();
        }

        public int NumPairsDivisibleBy60(int[] time)
        {
            int count = 0;
            int mod = 0;
            int[] lookup = new int[60];

            for (int i = 0; i < time.Length; i++)
            {
                mod = time[i] % 60;
                count += lookup[(mod == 0) ? 0 : 60 - mod];
                lookup[mod]++;
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
