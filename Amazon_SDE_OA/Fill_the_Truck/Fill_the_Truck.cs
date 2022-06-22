using Amazon_SDE_OA.Interface;

namespace Amazon_SDE_OA.Fill_the_Truck
{
    internal class Fill_the_Truck : ISolution
    {
        public void Solution() {
            Console.WriteLine("Fill the Truck");
            // Jagged Array in C#
            var Input = new int[3][];
            Input[0] = new int[2] { 1, 3 };
            Input[1] = new int[2] { 2, 2 };
            Input[2] = new int[2] { 3, 1 };
            var Output = maximumUnits(Input, 4);
            Console.WriteLine($"Ans: {Output}");
        }

        private static int maximumUnits(int[][] boxType, int truckSize)
        {
            Array.Sort(boxType, (a, b) => (b[1] - a[1]));
            
            int i = 0;
            int ans = 0;

            while (i < boxType.Length && truckSize > 0) {
                if (truckSize - boxType[i][0] >= 0)
                {
                    truckSize -= boxType[i][0];
                    ans += boxType[i][0] * boxType[i][1];
                }
                else
                {
                    ans += boxType[i][1] * truckSize;
                    truckSize = 0;
                }

                Console.WriteLine(ans);
                i++;
            }

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
