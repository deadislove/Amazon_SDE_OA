using Amazon_SDE_OA.Interface;

namespace Amazon_SDE_OA.Slowest_key
{
    internal class Slowest_key : ISolution
    {
        public void Solution() {
            Console.WriteLine("Slowest key");

            Console.WriteLine("Example 1");
            var Input1 = new int[] { 9, 29, 49, 50};
            var Input2 = "cbcd";
            var Output = slowestKey(Input1, Input2);
            Console.WriteLine($"Ans:{Output}");

            Console.WriteLine("Example 2");
            Input1 = new int[5] { 12, 23, 36, 46, 62 };
            Input2 = "spuda";
            Output = slowestKey(Input1, Input2);
            Console.WriteLine($"Ans:{Output}");
        }

        public static char slowestKey(int[] a, string s) {

            int res = -1, max = -1;
            int last = 0;

            for (int i = 0; i < a.Length; i++)
            {
                int time = a[i] - last;
                last = a[i];
                if (time > max)
                {
                    max = time;
                    res = i;
                }

                if (time.Equals(max))
                {
                    if (s[i] > s[res])
                        res = i;
                }
            }

            return s[res];
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
