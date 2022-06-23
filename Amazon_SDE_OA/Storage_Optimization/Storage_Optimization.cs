using Amazon_SDE_OA.Interface;
using System.Numerics;

namespace Amazon_SDE_OA.Storage_Optimization
{
    internal class Storage_Optimization : ISolution
    {
        public void Solution() {

            Console.WriteLine("Storage Optimization");
            Console.WriteLine("Example 1");
            Console.WriteLine($"Ans: {MaxArea(5, 4, new int[] {1, 2, 4}, new int[] { 1,3})}");

            Console.WriteLine("Example 2");
            Console.WriteLine($"Ans: {MaxArea(5, 4, new int[] { 3, 1 }, new int[] { 1 })}");
        }

        public int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts)
        {
            Array.Sort(horizontalCuts);
            Array.Sort(verticalCuts);

            long maxHor = horizontalCuts[0];
            long maxVert = verticalCuts[0];

            for (int i = 1; i < horizontalCuts.Length; i++)
                maxHor = Math.Max(maxHor, horizontalCuts[i] - horizontalCuts[i - 1]);

            maxHor = Math.Max(maxHor, h - horizontalCuts[horizontalCuts.Length - 1]);

            for (int i = 1; i < verticalCuts.Length; i++)
                maxVert = Math.Max(maxVert, verticalCuts[i] - verticalCuts[i - 1]);

            maxVert = Math.Max(maxVert, w - verticalCuts[verticalCuts.Length - 1]);

            BigInteger hor = new BigInteger(maxHor);
            BigInteger vert = new BigInteger(maxVert);
            BigInteger sq = hor * vert;
            sq = sq % 1_000_000_007;
            return (int)sq;
            
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
