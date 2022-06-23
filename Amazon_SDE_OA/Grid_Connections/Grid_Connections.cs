using Amazon_SDE_OA.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_SDE_OA.Grid_Connections
{
    internal class Grid_Connections : ISolution
    {
        public void Solution() {

            Console.WriteLine("Grid Connections");
            var Input = new List<List<int>> {
                new List<int> {1, 1, 1},
                new List<int> {0, 1, 0},
                new List<int> {0, 0, 0},
                new List<int> {1, 1, 0}
            };

            Console.WriteLine("Examples 1");
            var Output = gridOfNodes(Input);
            Console.WriteLine($"Ans: {Output}");
        }

        public int gridOfNodes(List<List<int>> intervals)
        {
            int connections = 0;
            int prevNodes = 1;

            for (int i = 0; i < intervals.Count; i++)
            {
                int currNodeCount = 0;
                for (int j = 0; j < intervals[i].Count; j++)
                {
                    if (intervals[i][j].Equals(1))
                        currNodeCount += 1;
                }

                if (i.Equals(0))
                {
                    prevNodes = currNodeCount;
                    continue;
                }
                else if (i > 0 && currNodeCount.Equals(0))
                {
                    continue;
                }
                else if (currNodeCount >= 1)
                {
                    connections += currNodeCount * prevNodes;
                }
                prevNodes = currNodeCount;
            }

            return connections;
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
