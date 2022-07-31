using Amazon_SDE_Phone_Interview.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_SDE_Phone_Interview.DataStructures
{
    internal class ArraySample : ISolution
    {
        private bool disposedValue;

        public void Solution()
        {
            Console.WriteLine("Multidimensional Arrays");
            Console.WriteLine($"[0, 0] return {MultidimensionalArrays.arr2d32[0,0]}");
            Console.WriteLine($"[0, 1] return {MultidimensionalArrays.arr2d32[0, 1]}");
            Console.WriteLine($"[1, 0] return {MultidimensionalArrays.arr2d32[1, 0]}");
            Console.WriteLine($"[1, 1] return {MultidimensionalArrays.arr2d32[1, 1]}");
            Console.WriteLine($"[2, 0] return {MultidimensionalArrays.arr2d32[2, 0]}");
            Console.WriteLine($"[2, 1] return {MultidimensionalArrays.arr2d32[2, 1]}");
            Console.WriteLine("Jagged Array");
            JaggedArrays.PrintJaggedArrays();
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
        ~ArraySample()
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

        internal static class MultidimensionalArrays
        {
            public static int[,]? arr2d; // two-dimensional array
            public static int[,,]? arr3d; // three-dimensional array
            public static int[,,,]? arr4d; // four-dimensional array
            public static int[,,,,]? arr5d; // five-dimensional array

            public static int[,] arr2d32 = new int[3, 2]{
                                {1, 2},
                                {3, 4},
                                {5, 6}
                            };
        }

        internal static class JaggedArrays
        {
            public static int[][] jArray1 = new int[2][];
            public static int[][,] jArray2 = new int[3][,];

            public static void PrintJaggedArrays()
            {
                int[][] jArray = new int[2][] { 
                    new int[3] { 1, 2, 3},
                    new int[4] { 4, 5, 6, 7}
                };

                for (int i = 0; i < jArray.Length; i++)
                {
                    for (int j = 0; j < jArray[i].Length; j++)
                        Console.WriteLine(jArray[i][j]);
                }

            }
        }
    }
}
